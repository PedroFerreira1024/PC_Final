using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.IO;

namespace Tracker
{
    // Logger single-threaded.
    public class Logger
    {
        private readonly TextWriter writer;
        private DateTime start_time;
        private int num_requests;

        public Logger() : this(Console.Out) { }
        public Logger(string logfile) : this(new StreamWriter(new FileStream(logfile, FileMode.Append, FileAccess.Write))) { }
        public Logger(TextWriter awriter)
        {
            num_requests = 0;
            writer = awriter;
        }

        public void Start()
        {
            start_time = DateTime.Now;
            writer.WriteLine();
            writer.WriteLine(String.Format("::- LOG STARTED @ {0} -::", DateTime.Now));
            writer.WriteLine();
        }

        public void LogMessage(string msg)
        {
            writer.WriteLine(String.Format("{0}: {1}", DateTime.Now, msg));
        }

        public void IncrementRequests()
        {
            ++num_requests;
        }

        public void Stop()
        {
            long elapsed = DateTime.Now.Ticks - start_time.Ticks;
            writer.WriteLine();
            LogMessage(String.Format("Running for {0} second(s)", elapsed / 10000000L));
            LogMessage(String.Format("Number of request(s): {0}", num_requests));
            writer.WriteLine();
            writer.WriteLine(String.Format("::- LOG STOPPED @ {0} -::", DateTime.Now));
            writer.Close();
        }
    }

    public class MyLogger
    {
        TextWriter writer;
        Thread lowThread;

        private DateTime start_time;
        private bool stopped;
        LinkedList<String> msgList = new LinkedList<String>();



        public MyLogger(TextWriter tw)
        {
            writer = tw;
        }

        public void writerFunc(Object obj)
        {
            lock (this)
            {
                while (true)
                {
                    foreach (String currentMsg in msgList)
                    {
                        writer.WriteLine(currentMsg);
                    }
                
                    if (stopped)
                        return;
                    try
                    {
                        Monitor.Wait(this);
                    }
                    catch (ThreadInterruptedException)
                    {
                        if (stopped)
                        {
                            //Não será necessário regenerar uma notificação que possa ficar perdida
                            // pois não deverá haver mais do que uma thread com esta função
                            Thread.CurrentThread.Interrupt();
                            return;
                        }
                    }
                }
            }
        }

        //
        //Passa a mensagem
        //
        public void LogMessage(String msg)
        {
            lock (this)
            {
                if (stopped)
                    throw new Exception();

                Monitor.Pulse(this);
                msgList.AddLast(msg);
            }
        }

        public void Start(int timeout)
        {
            lock (this)
            {
                start_time = DateTime.Now;
                writer.WriteLine();
                writer.WriteLine(String.Format("::- LOG STARTED @ {0} -::", DateTime.Now));
                writer.WriteLine();
                //===============
                lowThread = new Thread(writerFunc);
                lowThread.Priority = ThreadPriority.Lowest;
                lowThread.Start();
            }
        }

        public void Stop()
        {
            lock (this)
            {
                if (msgList.Count == 0)
                    return;

                long elapsed = DateTime.Now.Ticks - start_time.Ticks;
                writer.WriteLine();
                LogMessage(String.Format("Running for {0} second(s)", elapsed / 10000000L));
                //LogMessage(String.Format("Number of request(s): {0}", num_requests));
                writer.WriteLine();
                writer.WriteLine(String.Format("::- LOG STOPPED @ {0} -::", DateTime.Now));
                writer.Close();

                stopped = true;
            }

            lowThread.Join();
        }
    }
}
