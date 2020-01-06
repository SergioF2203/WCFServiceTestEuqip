using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceProcess;

namespace EquipService
{
    [RunInstaller(true)]
    public partial class EquipServiceInstaller : System.Configuration.Install.Installer
    {
        public EquipServiceInstaller()
        {
            //InitializeComponent();
            serviceProcessInstaller1 = new ServiceProcessInstaller();
            serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;
            serviceInstaller1 = new ServiceInstaller();
            serviceInstaller1.ServiceName = "WindowsServiceHostForEquipService";
            serviceInstaller1.DisplayName = "WindowsServiceHostForEquipService";
            serviceInstaller1.Description = "WCF Service";
            serviceInstaller1.StartType = ServiceStartMode.Automatic;
            Installers.Add(serviceProcessInstaller1);
            Installers.Add(serviceInstaller1);
        }
    }
}
