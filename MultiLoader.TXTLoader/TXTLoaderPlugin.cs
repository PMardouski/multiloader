using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiLoader.Shared;

namespace MultiLoader.TXTLoader
{
    [DisplayName("TXT")]
    public class TXTLoaderPlugin : IPlugin
    {
        private ControlTemplate controlTemplate;
        private String name = String.Empty;
        private DataGridViewUserControl Control;

        public TXTLoaderPlugin(String name)
        {
            this.name = name;
            Control = new DataGridViewUserControl();
            controlTemplate = new ControlTemplate(this.Name(), Control);

        }

        public String Name()
        {
            return this.name;
        }

        public ControlTemplate PluginControls()
        {
            return controlTemplate;
        }

        public void ExecuteCommand(string loadFrom)
        {
            Control.Execute(loadFrom);
        }
    }
}
