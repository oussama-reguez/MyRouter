using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace myRouter
{
    /// <summary>
    /// Interaction logic for PingSettings.xaml
    /// </summary>
    public partial class PingSettings : MetroWindow
    {
        public static bool fileChange = false;
        private int pingNbr = 0;
        Network network = new Network();
        public ObservableCollection<myPing> Pings { get { return pings; } set{  pings=value; } }
        public Network Network { get { return network; } }
        ObservableCollection<myPing> pings;
        myPing ping = new myPing();
        public PingSettings()
        {
           
            ping.Ip = "192.168.1.2";
            ping.Country = "tunisia";
            ping.Selected = false;
            ping.Active = true;

           
            pings = new ObservableCollection<myPing>();
            
            
          //  network.initilializePingList();
            pings = Network.pings;
            //pingNbr = pings.Count();
          //  pings.Add(ping);
            InitializeComponent();
            
            pingList.CurrentCellChanged += PingList_CurrentCellChanged;
            startPing();
            this.DataContext = this;
        }

        private void PingList_CurrentCellChanged(object sender, EventArgs e)
        {
            fileChange = true;
            Console.WriteLine("changed");
        }

        
        void savePingList()
        {
            #region Save the object

            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(pings.GetType());

            // Create a new file stream to write the serialized object to a file
           
            TextWriter WriteFileStream = new StreamWriter(@WpfApplication4.MainWindow.appDirectory+"/ping_list.xml");
            SerializerObj.Serialize(WriteFileStream, pings);
           
            // Cleanup
            WriteFileStream.Close();

            #endregion
        }
        private void selectAll(object sender, RoutedEventArgs e)
        {
            foreach (myPing ping in pings)
            {
                ping.Selected = true;
            }
        }

        private void deselectAll(object sender, RoutedEventArgs e)
        {
            foreach (myPing ping in pings)
            {
                ping.Selected = false;
            }
        }

        private void remove(object sender, RoutedEventArgs e)
        {
            int i = 0;
           // pingList.ItemsSource = null;
            foreach (myPing ping in pings.ToList())
            {
                i++;
                if (ping.Selected == true) {
                    pings.Remove(ping);
                    fileChange = true;
                }
                    
            }
         //   pingList.ItemsSource = pings;
        //    pings.RemoveAt(0);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            pingList.CommitEdit();
           
           // pingList.ItemsSource = null;
           foreach(var ping in pings)
            {
                Console.WriteLine(ping.Selected);
            }
            if (fileChange)
            {
                savePingList();
            }
            closed = true;
            pingList.ItemsSource = null;

            
          
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
          
        }

        private void add(object sender, RoutedEventArgs e)
        {
            //
            Window5 form = new Window5();
            WindowExtensions.ShowCenteredToMouse(form);
           // form.Show();
        }
        List<Task<PingReply>> pingTasks;
        void startPing()
        {
          pingTasks = new List<Task<PingReply>>();
            foreach (myPing ping in pings)
            {
                pingTasks.Add(PingAsync(ping));
            }



            Task.Run(async () =>
            {



                await Task.WhenAll(pingTasks.ToArray()).ContinueWith(again);



            }

        );
        }
        bool closed = false;
        public void again(Task<PingReply[]>tas)
        {
           
            Console.WriteLine("working hello");
            Thread.Sleep(2000);
            if (!closed)
            {
                startPing();
            }
           

        }
        public static string[] addresses = { "microsoft.com", "yahoo.com", "google.com" };
        static Task<PingReply> PingAsync(myPing my)
        {
            var tcs = new TaskCompletionSource<PingReply>();
            Ping ping = new Ping();
            
            ping.PingCompleted += (obj, sender) =>
            {
                tcs.SetResult(sender.Reply);
                //  Console.WriteLine(((myPing)obj).Ip);
               
                my.Value = sender.Reply.RoundtripTime.ToString();
               // myping.Value=sender.Reply.RoundtripTime.ToString();
            };
            ping.SendAsync(my.Ip, my);
            return tcs.Task;
        }
    }
}
