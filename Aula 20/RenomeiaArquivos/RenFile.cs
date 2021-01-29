using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Runtime.InteropServices;

namespace RenomeiaArquivos
{
    public partial class RenFile : ServiceBase
    {
        [DllImport("advapi32.dll", SetLastError = true)]
        private static extern bool SetServiceStatus(System.IntPtr handle, ref ServiceStatus serviceStatus);

        public RenFile()
        {
            InitializeComponent();

            evLog = new System.Diagnostics.EventLog();
            const string source = "RenomeiaArq";
            const string log = "LogMonitoramento";

            if (!System.Diagnostics.EventLog.SourceExists(source))
                System.Diagnostics.EventLog.CreateEventSource(source, log);

            evLog.Source = source;
            evLog.Log = log;
        }

        protected override void OnStart(string[] args)
        {
            // Update the service state to Start Pending.
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwCurrentState = ServiceState.SERVICE_START_PENDING;
            serviceStatus.dwWaitHint = 100000;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            evLog.WriteEntry("Serviço iniciado");

            //Simula um tempo grande de carga
            System.Threading.Thread.Sleep(10000);

            // Update the service state to Running.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_RUNNING;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);

            Timer timer = new Timer();
            timer.Interval = 10000; // 10 seconds
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        protected override void OnContinue()
        {
            evLog.WriteEntry("Serviço iniciado novamente");
        }

        protected override void OnPause()
        {
            evLog.WriteEntry("Serviço pausado");
        }

        protected override void OnStop()
        {
            ServiceStatus serviceStatus = new ServiceStatus();
            serviceStatus.dwWaitHint = 100000;
            
            evLog.WriteEntry("Serviço parado");
            // Update the service state to Stopped.
            serviceStatus.dwCurrentState = ServiceState.SERVICE_STOPPED;
            SetServiceStatus(this.ServiceHandle, ref serviceStatus);
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            evLog.WriteEntry("Procurando arquivos", EventLogEntryType.Information, eventId++);

            RenomearArquivos();
        }

        private void RenomearArquivos()
        {
            var arquivos = Directory.GetFiles(@"C:\Temp\Testes", "*.txt");

            foreach (var arq in arquivos)
            {
                File.Move(arq, arq + ".ok");
                evLog.WriteEntry($"'{arq}' renomeado");
            }
        }

        private int eventId = 0;
    }

    public enum ServiceState
    {
        SERVICE_STOPPED = 0x00000001,
        SERVICE_START_PENDING = 0x00000002,
        SERVICE_STOP_PENDING = 0x00000003,
        SERVICE_RUNNING = 0x00000004,
        SERVICE_CONTINUE_PENDING = 0x00000005,
        SERVICE_PAUSE_PENDING = 0x00000006,
        SERVICE_PAUSED = 0x00000007,
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct ServiceStatus
    {
        public int dwServiceType;
        public ServiceState dwCurrentState;
        public int dwControlsAccepted;
        public int dwWin32ExitCode;
        public int dwServiceSpecificExitCode;
        public int dwCheckPoint;
        public int dwWaitHint;
    }
}
