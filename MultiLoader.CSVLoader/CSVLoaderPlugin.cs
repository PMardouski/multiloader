using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiLoader.Shared;

namespace MultiLoader.CSVLoader
{
    [DisplayName("CSV")]
    public class CSVLoaderPlugin : IPlugin
    {
        private ControlTemplate controlTemplate;
        private String name = String.Empty;
        private DataGridViewUserControl Control;
        private ICommand command;

        public CSVLoaderPlugin(String name)
        {
            this.name = name;
            Control = new DataGridViewUserControl();
            controlTemplate = new ControlTemplate(this.Name(), Control);
        }

        public void ExecuteCommand(string loadFrom)
        {
            Control.Execute(loadFrom);
        }

        public String Name()
        {
            return this.name;
        }

        public ControlTemplate PluginControls()
        {
            return controlTemplate;
        }
    }
}
