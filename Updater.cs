using Squirrel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace myRouter
{
    public static class Updater
    {
        public static string currentReleaseNote = null;

        public static UpdateInfo update;
        static bool updateCheckAttempt;
       // static bool updateCheckAttempt;
        static Dispatcher dispatcher;
     public static  UpdateManager mgr ;
     public   static ReleaseEntry releaseEntry;
        public static ReleaseEntry installedReleaseEntry;
      public  static Boolean downloaded = false;
        public static Boolean installed = false;
      public  static bool updateCheck = false;
        public static Task task;



         public static string getCurrentReleaseNote()
        {
            ;
           
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            string content = File.ReadAllText(WpfApplication4.MainWindow.appDirectory + @"\packages\RELEASES");
            List<ReleaseEntry> lists = ReleaseEntry.ParseReleaseFile(content).ToList();
            ;
            foreach (var release in lists)
            {
                if (release.Version.Version == ver)
                {
                    try
                    {
                        return release.GetReleaseNotes(WpfApplication4.MainWindow.appDirectory + @"\packages");
                    }
                    catch(Exception ex)
                    {
                        return null;
                    }
                    
                }
            }



            return null;
        }

        public static void updateMyRouter()
        {

           task = new Task(startUpdate);
            task.Start();
        }
        public static  void startUpdate()
        {
           
                mgr = new UpdateManager(@"https://raw.githubusercontent.com/reguez/myRouterBeta/master/Releases");


            mgr.CheckForUpdate().ContinueWith(updateCheckCompleted, TaskContinuationOptions.OnlyOnRanToCompletion)
               .ContinueWith(updateCheckFailed, TaskContinuationOptions.OnlyOnFaulted);
        }

        private static void updateCheckFailed(Task obj)
        {
            ;//update check failed  retry check
            mgr.CheckForUpdate().ContinueWith(updateCheckCompleted, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith(updateCheckFailed, TaskContinuationOptions.OnlyOnFaulted);

        }

        public static  void downloadUpdate()
        {
            Console.WriteLine("donwloading update");

            if (releaseEntry != null)
            {
                List<ReleaseEntry> releaseToDownload = new List<ReleaseEntry>();


                releaseToDownload.Add(releaseEntry);

                mgr.DownloadReleases(releaseToDownload).ContinueWith(applyDownload, TaskContinuationOptions.OnlyOnRanToCompletion)
                    .ContinueWith(DownloadFailed, TaskContinuationOptions.OnlyOnFaulted);
             //mgr.DownloadReleases(releaseToDownload).ContinueWith(DownloadFailed, TaskContinuationOptions.OnlyOnFaulted);

               

             
               
            }
           


        }

        private static void DownloadFailed(Task obj)
        {
            Console.WriteLine("download failded");
            List<ReleaseEntry> releaseToDownload = new List<ReleaseEntry>();


            releaseToDownload.Add(releaseEntry);
            mgr.DownloadReleases(releaseToDownload).ContinueWith(applyDownload, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(DownloadFailed, TaskContinuationOptions.OnlyOnFaulted);
    
        }

        public static  void updateFinish(Task<string> task)
        {
            Console.WriteLine("done updating");
            installed = true;
            installedReleaseEntry = releaseEntry;
              
            ;//done updating
           
            

        }


        public static void applyDownload(Task task)
        {
            downloaded = true;
           currentReleaseNote = getCurrentReleaseNote();
         
            Console.WriteLine("installing update");
            ;//installing update
            mgr.ApplyReleases(update).ContinueWith(updateFinish, TaskContinuationOptions.OnlyOnRanToCompletion)
               .ContinueWith(installFailed, TaskContinuationOptions.OnlyOnFaulted);
            /*
                .ContinueWith(_ =>
            {
                dispatcher.Invoke(new Action(() =>
                {
                    status.Visibility = Visibility.Collapsed;
                    failed.Visibility = Visibility.Visible;
                    Console.WriteLine("what happen");

                }));


            }, TaskContinuationOptions.OnlyOnFaulted);

           
            */
        }

        private static void installFailed(Task obj)
        {
            Console.WriteLine("install failed");
            ; //install failded
            mgr.ApplyReleases(update).ContinueWith(updateFinish, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(installFailed, TaskContinuationOptions.OnlyOnFaulted);
        }

        private static void updateCheckCompleted(Task<UpdateInfo> task)
        {




            update = task.Result;
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            if (update != null)
            {
                if(update.FutureReleaseEntry.Version.Version != ver)
                {
                    releaseEntry = update.FutureReleaseEntry;
                    ;//downloading update
                    downloadUpdate();
                }
              

            }





        }

        public static void initializeUpdater()
        {
            mgr = new UpdateManager(@"https://raw.githubusercontent.com/reguez/myRouterBeta/master/Releases");
        }

        private static int _isUpdateManagerDisposed = 1;
        internal static void DisposeUpdateManager()
        {
            WaitForCheckForUpdateLockAcquire();

            if (1 == Interlocked.Exchange(ref _isUpdateManagerDisposed, 0))
            {
                mgr.Dispose();
            }
        }

        /// <summary>
        /// Workaround for exception throw on SingleGlobalInstance destructor call.
        /// Before app close we should wait for 2 seconds before SingleGlobalInstance will be disposed
        /// </summary>
        private static void WaitForCheckForUpdateLockAcquire()
        {
            var goTime = _lastUpdateCheckDateTime + TimeSpan.FromMilliseconds(2000);
            var timeToWait = goTime - DateTime.Now;
            if (timeToWait > TimeSpan.Zero)
                Thread.Sleep(timeToWait);
        }
        private static DateTime _lastUpdateCheckDateTime = DateTime.Now - TimeSpan.FromDays(1);
       

        private static async Task<UpdateInfo> CheckForUpdate(bool ignoreDeltaUpdates)
        {
            _lastUpdateCheckDateTime = DateTime.Now;
            return await mgr.CheckForUpdate(ignoreDeltaUpdates);
        }

    
    }
}
