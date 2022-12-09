using DTO;
using ExceptionHandling;
using System;
using System.Collections.Generic;

namespace FingerPrintService.Middlewares
{
    class GeneralFingerPrint
    {
        static GeneralFingerPrint general;

        static VirdiFingerPrint VirdiFP;
        static int VirdiPlugCount = 0;

        static SuprimaFingerPrint SuprimaFP;
        static int SuprimaPlugCount = 0;

        static bool IsFirst = false;
        public GeneralFingerPrint()
        {
            VirdiFP = new VirdiFingerPrint();
            SuprimaFP = new SuprimaFingerPrint();
        }

        public static GeneralFingerPrint Instance()
        {
            if (general == null)
                general = new GeneralFingerPrint();

            return general;
        }

        public static List<DeviceDTO> IsPlug()
        {

            try
            {
                VirdiPlugCount = VirdiFP.IsPlug();
            }
            catch (Exception) { }

            try
            {
                SuprimaPlugCount = SuprimaFP.IsPlug();
            }
            catch (Exception) { }

            List<DeviceDTO> devices = new List<DeviceDTO>();

            if (VirdiPlugCount > 0)
            {
                devices.Add(new DeviceDTO
                {
                    Name = "Virdi",
                    Count = VirdiPlugCount,
                    IsAvable = true
                });
            }

            if (SuprimaPlugCount > 0)
            {
                devices.Add(new DeviceDTO
                {
                    Name = "Suprima",
                    Count = SuprimaPlugCount,
                    IsAvable = true
                });
            }

            if (devices.Count == 0 && !IsFirst)
            {
                general = new GeneralFingerPrint();
                IsFirst = true;
                return IsPlug();
            }
            else
                IsFirst = false;


            return devices;
        }

        public static FingerImageDTO ScanFinger()
        {
            string result = string.Empty;

            if (IsPlug().Count > 0)
            {
                if (SuprimaPlugCount > 0)
                    return SuprimaFP.Scan();
                if (VirdiPlugCount > 0)
                    return VirdiFP.Scan();
            }

            throw new NoDeviceFound();
        }
    }
}
