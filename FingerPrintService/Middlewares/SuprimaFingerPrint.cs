using DTO;
using ExceptionHandling;
using Suprema;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using Utilities;

namespace FingerPrintService.Middlewares
{
    class SuprimaFingerPrint
    {
        const int MAX_TEMPLATE_SIZE = 304;
        public static UFScannerManager ScannerManager;
        public static UFS_STATUS ufs_res;
        public static UFScanner Scanner;
        public static int nScannerNumber;

        public SuprimaFingerPrint()
        {
            //initinlize
            ScannerManager = new UFScannerManager(null);
            ufs_res = ScannerManager.Init();
            nScannerNumber = ScannerManager.Scanners.Count;
            //Configuratuing BioMini
            if (ScannerManager.Scanners[0] != null)
            {
                Scanner = ScannerManager.Scanners[0];
                Scanner.Timeout = Constants.ScannWaitTime; // 7 sec
                Scanner.TemplateSize = MAX_TEMPLATE_SIZE;
                Scanner.DetectCore = false;
            }
            else
            {
                ScannerManager.Uninit();
            }

        }

        internal int IsPlug() => ScannerManager.Scanners.Count;

        static object lockScan = new object();
        static int attempt = 0;
        public FingerImageDTO Scan()
        {
            lock (lockScan)
            {
                try
                {
                    //Enrolling a finger using BioMini
                    byte[] template0 = new byte[MAX_TEMPLATE_SIZE];
                    byte[] template1 = new byte[MAX_TEMPLATE_SIZE];
                    int TemplateSize;
                    int EnrollQuality;

                    Dictionary<string, object> dicFinger = new Dictionary<string, object>();

                    List<object> fingerprint_template_list = new List<object>();
                    dicFinger.Add("fingerprint_template_list", fingerprint_template_list);

                    ufs_res = Scanner.ClearCaptureImageBuffer();
                    ufs_res = Scanner.CaptureSingleImage();
                    ufs_res = Scanner.ExtractEx(MAX_TEMPLATE_SIZE, template0, out TemplateSize, out EnrollQuality);

                    if (EnrollQuality < 80)
                    {
                        attempt++;
                        if (attempt == Constants.AttempTimeForRescanFinger)
                        {
                            Scanner.AbortCapturing();
                            attempt = 0;
                            throw new MaximumAttempt();
                        }

                        Thread.Sleep(1000);
                        return Scan();
                    }

                    int resulation;
                    Bitmap bitmapImage;

                    ufs_res = Scanner.GetCaptureImageBuffer(out bitmapImage, out resulation);

                    Bitmap newBitMap = ImageUtilities.AdjustContrast(bitmapImage, 12);


                    var SystemInfo = SystemTool.GetSystem();

                    return new FingerImageDTO
                    {
                        Image = StringCipher.Encrypt(ImageUtilities.BitMapToBase64(newBitMap), SystemTool.GenerateMDSS(ref SystemInfo)),
                        Quality = EnrollQuality,
                        DeviceName = "Suprima",
                        SystemInfo = SystemInfo
                    };
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}
