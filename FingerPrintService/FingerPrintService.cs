using Microsoft.Owin.Hosting;
using System;
using System.ServiceProcess;
using Utilities;

namespace FingerPrintService
{
    public partial class FingerPrintService : ServiceBase
    {

        IDisposable webAPI;

        public FingerPrintService()
        {
            InitializeComponent();
        }

        public void onDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            string baseAddress = "http://" + Constants.WindowsServiceUrl + ":" + Constants.WindowsServicePort + "/";

            // Start OWIN host 
            webAPI = WebApp.Start<Startup>(url: baseAddress);

            LogWriter.Log(Constants.FingerServiceName + " Started");

        }

        protected override void OnStop()
        {
            // Stop OWIN host 
            webAPI.Dispose();
            LogWriter.Log("WebAPI Dispose");

            GC.Collect();
            GC.WaitForPendingFinalizers();
            LogWriter.Log("GC Collect");

            LogWriter.Log(Constants.FingerServiceName + " Stoped");
        }
    }
}
