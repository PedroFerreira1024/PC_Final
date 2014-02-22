using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ex4
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource taskCts;

        public Form1()
        {
            InitializeComponent();
            SearchTextBox.Text = @"C:\Users\Pedro\Desktop\PC";
        }

        private void Search_click(object sender, EventArgs e)
        {
            TaskScheduler syncCtxScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            taskCts = new CancellationTokenSource();
            CancellationToken ctk = taskCts.Token;

            var backgroundTask = Task.Factory.StartNew(() =>
            {
                Task<Ex3v2.Program.SearchObj> taskSf = Ex3v2.Program.searchAndListFiles(SearchTextBox.Text, ExtensionTextBox.Text,
                WordTextBox.Text, ctk,
                    syncCtxScheduler, (text) =>
                    {
                        ProgressTextBox.AppendText(text + "\n");
                    });

                taskSf.ContinueWith((searchedFiles) =>
                {
                    Ex3v2.Program.SearchObj so = searchedFiles.Result;
                    ProgressTextBox.AppendText(@"Files with specified extension:" + so.countWithExtension + "\n");
                    ProgressTextBox.AppendText(@"Total files: " + so.countTotal + "\n");
                }, CancellationToken.None, TaskContinuationOptions.None, syncCtxScheduler);
            }, ctk, TaskCreationOptions.LongRunning, TaskScheduler.Default);

            backgroundTask.ContinueWith((completed) =>
            {
                try
                {
                    completed.Wait();
                    ProgressTextBox.AppendText("COMPLETED!");
                }
                catch (AggregateException aex)
                {
                    if (aex.InnerException is TaskCanceledException)
                    {
                        ProgressTextBox.AppendText("CANCELED!");
                    }
                    else
                    {
                        ProgressTextBox.AppendText("Unknown exception: " + aex.InnerException);
                    }
                }
            }, CancellationToken.None, TaskContinuationOptions.None, syncCtxScheduler);

            //var obj = Ex3v2.Program.searchAndListFiles(SearchTextBox.Text,ExtensionTextBox.Text,
            //    WordTextBox.Text, ctk,
            //        syncCtxScheduler, (text) => {
            //            ProgressTextBox.AppendText(text+"\n");
            // });

            //ProgressTextBox.AppendText("Total files "+obj.countTotal+"\n");
            //ProgressTextBox.AppendText("COMPLETED!!\n");

        }

        private void Cancel_click(object sender, EventArgs e)
        {
            if (taskCts != null)
            {
                taskCts.Cancel();
            }
        }
    }
}
