using MahApps.Metro.Controls;
using myRouter;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Serialization;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for updateDialog.xaml
    /// </summary>
    public partial class updateDialog : MetroWindow
    {
        UpdateInfo update;
        Dispatcher dispatcher;
        UpdateManager mgr=null;
        ReleaseEntry releaseEntry;
        private Boolean downloaded = false;
        private Boolean updateCheck = false;
       
        string appDirectory;
        public updateDialog()
        {

            update = Updater.update;
            releaseEntry = Updater.releaseEntry;
            // Updater. mgr = new UpdateManager(@"https://raw.githubusercontent.com/reguez/myRouterBeta/master/Releases");
            Updater.DisposeUpdateManager();
            Updater.mgr = new UpdateManager(@"https://raw.githubusercontent.com/reguez/myRouterBeta/master/Releases");
            /*

             Task.Run(async () =>
             {



                    await mgr.UpdateApp();


             }

            );
            */

            //   Updater.startUpdate();
            dispatcher = Dispatcher.CurrentDispatcher;

            //  Window1.mgr.CheckForUpdate().ContinueWith(updateCompleted);

          //  Updater.startUpdate();
              startUpdateCheck();
            InitializeComponent();
            this.Hide();

        }
        

        string getCurrentReleaseNote()
        {
            mgr = new UpdateManager(@"d:\Releases");
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            string content = File.ReadAllText(mgr.RootAppDirectory + @"\packages\RELEASES");
            ;
            List<ReleaseEntry> lists = ReleaseEntry.ParseReleaseFile(content).ToList();
            ;
foreach( var release in lists)
            {
                if (release.Version.Version == ver)
                {
                   return release.GetReleaseNotes(mgr.RootAppDirectory + @"\packages");
                }
            }
           
           

            return null;
        }
        private void startUpdateCheck()
        {
        
            

             Updater.mgr.CheckForUpdate().ContinueWith(updateCheckCompleted, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(updateCheckFailed, TaskContinuationOptions.OnlyOnFaulted);
            /*

            if (mgr == null)
            {
            //     mgr = new UpdateManager("https://raw.githubusercontent.com/reguez/cfg/master/Releases");
                mgr = new UpdateManager(@"d:\Releases");



                ;
               
            }

           
                  
          */
            /*
            mgr.CheckForUpdate().ContinueWith(_ =>
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

        private void updateCheckFailed(Task obj)
        {
            dispatcher.Invoke(new Action(() =>
            {
                status.Visibility = Visibility.Collapsed;
                checkFailed.Visibility = Visibility.Visible;
                this.Show();

            }));
        }


       
        public List<string> getFutureReleaseNote()
        {
            List<string> releases = new List<string>();
            XmlSerializer ser = new XmlSerializer(releases.GetType());
            try
            {
                var request = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/reguez/myRouterBeta/master/releaseNote.txt");
                request.Timeout = 3000;
                var response = (HttpWebResponse)request.GetResponse();


                


                // Load the object saved above by using the Deserialize function
                //releases = (List<string>)ser.Deserialize(new StreamReader(response.GetResponseStream()));

                StreamReader reader = new StreamReader(response.GetResponseStream());
                string strResponse = reader.ReadToEnd();
                string[] texts = Regex.Split(strResponse, "\n");
                foreach (string texxt in texts)
                {
                    Console.WriteLine(texxt);
                }
                

                return texts.ToList();
            }
            catch(Exception exx)
            {
                return releases;
            }
           
        }
        
        void updateCheckCompleted(Task<UpdateInfo> task)
        {



            


           
           Updater. update = task.Result;
            if (Updater.update == null)
            {
                dispatcher.Invoke(new Action(() =>
                {
                    checkFailed.Visibility = Visibility.Visible;

                }));
            }
            ;

          
            Updater. releaseEntry=Updater.update.FutureReleaseEntry;

            //check if auto update has installed the update 
            if (Updater.installed)
            {

                if (Updater.installedReleaseEntry.Filename != Updater.update.FutureReleaseEntry.Filename)
                {
                }
            }
            
            if (Updater.update.CurrentlyInstalledVersion.Filename != Updater.update.FutureReleaseEntry.Filename)
            {
              //  
                // update is available 
              
                dispatcher.Invoke(new Action(() =>
                {
                    version.Content = Updater.update.FutureReleaseEntry.Version;
                    foreach (string line in getFutureReleaseNote())
                    {
                        releases.Inlines.Add(line);
                        releases.Inlines.Add(new LineBreak());
                    }
                  
                    updateDiag.Visibility = Visibility.Visible;
                    this.Show();
                }));


            }
            else
            {
                dispatcher.Invoke(new Action(() =>
                {

                    noUpdate.Visibility = Visibility.Visible;
                    this.Show();
                }));
            }
            updateCheck = true;
           
    
        }
        private void updateFinish(Task<string> task)
        {
   
            // app
            
            appDirectory = task.Result;
            Console.WriteLine(appDirectory);
            dispatcher.Invoke(new Action(() =>
            {
                status.Visibility = Visibility.Collapsed;
                success.Visibility = Visibility.Visible;


            }));
            
        }

        
        private void runApp()
        {

           
            Process.Start(appDirectory + "/myRouter.exe");
           
         //   Application.Current.Shutdown();


        }
        
        private void applyDownload(Task task)
        {
            downloaded = true;
            //create a release not before install since installing will remove the previous version 

            var d = task;

            actionString = "Installing";
            dispatcher.Invoke(new Action(() =>
            {

                statusText.Content = actionString + " 0%";
            }));
           
            Action<int> action = new Action<int>(progress);
            
            Updater.mgr.ApplyReleases(Updater.update, action).ContinueWith(updateFinish, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(_ =>
            {
                dispatcher.Invoke(new Action(() =>
                {
                    status.Visibility = Visibility.Collapsed;
                    installFailed.Visibility = Visibility.Visible;
                    Console.WriteLine("could noy install");

                }));


            }, TaskContinuationOptions.OnlyOnFaulted);
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

        private void installApp()
        {
            actionString = "Installing";
            

                statusText.Content = actionString + " 0%";
          

            Action<int> action = new Action<int>(progress);

            /*
            mgr.ApplyReleases(update, action).ContinueWith(_ =>
            {
                dispatcher.Invoke(new Action(() =>
                {
                    status.Visibility = Visibility.Collapsed;
                    failed.Visibility = Visibility.Visible;
                    Console.WriteLine("what happen");

                }));


            }, TaskContinuationOptions.OnlyOnFaulted);
               */
         Updater. mgr.ApplyReleases(Updater.update, action).ContinueWith(updateFinish, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(_ =>
          {
              dispatcher.Invoke(new Action(() =>
              {
                  status.Visibility = Visibility.Collapsed;
                  installFailed.Visibility = Visibility.Visible;
                  Console.WriteLine("could noy install");

              }));


          }, TaskContinuationOptions.OnlyOnFaulted);


        }
        private void downloadApp()
        {
           
             actionString = "Downloading ";
            
            statusText.Content = actionString + " 0%";
            status.Visibility = Visibility.Visible;
            List<ReleaseEntry> releaseToDownload = new List<ReleaseEntry>();
            Action<int> action = new Action<int>(progress);

            releaseToDownload.Add(Updater.releaseEntry);

            //  



            Updater.mgr.DownloadReleases(releaseToDownload,action).ContinueWith(applyDownload, TaskContinuationOptions.OnlyOnRanToCompletion).ContinueWith(_ =>
            {
                dispatcher.Invoke(new Action(() =>
                {
                    status.Visibility = Visibility.Collapsed;
                    downloadFailed.Visibility = Visibility.Visible;
                  

                }));


            }, TaskContinuationOptions.OnlyOnFaulted);

            ;

        }
        private void updateButton(object sender, RoutedEventArgs e)
        {
            updateDiag.Visibility = Visibility.Collapsed;
            if (Updater.installed)
            {

            }
            if(!Updater.installed && Updater.downloaded)
            {

            }

            downloadApp();
        }
        string actionString="";
        private void progress(int i)
        {
            dispatcher.Invoke(new Action(() =>
            {

                statusText.Content = actionString + i + "%";

            }));
        }

        private void restartApp(object sender, RoutedEventArgs e)
        {
            runApp();
        }

        private void retryUpdate(object sender, RoutedEventArgs e)
        {
            if (!updateCheck)
            {
                checkFailed.Visibility = Visibility.Collapsed;
                Console.WriteLine("start upddate check");
                startUpdateCheck();
                return;
            }

            if (!downloaded)
            {
                downloadFailed.Visibility = Visibility.Collapsed;
                status.Visibility = Visibility.Visible;
                Console.WriteLine("start download");
                downloadApp();
            }
            else
            {
                installFailed.Visibility = Visibility.Collapsed;
                status.Visibility = Visibility.Visible;
                Console.WriteLine("start install");
                installApp();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
         

        }

        private void Window_Closed(object sender, EventArgs e)
        {
                
            Updater.DisposeUpdateManager();
            ;//done     
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
