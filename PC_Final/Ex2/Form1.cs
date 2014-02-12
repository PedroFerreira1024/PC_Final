using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using TestClient;

namespace Ex2
{
    public partial class Form1 : Form
    {

        private const int PORT = 8888;
        private const int TIMEOUT = 1000;

        public SynchronizationContext contextUI = SynchronizationContext.Current;

        public Form1()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            var toRegister = regTextBox.Text.Split(',');
            Task.Factory.StartNew(() =>
            {
                Client.Register(toRegister, "192.1.1.1", 5555);
                contextUI.Post() }));
            });
        }

        private void UnRegister_Click(object sender, EventArgs e)
        {

        }

        private void ListFiles_Click(object sender, EventArgs e)
        {

        }
        
        private void ListLocation_Click(object sender, EventArgs e)
        {

        }
    }
}
