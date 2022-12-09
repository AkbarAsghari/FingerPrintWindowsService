namespace FingerPrintService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serviceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.FingerPrintInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // serviceProcessInstaller
            // 
            this.serviceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.serviceProcessInstaller.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.FingerPrintInstaller});
            this.serviceProcessInstaller.Password = null;
            this.serviceProcessInstaller.Username = null;
            // 
            // FingerPrintInstaller
            // 
            this.FingerPrintInstaller.Description = "Develope by Donya Pardaz";
            this.FingerPrintInstaller.DisplayName = "Finger Print Donya Pardaz";
            this.FingerPrintInstaller.ServiceName = "FingerPrintService";
            this.FingerPrintInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            this.FingerPrintInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.FingerPrintInstaller_AfterInstall);
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller FingerPrintInstaller;  
    }
}