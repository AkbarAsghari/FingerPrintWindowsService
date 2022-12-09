using DTO;
using System;
using System.Linq;
using System.Net.NetworkInformation;

namespace Utilities
{
    public class SystemTool
    {
        public static string GetMacAddress()
        {
            return NetworkInterface
                        .GetAllNetworkInterfaces()
                        .Where(nic => nic.OperationalStatus == OperationalStatus.Up && nic.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                        .Select(nic => nic.GetPhysicalAddress().ToString())
                        .FirstOrDefault();
        }

        public static string GetDomainName()
        {
            return IPGlobalProperties.GetIPGlobalProperties().DomainName;
        }

        public static string GetSystemName()
        {
            return IPGlobalProperties.GetIPGlobalProperties().HostName;
        }

        public static string GetSystemTime()
        {
            return DateTime.Now.ToFileTime().ToString();
        }

        public static SystemDTO GetSystem()
        {
            return new SystemDTO
            {
                DomainName = GetDomainName(),
                MacAddress = GetMacAddress(),
                SystemName = GetSystemName(),
                SystemTime = DateTime.Now.ToFileTime().ToString()
            };
        }
        public static string GenerateMDSS(ref SystemDTO systemDTO)
        {
            return systemDTO.MacAddress + systemDTO.DomainName + systemDTO.SystemName + systemDTO.SystemTime;//+ Constants.EncryptionPassword;
        }
    }
}
