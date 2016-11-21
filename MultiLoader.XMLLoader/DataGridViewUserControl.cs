using System;
using MultiLoader.Shared;

namespace MultiLoader.XMLLoader
{
    public partial class DataGridViewUserControl : UserControlWithCallBack
    {
        private XMLReader _reader;
        public DataGridViewUserControl()
        {
            InitializeComponent();
            _reader = XMLReader.GetInstance();
        }

        public void Execute(string loadFrom)
        {
            dataGridViewTest.DataSource = _reader.LoadData(loadFrom);
            dataGridViewTest.Visible = true;
        }
    }
}
