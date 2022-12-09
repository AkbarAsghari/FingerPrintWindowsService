using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class FingerImageDTO
    {
        public FingerImageDTO(string exception , SystemDTO systemDTO)
        {
            Exception = exception;
            DeviceName = "Unknown";
            SystemInfo = systemDTO;
            Image = "";
            Quality = 0;
        }

        public FingerImageDTO() {}
        public SystemDTO SystemInfo { get; set; }
        public string DeviceName { get; set; }
        public int Quality { get; set; }
        public string Exception { get; set; }
        public string Image { get; set; }
    }
}
