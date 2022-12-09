using DTO;
using ExceptionHandling;
using System;
using System.Drawing;
using System.Threading;
using UNIONCOMM.SDK.UCBioBSP;
using Utilities;

namespace FingerPrintService.Middlewares
{
    class VirdiFingerPrint
    {
        UCBioAPI ucBioAPI;
        UCBioAPI.Type.WINDOW_OPTION winOption;
        short openedDeviceID;
        UCBioAPI.Type.HFIR hEnrolledFIR;
        UCBioAPI.Export exportAPI;

        UCBioAPI.FastSearch fastSearch;

        UCBioAPI.Export.EXPORT_AUDIT_DATA eXPORT_AUDIT_DATA;

        uint numDevice;
        short[] deviceIDs;

        internal int IsPlug()
        {
            this.ucBioAPI.EnumerateDevice(out numDevice, out deviceIDs);
            return Convert.ToInt32(numDevice);
        }

        public VirdiFingerPrint()
        {
            this.ucBioAPI = new UCBioAPI();

            this.winOption = new UCBioAPI.Type.WINDOW_OPTION();
            this.hEnrolledFIR = null;

            this.openedDeviceID = UCBioAPI.Type.DEVICE_ID.NONE;

            this.exportAPI = new UCBioAPI.Export(this.ucBioAPI);

            this.fastSearch = new UCBioAPI.FastSearch(ucBioAPI);

            this.eXPORT_AUDIT_DATA = new UCBioAPI.Export.EXPORT_AUDIT_DATA();
        }

        static object lockScan = new object();
        static int attempt = 0;
        public FingerImageDTO Scan()
        {
            lock (lockScan)
            {
                try
                {
                    if (deviceIDs.Length == 0)
                        return Scan();
                    // Close Device if before opened
                    this.ucBioAPI.CloseDevice(deviceIDs[0]);
                    UCBioAPI.Type.HFIR CapturedFIR = new UCBioAPI.Type.HFIR();

                    UCBioAPI.Type.FIR fullFIR;

                    // Open device
                    uint ret = this.ucBioAPI.OpenDevice(deviceIDs[0]);
                    if (ret == UCBioAPI.Error.NONE)
                    {
                        winOption.WindowStyle = 1;

                        UCBioAPI.Type.HFIR hFIR = new UCBioAPI.Type.HFIR();
                        ret = this.ucBioAPI.Capture(UCBioAPI.Type.FIR_PURPOSE.VERIFY, out CapturedFIR, Constants.ScannWaitTime, hFIR, winOption);
                        if (ret == UCBioAPI.Error.NONE)
                        {
                            ret = this.ucBioAPI.CloseDevice(deviceIDs[0]);

                            this.ucBioAPI.GetFIRFromHandle(CapturedFIR, out fullFIR);
                            this.exportAPI.AuditFIRToImage(hFIR, out eXPORT_AUDIT_DATA);

                            if (fullFIR.Header.Quality < 80)
                            {
                                attempt++;
                                if (attempt == Constants.AttempTimeForRescanFinger)
                                {
                                    ret = this.ucBioAPI.CloseDevice(deviceIDs[0]);
                                    attempt = 0;
                                    throw new MaximumAttempt();
                                }

                                Thread.Sleep(1000);
                                return Scan();
                            }

                            byte[] img = eXPORT_AUDIT_DATA.AuditData[0].Image[0].Data;

                            Bitmap bitmap = ImageUtilities.RawToBitMap(Convert.ToInt32(eXPORT_AUDIT_DATA.ImageWidth), Convert.ToInt32(eXPORT_AUDIT_DATA.ImageHeight), img);

                            Bitmap newBitMap = ImageUtilities.AdjustContrast(bitmap, 5);

                            var SystemInfo = SystemTool.GetSystem();

                            return new FingerImageDTO
                            {
                                Image = StringCipher.Encrypt(ImageUtilities.BitMapToBase64(newBitMap), SystemTool.GenerateMDSS(ref SystemInfo)),
                                Quality = fullFIR.Header.Quality,
                                DeviceName = "Virdi",
                                SystemInfo = SystemInfo
                            };
                        }
                        else
                        {
                            attempt++;
                            if (attempt == Constants.AttempTimeForRescanFinger)
                            {
                                ret = this.ucBioAPI.CloseDevice(deviceIDs[0]);
                                attempt = 0;
                                throw new MaximumAttempt();
                            }
                        }
                    }
                    

                    return Scan();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
