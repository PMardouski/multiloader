using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using MultiLoader.Shared;
using MultiLoader.Infrastructure;

namespace MultiLoader.Host
{
    public partial class Main : Form
    {
        IUnityContainer container = null;
        private String pluginFilePath = String.Empty;
        private Boolean testMode = false;
        private string _defaultFolder = "C:\\Projects\\MultiLoader\\Sources\\";

        public Main()
        {
            InitializeComponent();
            RegisterPlugins();
            LoadPlugins();
            selectedDirectoryLabel.Text = _defaultFolder;

            var plugin = container.Resolve<IPlugin>("CSV");
            plugin.ExecuteCommand("C:\\Projects\\MultiLoader\\Sources\\TextFile.csv");
            plugin = container.Resolve<IPlugin>("TXT");
            plugin.ExecuteCommand("C:\\Projects\\MultiLoader\\Sources\\TextFile.txt");
            plugin = container.Resolve<IPlugin>("XML");
            plugin.ExecuteCommand("C:\\Projects\\MultiLoader\\Sources\\XMLFile.xml");

            this.textBox1.Text = TimerHelper.Timer.ToString();
        }

        public void RegisterPlugins()
        {
            SetupFilePath();
            container = new UnityContainer();
            
            string[] files = Directory.GetFiles(pluginFilePath, "*.dll");

            Int32 pluginCount = 1;

            foreach (String file in files)
            {
                Assembly assembly = Assembly.LoadFrom(file);

                foreach (Type T in assembly.GetTypes())
                {
                    foreach (Type iface in T.GetInterfaces())
                    {
                        if (iface == typeof(IPlugin))
                        {
                            IPlugin pluginInstance = (IPlugin)Activator.CreateInstance(T, new[] { GetDisplayNameAttribute(T) ?? T.Name });
                            container.RegisterInstance<IPlugin>(pluginInstance.Name(), pluginInstance);
                        }
                    }
                }
            }
        }

        private void SetupFilePath()
        {
            var directoryInfo = Directory.GetParent(Directory.GetCurrentDirectory()).Parent;
            if (directoryInfo != null)
                pluginFilePath = directoryInfo.FullName + @"\Plugins\";
        }

        private string GetDisplayNameAttribute(Type T)
        {
            var attributes = T.GetCustomAttributes(typeof (DisplayNameAttribute), true);
            if(attributes.Length == 0)
                return null;

            var attr = attributes.Cast<DisplayNameAttribute>().Single();
            return attr.DisplayName;
        }

        private void chooseFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fld = new FolderBrowserDialog
            {
                SelectedPath = _defaultFolder,
                ShowNewFolderButton = true
            };

            if (fld.ShowDialog() == DialogResult.OK)
            {
                _defaultFolder = fld.SelectedPath;
                selectedDirectoryLabel.Text = _defaultFolder;
            }
        }

        private void LoadPlugins()
        {
            if (container != null)
            {
                hostTabControl.TabPages.Clear();
                
                var loadedPlugins = container.ResolveAll<IPlugin>().ToList();

                if (loadedPlugins.Count > 0)
                    hostTabControl.Visible = true;

                foreach (var loadedPlugin in loadedPlugins)
                {
                    TabPage tabPage = new TabPage(loadedPlugin.Name());
                    tabPage.Controls.Add(loadedPlugin.PluginControls().UserControlContainer);
                    hostTabControl.TabPages.Add(tabPage);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int timer;
            if (int.TryParse(textBox1.Text, out timer))
            {
                TimerHelper.Timer = timer;
            }
        }
    }
}
