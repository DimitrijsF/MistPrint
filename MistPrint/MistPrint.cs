using MistPrintCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MistPrint
{
    public partial class MistPrint : ServiceBase
    {
        public MistPrint()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            Locals.Core = new Core();
            Locals.Core.Initialize();
        }

        protected override void OnStop()
        {
            Locals.Core?._webApp?.Dispose();
        }
    }
}
