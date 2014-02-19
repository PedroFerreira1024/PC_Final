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
        private const string defaultIP = "127.0.0.1";

        public SynchronizationContext contextUI;

        public Form1()
        {
            InitializeComponent();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            if (regTextBox.Text.Equals("") || regTextBox.Text.Equals("File(s) are Missing!!"))
            {
                regTextBox.Text="File(s) are Missing!!";
                return;
            }
            var toRegister = regTextBox.Text.Split(',');
            contextUI = SynchronizationContext.Current;
            Task.Factory.StartNew(() =>
            {
                contextUI.Post((s) => { regTextBox.Text = ""; }, null);
                foreach(String file in toRegister){
                    Client.Register(toRegister, defaultIP , 5555);
                    contextUI.Post((s) => { showResultBox.AppendText("> Registed - " + file + "\n"); }, null);
                }
                contextUI.Post((s) => { showResultBox.AppendText(">\n"); }, null);
            });
        }

        private void UnRegister_Click(object sender, EventArgs e)
        {
            if (unRegTextBox.Text.Equals("") || unRegTextBox.Text.Equals("file is Missing!!"))
            {
                regTextBox.Text = "file is Missing!!";
                return;
            }
            var toUnRegister = unRegTextBox.Text;
            contextUI = SynchronizationContext.Current;
            Task.Factory.StartNew(() =>
            {
                Client.Unregister(toUnRegister, defaultIP, 5555);
                contextUI.Post((s) => { unRegTextBox.Text = ""; }, null);
                contextUI.Post((s) => { showResultBox.AppendText("> UnRegisted - " + toUnRegister + "\n"); }, null);
                contextUI.Post((s) => { showResultBox.AppendText(">\n"); }, null);
            });
        }

        private void ListFiles_Click(object sender, EventArgs e)
        {
            contextUI = SynchronizationContext.Current;
            Task.Factory.StartNew(() =>
            {
                var list = Client.ListFiles();
                foreach(String file in list)
                {
                    contextUI.Post((s) => { showResultBox.AppendText("> Listing All Files:\n"); }, null);
                    contextUI.Post((s) => { showResultBox.AppendText("> => " + file + "\n"); }, null);
                    contextUI.Post((s) => { showResultBox.AppendText(">\n"); }, null);
                }
            });
        }
        
        private void ListLocation_Click(object sender, EventArgs e)
        {
            if (locationToList.Text.Equals("") || locationToList.Text.Equals("location is Missing!!"))
            {
                locationToList.Text = "location is Missing!!";
                return;
            }
            var location = locationToList.Text;
            contextUI = SynchronizationContext.Current;
            Task.Factory.StartNew(() =>
            {
                var list = Client.ListLocations(location);
                contextUI.Post((s) => { locationToList.Text = ""; }, null);
                foreach (String file in list)
                {
                    contextUI.Post((s) => { showResultBox.AppendText("> Listing All Files in Location:\n"); }, null);
                    contextUI.Post((s) => { showResultBox.AppendText("> => " + file + "\n"); }, null);
                }
                contextUI.Post((s) => { showResultBox.AppendText(">\n"); }, null);
            });
        }
    }
}
