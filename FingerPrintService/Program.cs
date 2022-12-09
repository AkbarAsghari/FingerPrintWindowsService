using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FingerPrintService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {

            if (Debugger.IsAttached)
            {
                FingerPrintService myService = new FingerPrintService();
                myService.onDebug();

                System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                {
                 new FingerPrintService()
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

    }
}
