using myRouter;
using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.Globalization;
using System.Windows.Threading;
using MahApps.Metro.Controls;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    /// 

    
    public partial class MainWindow   : MetroWindow

    {
        string macAdress;
        DateTime start=DateTime.Now;
        int displayed;
        int nbrRestart;
        int nbrReconnect;
        int nbrPing;
        public static int nbrUpdate;
        int nbrAbout;
        int nbrpingList;
        public static int nbrFeedback;
        public static int nbrFacebook;
        public static int nbrTwitter;

        RouterEngine engine;
        Router router;
        public Network network;
        int i = 0;
        myPing ping;
        private Boolean adslState;
        private Boolean lanState;
        private Boolean internetState;
        DateTime time;
        public static string appDirectory= System.IO.Directory.GetParent(System.IO.Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString()).ToString();
       

        public RouterEngine RouterEngine { get { return engine; } }
        public Router Router { get { return router; } }
        public Network Network { get { return network; } }


        Color green = new Color();
        Color blue = new Color();
        Color orange = new Color();


        private readonly BackgroundWorker worker = new BackgroundWorker();
        private readonly BackgroundWorker internetWorker = new BackgroundWorker();
        private readonly BackgroundWorker pingWorker = new BackgroundWorker();
        private readonly BackgroundWorker deviceSeeker = new BackgroundWorker();
        private readonly BackgroundWorker rebootWorker = new BackgroundWorker();
        private readonly BackgroundWorker routerWorker = new BackgroundWorker();
        private readonly BackgroundWorker reconnectWorker = new BackgroundWorker();
        private readonly BackgroundWorker animationWorker = new BackgroundWorker();

        System.Windows.Threading.DispatcherTimer internetTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer deviceSeekerTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer routerTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer networkTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer pingTimer = new System.Windows.Threading.DispatcherTimer();
        System.Windows.Threading.DispatcherTimer updateStatusTimer = new System.Windows.Threading.DispatcherTimer();

        private void networkTimer_Tick(object sender, EventArgs e)
        {
            

            network.UpdateNetworkInterface();
            Console.WriteLine("network" + network.Download);

        }
      

        private void internetTimer_Tick(object sender, EventArgs e)
        {
            // checking for internet 
           
            internetWorker.RunWorkerAsync();
            internetTimer.Stop();
        }

        private void routerTimer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("updating");
           
           Console.WriteLine( routerWorker.IsBusy);
            if (!routerWorker.IsBusy)
            {
                
                routerTimer.Stop();
                routerWorker.RunWorkerAsync();
            }
          //  routerWorker.RunWorkerAsync();
            
           

            /*

            try
            {
                Console.WriteLine("tik tok");
                engine.updateStatus();

                //  Boolean currentLanState = true;

                if (!lanState)
                {
                    changeLanColor(blue);
                    lanState = true;
                }
                
                   
                
                Boolean currentState = router.checkAdslState();
                if (currentState != adslState)
                {
                    if (currentState) { 
                        changeAdslColor(green);
                        Boolean internetCurrentState = router.checkInternetStat();
                        if (internetCurrentState != internetState)
                        {
                            if (internetCurrentState)
                            {
                                changeInternetColor(green);
                            }
                            else
                            {
                                changeInternetColor(Colors.Red);
                            }
                            internetState = internetCurrentState;
                        }
                    
                    }
                    else
                    {
                        // if adsl down we dont need to check for internet 
                        //    internetTimer.Stop();
                        changeAdslColor(Colors.Red);
                        changeInternetColor(Colors.Red);
                        router.Internet = "0.0.0.0";

                    }
                    adslState = currentState;
                }
               

            }

            catch (WebException ex)
            {


                Console.WriteLine("error error error error ");
                routerTimer.Stop();
                //internetTimer.Stop();
                // pingTimer.Stop();
                // networkTimer.Stop();
                showNoConnection();
                router.Status = "connection down";
                router.DownStream = 0;
                router.UpStream = 0;
                router.Modulation = "---";
                lanState = false;
                internetState = false;
                adslState = false;
                router.Internet = "0.0.0.0";
                changeLanColor(Colors.Red);
                changeAdslColor(orange);
                changeInternetColor(orange);
                //internetWorker.CancelAsync();
                time = DateTime.Now;
                worker.RunWorkerAsync();
                pingWorker.CancelAsync();
                pingTimer.Stop();
               

            }
            */
       

        }

       
        public void updateStatus()
        {
            router.checkAdslState();
            network.checkInternetState();
        }
        Dispatcher dispatcher;
        public MainWindow()
        {

             dispatcher = Dispatcher.CurrentDispatcher;
            deviceSeeker.DoWork += deviceSeeker_DoWork;
            deviceSeeker.RunWorkerCompleted += deviceSeeker_RunWorkerCompleted;
            InitializeComponent();
            //  green = Color.FromRgb(0, 184, 0);
            // blue = Color.FromRgb(41, 175, 255);
            // orange = Color.FromRgb(241,183,97);
            //remove after test :::!!!!!!!!!!!!!!!!!!
           

            ///remove after test 
            green = Colors.Green;
            blue = Color.FromRgb(0, 70, 255);
            orange = Colors.Orange;
            /*
            router = new Router();
            router.Status="internet is up";
            router.Modulation = "g.dmt";
            router.UpStream = 1024;
            router.Ip = "192.168.1.1";
            changeAdslColor(green);
            changeInternetColor(green);
            changeLanColor(blue);
            router.DownStream = 1000;
            router.Internet = "41.121.236";
          network = new Network();
            myPing my = new myPing();
            my.Ip = "42.123.524";
            my.Value = "20 ms";
            my.Country = "Tunisia";
            network.InterfaceName = "Wireless";
            network.Ping = my;
            network.Download = "800 kb/s";
            network.Upload = "25 kb/s";
            */

            
            if (!File.Exists(appDirectory + "/router.mtlc"))
            {
                Startup startup = new Startup();
                startup.Show();
                this.Close();
                return;
            }
            
            InitializeRouter();
            initializeNetwork();
            deviceSeeker.RunWorkerAsync();
          
            try { engine.executeRequest("authentication"); }
            catch (Exception ex)
            {
                Startup start = new Startup();
                start.Show();
                this.Close();
                return;
            }

            
            if (!router.ReconnectSupport)
            {
                reconnect.Opacity = 0.5;
                reconnect.IsEnabled = false;
            }
          
          initializePing();

            routerWorker.DoWork += routerWorker_DoWork;
            routerWorker.RunWorkerCompleted += routerWorker_RunWorkerCompleted;
            routerWorker.WorkerReportsProgress = true;
            routerWorker.ProgressChanged += routerWorker_ProgressChanged;

            routerTimer.Tick += new EventHandler(routerTimer_Tick);
            routerTimer.Interval = TimeSpan.FromSeconds(8);
           /// routerTimer.Start();

            animationWorker.DoWork += animationWorker_DoWork;
            animationWorker.RunWorkerCompleted += ranimationWorker_RunWorkerCompleted;
            animationWorker.WorkerReportsProgress = true;
            animationWorker.ProgressChanged += animationWorker_ProgressChanged;

            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            deviceSeekerTimer.Tick += new EventHandler(deviceSeekerTimer_Tick);
            deviceSeekerTimer.Interval = TimeSpan.FromSeconds(10);
            //deviceSeekerTimer.Start();
            networkTimer.Tick += new EventHandler(networkTimer_Tick);
            networkTimer.Interval = TimeSpan.FromSeconds(1);
            //  network.InternetIp = network.getIp();
            // network.getAliveHost("192.168.1.1","192.168.1.254");
            networkTimer.Start();
            rebootWorker.DoWork += rebootWorker_DoWork;
            rebootWorker.RunWorkerCompleted += rebootWorker_RunWorkerCompleted;
            rebootWorker.WorkerReportsProgress = true;
            rebootWorker.ProgressChanged += rebootWorker_ProgressChanged;
            reconnectWorker.DoWork += reconnectWorker_DoWork;
            reconnectWorker.RunWorkerCompleted += reconnectWorker_RunWorkerCompleted;
            reconnectWorker.WorkerReportsProgress = true;
            reconnectWorker.ProgressChanged += reconnectWorker_ProgressChanged;
            
            
           
       
           
              routerTimer.Tick += new EventHandler(routerTimer_Tick);
              routerTimer.Interval = TimeSpan.FromSeconds(2);
            
           routerTimer.Start();

            //makeXml();
            /*
             
             routerTimer.Tick += new EventHandler(routerTimer_Tick);
             routerTimer.Interval = TimeSpan.FromSeconds(3);
              routerTimer.Start();
             internetTimer.Tick += new EventHandler(internetTimer_Tick);
             internetTimer.Interval = TimeSpan.FromSeconds(8);
            
             worker.DoWork += worker_DoWork;
             worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            

             internetWorker.DoWork += internetWorker_DoWork;
             internetWorker.WorkerSupportsCancellation = true;
             internetWorker.RunWorkerCompleted += internetWorker_RunWorkerCompleted;
             internetWorker.RunWorkerAsync();
             //  internetTimer.Start();

             // initializePing();

             */
            this.DataContext = this;

        }

        private void routerWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
          
        }

        private void routerWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dispatcher.Invoke(new Action(() =>
            {
                routerTimer.Start();

            }));
        }

        private void routerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("updating");
          

               
                        try
                        {
                            Console.WriteLine("tik tok");
                            engine.updateStatus();

                            //  Boolean currentLanState = true;

                            if (!lanState)
                            {
                    dispatcher.Invoke(new Action(() =>
                    {
                        changeLanColor(blue);

                    }));
                   
                                lanState = true;
                            }



                            Boolean currentState = router.checkAdslState();
                            if (currentState != adslState)
                            {
                                if (currentState)
                                {
                        dispatcher.Invoke(new Action(() =>
                        {
                            changeAdslColor(green);

                        }));
                        
                                    Boolean internetCurrentState = router.checkInternetStat();
                                    if (internetCurrentState != internetState)
                                    {
                                        if (internetCurrentState)
                                        {
                                dispatcher.Invoke(new Action(() =>
                                {
                                    changeInternetColor(green);

                                }));
                               
                                        }
                                        else
                                        {
                                dispatcher.Invoke(new Action(() =>
                                {
                                    changeInternetColor(Colors.Red);

                                }));
                               
                                        }
                                        internetState = internetCurrentState;
                                    }

                                }
                                else
                                {
                        // if adsl down we dont need to check for internet 
                        //    internetTimer.Stop();
                        dispatcher.Invoke(new Action(() =>
                        {
                            changeAdslColor(Colors.Red);
                            changeInternetColor(Colors.Red);

                        }));
                       
                                    router.Internet = "0.0.0.0";

                                }
                                adslState = currentState;
                            }


                        }

                        catch (WebException ex)
                        {


                            Console.WriteLine("error error error error ");
                dispatcher.Invoke(new Action(() =>
                {
                    showNoConnection();
                    router.Status = "connection down";
                    router.DownStream = 0;
                    router.UpStream = 0;
                    router.Modulation = "---";
                    lanState = false;
                    internetState = false;
                    adslState = false;
                    router.Internet = "0.0.0.0";
                    changeLanColor(Colors.Red);
                    changeAdslColor(orange);
                    changeInternetColor(orange);
                    //internetWorker.CancelAsync();
                    time = DateTime.Now;
                    worker.RunWorkerAsync();
                    pingWorker.CancelAsync();
                    pingTimer.Stop();
                    routerTimer.Stop();
                }));
              
                            //internetTimer.Stop();
                            // pingTimer.Stop();
                            // networkTimer.Stop();
                           


                        }
                        
        }
        private void Button_ToolTipOpening(object sender, ToolTipEventArgs e)
        {
            // ... Set ToolTip on Button before it is shown.
            Button b = sender as Button;
            if (!b.IsEnabled)
            {
                b.ToolTip = "this feature will be  available soon ";
            }
           
        }
        private void reconnectWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 10)
            {
                router.Status = "disconnecting";
            }

            if (e.ProgressPercentage == 20)
            {
                router.Status = "disconnected";
            }

            if (e.ProgressPercentage == 30)
            {
                router.Status = "connecting";
            }

            if (e.ProgressPercentage == 40)
            {
                router.Status = "connected";
            }


        }

        private void reconnectWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void reconnectWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            reconnectWorker.ReportProgress(10); //disconnecting
           Boolean InternetCheck = false;
            Boolean dead = false;

            //
            Console.WriteLine("Checking connectivity");
            // disconnect
            while ( !InternetCheck || !dead)
            {
                try
                {
                    try
                    {
                        engine.updateStatus();
                    }
                    catch (Exception ex)
                    {

                    }
                    
                    if (!dead)
                    {
                        if (router.checkInternetStat())
                        {
                            reconnectWorker.ReportProgress(20);
                            dead = true;
                            Thread.Sleep(2000);
                            reconnectWorker.ReportProgress(30);

                            //connect  
                        }


                    }
                  
                    if (dead&&!InternetCheck)
                    {
                        if (router.checkInternetStat())
                        {
                            InternetCheck = true;
                            reconnectWorker.ReportProgress(40);
                        }
                    }
                       
                       

                    }
                
                catch (Exception ex)
                {
                    Console.WriteLine("sleeping ");
                    Thread.Sleep(2000);
                }

            }
            //internetWorker.CancelAsync();
            // worker.RunWorkerAsync();


        }

        private void animationWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(2000);
            animationWorker.ReportProgress(5);
            Thread.Sleep(1000);
            animationWorker.ReportProgress(10);
            Thread.Sleep(6000);
            animationWorker.ReportProgress(20);
            Thread.Sleep(6000);
            animationWorker.ReportProgress(30);
        }
        private void animationWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 5)
            {
                changeLanColor(blue);
                changeAdslColor(orange);
                changeInternetColor(orange);
                
            }
            if (e.ProgressPercentage == 10)
            {
                adslStoryBoard = new Storyboard();
                adslEffect.Color=Colors.Gray;
                flickAdsl(green);
               
                changeInternetColor(Colors.Red);
            }
            if (e.ProgressPercentage == 20)
            {
                 adslStoryBoard = new Storyboard();
                changeAdslColor(green);
                internetStoryBoard = new Storyboard();
                internetEffect.Color = Colors.Gray;
               // Adsl(Colors.Gray, Colors.Green);
             //   flickInternet(Colors.Gray,green);
            }
            if (e.ProgressPercentage == 30)
            {
                internetStoryBoard = new Storyboard();
                changeInternetColor(green);
            }
        }

        private void ranimationWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           
        }

        

        private void deviceSeekerTimer_Tick(object sender, EventArgs e)
        {
            deviceSeekerTimer.Stop();
            deviceSeeker.RunWorkerAsync();
        }

        void initializeNetwork()
        {

            network = new Network();
            network.initialiseNetworkInterface(router.Ip);

         
            //deviceSeeker.RunWorkerAsync();

        }

        void initializePing()
        {
            network.initilializePingList();

            pingWorker.DoWork += pingWorker_DoWork;
            pingWorker.RunWorkerCompleted += pingWorker_RunWorkerCompleted;
            pingWorker.WorkerSupportsCancellation = true;
            pingWorker.RunWorkerAsync();
           /* pingTimer.Tick += new EventHandler(pingTimer_Tick);
            pingTimer.Interval = TimeSpan.FromSeconds(1);
            pingTimerRunning = true;
            pingTimer.Start();
            */
        }


        private void deviceSeeker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("started");
            deviceSeekerTimer.Stop();
            network.getAliveHost("192.168.1.1", "192.168.1.254");
        }

        private void deviceSeeker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("done devices" + network.ConnectedDevices);
            deviceSeekerTimer.Start();
        }



        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean end = false;

            while (end == false)
            {
                Thread.Sleep(8000);
                end = engine.checkAlive();

                TcpClient TcpScan = new TcpClient();

                try

                {

                    // Try to connect 

                    TcpScan.Connect("192.168.1.1", 80);

                    // If there's no exception, we can say the port is open 

                    Console.WriteLine("Port " + 80 + " open");

                }

                catch

                {

                    // An exception occured, thus the port is probably closed 

                    Console.WriteLine("Port " + "192.168.1.1" + " closed");

                }

         double current=  DateTime.Now.Subtract(time).TotalSeconds ;
                if (current > 10)
                {
                    Startup start = new Startup();
                    this.Close();
                    start.Show();

                  
                }
                if (end == true)
                {
                    
                    return;
                   
                }

            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            changeLanColor(blue);
            changeAdslColor(orange);
            changeInternetColor(orange);
            hideNoConnection();
            routerTimer_Tick(sender,e);
            routerTimer.Start();
            
            
          
           
            //internetWorker.CancelAsync();
           
            //  networkTimer.Start();
            //   pingTimer.Start();
            //   internetWorker.RunWorkerAsync();
            //   internetTimer.Start();

        }


        private void rebootWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Boolean end = false;
            Boolean pingCheck = false;
            Boolean dead = false;
            Boolean aliveCheck = false;
            Boolean adslCheck = false;
            Boolean InternetCheck = false;
    //        rebootWorker.ReportProgress(20);
            Console.WriteLine("started reboot");
            Thread.Sleep(8000);
            Ping ping = new Ping();

            rebootWorker.ReportProgress(5);//rebooting 
            while (!dead)
            {
                PingReply reply;
                try
                {
                    reply = ping.Send(router.Ip, 1000);
                    if (reply.Status == IPStatus.Success)
                    {
                        dead = false;
                      
                       
                    }
                    else
                    {
                        dead = true;
                    }
                }
                catch (System.Net.NetworkInformation.PingException ex)
                {
                    dead = true; ;
                }
            }
            Thread.Sleep(1000);
            rebootWorker.ReportProgress(10);
            Thread.Sleep(1000);
            rebootWorker.ReportProgress(12);
            //whaiting for router to connect
            while (!pingCheck)
            {
                PingReply reply;
                try
                {
                    reply = ping.Send(router.Ip, 100);
                    if (reply.Status == IPStatus.Success)
                    {
                        pingCheck = true;
                        router.Status = "";
                        Console.WriteLine("ping success");
                        
                    }
                }
                catch(Exception ex)
                {
                    pingCheck = false;
                }
             
               
            }
            rebootWorker.ReportProgress(25);
            Thread.Sleep(1000);
            rebootWorker.ReportProgress(27);
            Thread.Sleep(1000);
            // router is connected to network
            // waiting for router http server 
            while (!aliveCheck)
            {
                try
                {
                    aliveCheck = engine.checkAlive();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("hllo");
                    Thread.Sleep(2000);
                }
            }


            rebootWorker.ReportProgress(28);
            Console.WriteLine("Checking connectivity");
            while(!adslCheck || !InternetCheck)
            {
                try
                {
                    try
                    {
                        engine.updateStatus();
                    }
                    catch(Exception ex)
                    {

                    }

                    if (!adslCheck&&router.checkAdslState())
                    {
                        rebootWorker.ReportProgress(30);
                        adslCheck = true;
                        Console.WriteLine("Adsl is on");
                        Thread.Sleep(1000);
                        rebootWorker.ReportProgress(32);
                        Thread.Sleep(1000);
                    }

                    if (adslCheck)
                    {
                       
                        if (network.checkInternetState())
                        {
                            InternetCheck = true;
                            rebootWorker.ReportProgress(40);
                            Console.WriteLine("Internet is on");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine("sleeping ");
                    Thread.Sleep(2000);
                }

            }
            return;
          





        }


       private void rebootWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 28)
            {

                router.Status = "checking connectivity ";
                
            }

            if (e.ProgressPercentage == 25)
            {
               
                router.Status = "Router is connected to network ";
                lanStoryBoard = new Storyboard();
                changeLanColor(Colors.Blue);
                adslStoryBoard = new Storyboard();
                adslStoryBoard.Completed += delegate
                {
                    adslStoryBoard = new Storyboard();
                    adslEffect.Color = Colors.Gray;
                    flickAdsl(Colors.Green);
                };
                changeAdslColor(Colors.Gray);

            }
            if (e.ProgressPercentage == 27)
            {

               
                router.Status = "waiting for router http server";
            }
            if (e.ProgressPercentage == 10)
            {
                router.Status = "Router is down";
                lanStoryBoard = new Storyboard();
                lanStoryBoard.Completed += delegate
                {
                    lanStoryBoard = new Storyboard();
                    routerEffect.Color = Colors.Gray;
                    flickLan(Colors.Blue);
                };
                changeLanColor(Colors.Gray);

               
            }

            if (e.ProgressPercentage == 12)
            {
               
                router.Status = "waiting for router to connect";
            }

            if (e.ProgressPercentage == 5)
            {
                router.Status = "Rebooting ...";
            }

            if (e.ProgressPercentage == 20)
            {
                changeLanColor(blue);
                //changeAdslColor(orange);
               // changeInternetColor(orange);
               // flickAdsl(Colors.Green);
            }
            if (e.ProgressPercentage == 30)
            {
                //         stopAdslAnimation();

                adslStoryBoard = new Storyboard();
                changeAdslColor(green);

                router.Status = "Adsl is ON";
                internetStoryBoard = new Storyboard();
                internetStoryBoard.Completed += delegate
                {
                    internetStoryBoard = new Storyboard();
                    internetEffect.Color = Colors.Gray;
                    flickInternet(Colors.Green);
                };
                changeInternetColor(Colors.Gray);
                //   flickInternet(Colors.Green);
            }

            if (e.ProgressPercentage == 32)
            {
                //         stopAdslAnimation();
                // changeAdslColor(green);

                
                router.Status = "waiting for internet";
                //   flickInternet(Colors.Green);
            }
            if (e.ProgressPercentage == 40)
            {

               //stopInternetAnimation();
                router.Status = "Internet is ON";
                Thread.Sleep(1000);
                router.Status = "successful Reboot";
                internetStoryBoard = new Storyboard();
                changeInternetColor(green);
                Thread.Sleep(1000);
            }
        }
        private void rebootWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            Console.WriteLine("done reboot");
           

        }

        private void internetWorker_DoWork(object sender, DoWorkEventArgs e)
        {



            Console.WriteLine("internet worker");

           
                network.checkInternetState();


            Console.WriteLine("internet ip " + network.InternetIp);
              
            
                
              

            
        }

        private void internetWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (network.InternetIp.Equals("0.0.0.0"))
            {
             
                
                    changeInternetColor(Colors.Red);
               
            }
            else
            {
                changeInternetColor(blue);
            }
          //  internetTimer.Start();
            Console.WriteLine("internet worker done");
        }

        public void makeXml()
        {
            Router router = new Router();
            router.Ip = "192.168.1.5";

            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Router));

            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter(@"d:\routerouss.xml");
            SerializerObj.Serialize(WriteFileStream, router);

            // Cleanup
            WriteFileStream.Close();


        }

        public void InitializeRouter()
        {
            /*
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Router));
            FileStream ReadFileStream = new FileStream(@appDirectory+"/router.xml", FileMode.Open, FileAccess.Read, FileShare.Read);

            // Load the object saved above by using the Deserialize function
            router = (Router)SerializerObj.Deserialize(ReadFileStream);
            encryptRouter(router);
            */
            ;
            router=createRouter(decryptRouter());
            //  router.Mac = "sdfsdfdsfdssdfdsf";

         //   router.Mac = "F8:8E:85:A5:65:D2";
           //    encryptRouter(router);

            ;
       //    encryptRouter(router);
            ;
            engine = new RouterEngine(router);

           




            //  engine.updateStatus();



            // Cleanup
            //ReadFileStream.Close();
        }

       

        private void pingTimer_Tick(object sender, EventArgs e)
        {
            pingWorker.RunWorkerAsync();

        }

        private void updateStatus_Tick(object sender, EventArgs e)
        {
            router.checkAdslState();
            Console.WriteLine("dsfdsfs");
        }
        Boolean pingTimerRunning = false;
        private void showNoConnection()
        {
            BlurEffect effect = new BlurEffect();
            effect.Radius = 10;
            pingBorder.Effect = effect;
            connectionLost.Visibility = Visibility.Visible;

        }
        private void hideNoConnection()
        {
            BlurEffect effect = new BlurEffect();
            effect.Radius = 0;
            pingBorder.Effect = effect;
            connectionLost.Visibility = Visibility.Collapsed;

        }
        public static Boolean pause= false;
        private void pingWorker_DoWork(object sender, DoWorkEventArgs e)
        {
           
            Console.WriteLine("hello it's me");
            while (true)
            {

                Thread.Sleep(1000);
                if(internetState)
            {
                    
                        if (network.Pings[i].Active)
                        {
                        if (!pause)
                        {
                            network.pingHost(i);

                        }
                        else
                        {
                            network.Ping = network.Pings[i];
                        }
                        }
                    
                   
                    i++;

                    if (i == Network.pings.Count)
                {
                    i = 0;
                }

            }
                else
                {
                    Thread.Sleep(2000);
                }
                
            }




            //PingHost(pings[i]);
        }

        private void pingWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("ping worker completed");

          
            
           
        }



        Storyboard adslStoryBoard = new Storyboard();
        Storyboard lanStoryBoard = new Storyboard();
        Storyboard RouterStoryBoard = new Storyboard();
        Storyboard internetStoryBoard = new Storyboard();
        Storyboard textStoryBoard = new Storyboard();
        private void changeAdslColor(Color color)
        {
            if (adslEffect.Color != color)
            {
                adslStoryBoard.Children.Clear();

                ColorAnimation ca2 = new ColorAnimation(adslEffect.Color, color, new Duration(TimeSpan.FromMilliseconds(500)));
                adslStoryBoard.Children.Add(ca2);
                Storyboard.SetTarget(ca2, imgAdsl);
                Storyboard.SetTargetProperty(ca2, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
                adslStoryBoard.Begin();
            }
            
        }
        private void changeInternetColor(Color color)
        {
            if (internetEffect.Color != color)
            {
                internetStoryBoard.Children.Clear();
                ColorAnimation ca2 = new ColorAnimation(internetEffect.Color, color, new Duration(TimeSpan.FromMilliseconds(500)));
                internetStoryBoard.Children.Add(ca2);
                Storyboard.SetTarget(ca2, imgInternet);
                Storyboard.SetTargetProperty(ca2, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
                internetStoryBoard.Begin();
            }
           
        }
        private void changeLanColor(Color color)
        {
            if (routerEffect.Color != color)
            {
                lanStoryBoard.Children.Clear();
                ColorAnimation ca2 = new ColorAnimation(routerEffect.Color, color, new Duration(TimeSpan.FromMilliseconds(500)));
                lanStoryBoard.Children.Add(ca2);
                Storyboard.SetTarget(ca2, imgRouter);
                Storyboard.SetTargetProperty(ca2, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
                lanStoryBoard.Begin();
            }
            
        }
        private void change(Color color)
        {

         //   Object TT = test.getColor();

                lanStoryBoard.Children.Clear();
                ColorAnimation ca2 = new ColorAnimation(routerEffect.Color, color, new Duration(TimeSpan.FromMilliseconds(500)));
                lanStoryBoard.Children.Add(ca2);
             //   Storyboard.SetTarget(ca2, tt);
                Storyboard.SetTargetProperty(ca2, new PropertyPath("SolidColorBrush.Color"));
           
                lanStoryBoard.Begin();
            

        }
        private void flickAdsl(Color color )
        {
            adslStoryBoard.Children.Clear();
           // Color oldColor = adslEffect.Color;
            ColorAnimation ca = new ColorAnimation(Colors.Gray, color, new Duration(TimeSpan.FromMilliseconds(500)));
            ColorAnimation ca2 = new ColorAnimation(color, Colors.Gray, new Duration(TimeSpan.FromMilliseconds(500)));

            adslStoryBoard.Children.Add(ca);
            adslStoryBoard.Children.Add(ca2);
            ca.BeginTime = TimeSpan.FromMilliseconds(500);
            ca2.BeginTime = TimeSpan.FromMilliseconds(1500);
            Storyboard.SetTarget(ca, imgAdsl);
            Storyboard.SetTargetProperty(ca, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
            Storyboard.SetTarget(ca2, imgAdsl);
            Storyboard.SetTargetProperty(ca2, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
            adslStoryBoard.RepeatBehavior = RepeatBehavior.Forever;

            adslStoryBoard.Begin();
        }
        private void flickInternet(Color color)
        {
            internetStoryBoard.Children.Clear();
            Color oldColor = internetEffect.Color;
            ColorAnimation ca = new ColorAnimation(Colors.Gray, color, new Duration(TimeSpan.FromMilliseconds(500)));
            ColorAnimation ca2 = new ColorAnimation(color, Colors.Gray,new Duration(TimeSpan.FromMilliseconds(500)));
            internetStoryBoard.Children.Add(ca);
            internetStoryBoard.Children.Add(ca2);
            ca.BeginTime = TimeSpan.FromMilliseconds(500);
            ca2.BeginTime = TimeSpan.FromMilliseconds(1500);
            Storyboard.SetTarget(ca, imgInternet);
            Storyboard.SetTargetProperty(ca, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
            Storyboard.SetTarget(ca2, imgInternet);
            Storyboard.SetTargetProperty(ca2, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
            internetStoryBoard.RepeatBehavior = RepeatBehavior.Forever;

            internetStoryBoard.Begin();


        }
        private void flickLan(Color color)
        {
            lanStoryBoard.Children.Clear();
            Color oldColor=routerEffect.Color;
            ColorAnimation ca = new ColorAnimation(oldColor, color, new Duration(TimeSpan.FromMilliseconds(1000)));
            ColorAnimation ca2 = new ColorAnimation(color, oldColor, new Duration(TimeSpan.FromMilliseconds(1000)));
            lanStoryBoard.SetValue(Storyboard.TargetNameProperty, "imgRouter");
            ca.BeginTime = TimeSpan.FromMilliseconds(500);
            ca2.BeginTime = TimeSpan.FromMilliseconds(1500);
            Storyboard.SetTarget(ca, imgRouter);
            Storyboard.SetTargetProperty(ca, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));
            Storyboard.SetTarget(ca2, imgRouter);
            Storyboard.SetTargetProperty(ca2, new PropertyPath("(Ellipse.Stroke).(SolidColorBrush.Color)"));

            lanStoryBoard.RepeatBehavior = RepeatBehavior.Forever;
            lanStoryBoard.Children.Add(ca);
            lanStoryBoard.Children.Add(ca2);
            lanStoryBoard.Begin();
        }
        private void stopAdslAnimation()
        {
            adslStoryBoard.Stop();
        }
        private void stopInternetAnimation()
        {
            internetStoryBoard.Stop();
        }
        private void stopLanAnimation()
        {
            lanStoryBoard.Stop();
        }

        private void button_Click_2(object sender, RoutedEventArgs e)
        {

            network.Download = "dsfsf";
            Console.WriteLine("network" + network.Download);
            /*
                        dispatcherTimer.Stop();
                        engine.executeRequest("reboot");
                        router.Status = "modem rebooting";
                        router.Modulation = "---";
                        router.DownStream = 0;
                        router.UpStream = 0;
                        worker.RunWorkerAsync();
            */
            Console.WriteLine("network" + network.InterfaceName);
        }
        public void method1(int i) {
            Console.WriteLine(i);
        }
        private void continu(Task<UpdateInfo> task)
        {
            
            if (task != null)
            {
           
                
                update = task.Result;
                if (update == null)
                {
                  
                }
                else
                {
                    ReleaseEntry futre = update.FutureReleaseEntry;
                    ReleaseEntry now = update.CurrentlyInstalledVersion;

                    if (now.Filename != futre.Filename)
                    {
                        List<ReleaseEntry> list = new List<ReleaseEntry>();

                        list.Add(futre);
                        Action<int> action = new Action<int>(method1);


                        Task.Run(async () =>
                        {



                            await mgr.DownloadReleases(list, action).ContinueWith(afterDownload);
                        }

         );
                    }
                   
                   
                    //   mgr.DownloadReleases(list);
                    // Dictionary<ReleaseEntry, string> dic = update.FetchReleaseNotes();
                    int i = 0;

                  
                    //mgr.DownloadReleases()
                }
                
            }
            else
            {
                
            }
             
           
            
        }
        private void afterDownload(Task task)
        {
            Console.WriteLine("after download");
            mgr.ApplyReleases(update);
          //  mgr.
            Console.WriteLine("done after download");
        }
       public static UpdateManager mgr;
        UpdateInfo update;
        private void button_Click(object sender, RoutedEventArgs e)
        {

            changeAdslColor(Colors.Red);
            changeInternetColor(green);



        }

        
        private void status(string type)
        {
            if (type.Equals("connectionLost"))
            {
                router.Status = "connection lost";
                router.UpStream = 0;
                router.DownStream = 0;
                router.Modulation = "---";
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //datausage
            nbrRestart++;
            //datausage


            /// 

            /*
            routerTimer.Stop();
            internetTimer.Stop();
            internetWorker.CancelAsync();
          
           
            router.Status = "modem rebooting";
            router.Modulation = "---";
            router.DownStream = 0;
            router.UpStream = 0;
            network.InternetIp = "0.0.0.0";
            engine.executeRequest("reboot");

            changeAdslColor(Colors.Red);
            changeInternetColor(Colors.Red);
            changeLanColor(Colors.Red);
            rebootWorker.RunWorkerAsync();
            */

            //  change(Colors. Green);

            // routerTimer.Stop();
            showNoConnection();
            router.Status = "modem rebooting";
            router.Modulation = "---";
            router.DownStream = 0;
            router.UpStream = 0;
           router.Internet = "0.0.0.0";
            //  engine.executeRequest("reboot");
            adslStoryBoard = new Storyboard();
            changeAdslColor(Colors.Red);
          changeInternetColor(Colors.Red);
            changeLanColor(Colors.Red);
               animationWorker.RunWorkerAsync();
            //rebootWorker.RunWorkerAsync();

        }

        private void openSettings(object sender, RoutedEventArgs e)
        {
            PingSettings form = new PingSettings();
            pause = true;
          //  pingWorker.CancelAsync();
            form.Show();

            //datatusage
            nbrPing++;
            //datausage
        }

        private void about_click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.Show();
            //datausage
            nbrAbout++;
            //datausage
        }


        private void Window_StateChanged(object sender, EventArgs e)
        {
            if ((sender as Window).WindowState == System.Windows.WindowState.Normal)
            {
                Console.WriteLine("displyed");
            }
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Thread.Sleep(1000);
          //  routerTimer_Tick(sender, e);
           // deviceSeekerTimer_Tick(sender, e);
           
        }

        private void reconnect_click(object sender, RoutedEventArgs e)
        {

            
            routerWorker.RunWorkerAsync();
            /*
            showNoConnection();
            routerTimer.Stop();
            router.Status = "reconnecting";


            internetState = false;
            adslState = true;
            router.Internet = "0.0.0.0";

            changeInternetColor(Colors.Red);
            reconnectWorker.RunWorkerAsync();
            */
            //datausage
            nbrReconnect++;
            //datausage
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Begin dragging the window
            this.DragMove();
        }
        private static void encryptRouter(Router router)
        {

            XmlSerializer SerializerObj = new XmlSerializer(typeof(Router));
            MemoryStream memo = new MemoryStream();
            SerializerObj.Serialize(memo, router);

            // Cleanup
            memo.Position = 0;
            MemoryStream ms;
            try
            {


                string theKey = @"mykeyismyroutercreatedbyoussamareguezliveinhammemzriba";
                byte[] salt = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(theKey, salt);


                RijndaelManaged RMCrypto = new RijndaelManaged();

                FileStream fileStream = new FileStream(@appDirectory + "/router.mtlc", FileMode.Create);
                CryptoStream cs = new CryptoStream(fileStream,
                    RMCrypto.CreateEncryptor(pdb.GetBytes(32), pdb.GetBytes(16)),
                    CryptoStreamMode.Write);

                //

                int data;
                while ((data = memo.ReadByte()) != -1)
                {
                    cs.WriteByte((byte)data);
                }





                memo.Close();
                cs.Close();


                fileStream.Close();

                //fsCrypt.Close();
            }
            catch
            {

            }












        }
        private static CryptoStream decryptRouter()
        {
            string theKey = @"mykeyismyroutercreatedbyoussamareguezliveinhammemzriba";
            byte[] salt = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(theKey, salt);

            FileStream fsCrypt = new FileStream(@appDirectory + "/router.mtlc", FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(pdb.GetBytes(32), pdb.GetBytes(16)),
                CryptoStreamMode.Read);



            return cs;

        }
        private static Router createRouter(CryptoStream cs)

        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(Router));


            // Load the object saved above by using the Deserialize function
            Router router = (Router)SerializerObj.Deserialize(cs);

            cs.Close();
            return router;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public void sendUsage(string macAdress, DateTime start, int displayed, int restart, int reconnect, int ping, int update, int about, int pingList, int feedback, int facebook, int twitter)
        {
            string server = "www.db4free.net";
            string database = "myrouter";
            string uid = "mtlc123456789";
            string password = "mtlc789456123";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection(connectionString);
                DateTime theDate = DateTime.Now;
                theDate.ToString("yyyy-MM-dd H:mm:ss");
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO FEEDBACK (UNIQUE_ID,START,END,DISPLAYED,RESTART_BUTTON,RECONNECT_BUTTON,PING_SETTINGS_BUTTON,CHECK_UPDATE_BUTTON,ABOUT_BUTTON,PINGLIST_NUMBER,SEND_FEEDBACK_BUTTON,FACEBOOK_CLICK,TWITTER_CLICK) VALUES (?name,?start,?end,?displayed,?restart,?reconnect,?ping,?update,?about,?pingList,?feedback,?facebook,?twitter)";
                //                                                                                                                                                                                                                                              DISPLAYED,RESTART_BUTTON,RECONNECT_BUTTON,PING_SETTINGS_BUTTON,CHECK_UPDATE_BUTTON,ABOUT_BUTTON,PINGLIST_NUMBER,SEND_FEEDBACK_BUTTON,FACEBOOK_CLICK,TWITTER_CLICK

                command.Parameters.AddWithValue("?name", macAdress);
                command.Parameters.AddWithValue("?start", theDate);
                command.Parameters.AddWithValue("?end", theDate);
                command.Parameters.AddWithValue("?displayed", displayed);
                command.Parameters.AddWithValue("?restart", restart);
                command.Parameters.AddWithValue("?reconnect", reconnect);
                command.Parameters.AddWithValue("?ping", ping);
                command.Parameters.AddWithValue("?update", update);
                command.Parameters.AddWithValue("?about", about);
                command.Parameters.AddWithValue("?pingList", pingList);
                command.Parameters.AddWithValue("?feedback", feedback);
                command.Parameters.AddWithValue("?facebook", facebook);
                command.Parameters.AddWithValue("?twitter", twitter);

                connection.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
               
            }
           
        }
        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            nbrpingList = network.Pings.Count;
            //      sendUsage(macAdress, start, displayed, nbrRestart, nbrReconnect, nbrPing, nbrUpdate, nbrAbout, nbrpingList, nbrFeedback, nbrFacebook, nbrTwitter);
            Updater.DisposeUpdateManager();
            Application.Current.Shutdown();
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Updater.startUpdate();
        }
    }
}
