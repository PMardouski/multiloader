using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiLoader.Shared
{
    public class ControlTemplate
    {
        public UserControlWithCallBack UserControlContainer;
        public ToolStripMenuItem MenuStripItemContainer;

        public ControlTemplate(String name, UserControlWithCallBack pluginUserControl)
        {
            UserControlContainer = new UserControlWithCallBack();

            UserControlContainer = pluginUserControl;
        }
    }
}
