using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLoader.Shared
{
    public interface IPlugin : ICommand
    {
        String Name();
        ControlTemplate PluginControls();
    }
}
