using System;
using MultiLoader.Shared;

namespace MultiLoader.TXTLoader
{
    public partial class DataGridViewUserControl : UserControlWithCallBack
    {
        private TXTReader _reader;
        public DataGridViewUserControl()
        {
            InitializeComponent();
            _reader = TXTReader.GetInstance();
        }

        public void Execute(string loadFrom)
        {
            dataGridViewTest.DataSource = _reader.LoadData(loadFrom);
            dataGridViewTest.Visible = true;
        }
    }
}
