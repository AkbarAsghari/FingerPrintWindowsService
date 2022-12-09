using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{

    public class VersionAndUrlDTO
    {
        public string version { get; set; }
        public string url { get; set; }
        public string changelog { get; set; }
        public ChecksumDTO checksum { get; set; }
    }
}
