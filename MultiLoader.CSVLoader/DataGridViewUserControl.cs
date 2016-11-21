using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using MultiLoader.Shared;
using ICommand = MultiLoader.Shared.ICommand;

namespace MultiLoader.CSVLoader
{
    public partial class DataGridViewUserControl : UserControlWithCallBack
    {
        private CSVReader _reader;
        public DataGridViewUserControl()
        {
            InitializeComponent();
            _reader = CSVReader.GetInstance();
        }

        public void Execute(string loadFrom)
        {
            dataGridViewTest.DataSource = _reader.LoadData(loadFrom);
            dataGridViewTest.Visible = true;
        }
    }
}
