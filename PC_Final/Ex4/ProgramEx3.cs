using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Ex3v2
{
    public class Program
    {
        public static CancellationTokenSource cToken;

        public class SearchObj
        {
            public volatile int countTotal;
            public volatile int countWithExtension;
            public List<String> filesSearched;

            public SearchObj()
            {
                filesSearched = new List<String>();
            }
        }

        public static Task<SearchObj> searchAndListFiles(String rootPath, String extension, String toLookFor,
                                    CancellationToken token, TaskScheduler syncCtxScheduler, Action<String> callback)
        {
            token.ThrowIfCancellationRequested();
            DirectoryInfo root = new DirectoryInfo(rootPath);

            var rootTasks = new List<Task<SearchObj>>();

            foreach(var dir in root.EnumerateDirectories())
            {
                rootTasks.Add(searchAndListFiles(rootPath + "\\" + dir.Name, extension, toLookFor,token,syncCtxScheduler, callback));
            }

            //
            //Para testar cancelamento
            //cToken.Cancel();

            var tasks = new List<Task<SearchObj>>();
            var obj = new SearchObj();
            Parallel.ForEach(root.EnumerateFiles(), (file,loopstate) =>
            {
                if (token.IsCancellationRequested)
                {
                    loopstate.Break();
                }

                Interlocked.Increment(ref obj.countTotal);
                if (file.Extension.Equals(extension))
                {

                    Interlocked.Increment(ref obj.countWithExtension);

                    tasks.Add(Task.Factory.StartNew<SearchObj>(() =>
                    {
                        
                        using (FileStream stream = file.OpenRead())
                        {
                            byte[] buff = new byte[file.Length];
                            UTF8Encoding temp = new UTF8Encoding(true);

                            while (stream.Read(buff, 0, buff.Length) > 0)
                            {
                                if (temp.GetString(buff).Contains(toLookFor))
                                {
                                    lock (obj)
                                    {
                                        obj.filesSearched.Add(file.FullName);
                                    }
                                    Task.Factory.StartNew((x) => callback(file.FullName), null,
                                                            token, TaskCreationOptions.None, syncCtxScheduler);
                                }
                            }
                            return obj;
                        }
                    }, token));
                }
            });

            token.ThrowIfCancellationRequested();

            return Task.WhenAll(rootTasks).ContinueWith<SearchObj>((x) => {
                
                foreach(SearchObj i in x.Result)
                {
                    obj.countTotal += i.countTotal;
                    obj.countWithExtension += i.countWithExtension;
                    obj.filesSearched.AddRange(i.filesSearched);
                }
                return obj;
            });
        }
    }
}
