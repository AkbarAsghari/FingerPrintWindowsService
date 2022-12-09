namespace Utilities
{
    public static class Constants
    {
        public const bool Debug = true;
        public const string WindowsServiceUrl = "localhost";
        public const int WindowsServicePort = 9000;
        public const string FingerServiceName = "FingerPrintDonyaPardaz";
        public const string FingerPrintServiceEXEName = "FingerPrintService";
        public const string FingerUpdateServiceName = "FingerPrintUpdaterService";
        public const string UpdateServiceUrl = "http://192.168.101.53:23349/update";
        public const string LoggerServiceUrl = "http://192.168.101.53:23349/logger";
        public const int UpdaterIntervalMinutes = 0;
        public const int ExceptionIntervalMinutes = 5;
        public const string EncryptionPassword = "";
        public const string DefaultFingerPrintServicePath = @"C:\Program Files (x86)\Default Company Name\FingerPrintServiceSetup\";
        public const int AttempTimeForRescanFinger = 5;
        public const int ScannWaitTime = 7 * 1000;
    }
}
