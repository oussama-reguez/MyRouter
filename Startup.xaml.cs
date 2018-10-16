using MahApps.Metro.Controls;
using myRouter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
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
using System.Xml.Serialization;

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    /// 
    public partial class Startup : MetroWindow
    {


        Storyboard gridStoryBoard = new Storyboard();
        Storyboard storyBoard = new Storyboard();
        RouterEngine engine;
        Router router;
        string previousIp;
        Boolean authentication;
        Boolean downloadedConfig = false;
        Boolean success = false;
        Boolean fileChanged = false;
        private Boolean listRouters = false;
        private BackgroundWorker worker = new BackgroundWorker();
        List<Router> routers = new List<Router>();
        public List<Router> Routers { get { return routers; } }
        private void Story_Completed(object sender, EventArgs e)
        {
            // Storyboard s = (Storyboard)sender;


            //e.
            //(( Storyboard) sender).t         
            //    DependencyObject target = Storyboard.GetTargetProperty(gridStoryBoard)
            // Console.WriteLine(sender.tar)
            // firstGrid.Visibility = Visibility.Collapsed;
        }
        

        public static string GetMacAddress(string ipAddress)
        {
            string macAddress = string.Empty;
            System.Diagnostics.Process pProcess = new System.Diagnostics.Process();
            pProcess.StartInfo.FileName = "arp";
            pProcess.StartInfo.Arguments = "-a " + ipAddress;
            pProcess.StartInfo.UseShellExecute = false;
            pProcess.StartInfo.RedirectStandardOutput = true;
            pProcess.StartInfo.CreateNoWindow = true;
            pProcess.Start();
            string strOutput = pProcess.StandardOutput.ReadToEnd();
            string[] substrings = strOutput.Split('-');
            if (substrings.Length >= 8)
            {
                macAddress = substrings[3].Substring(Math.Max(0, substrings[3].Length - 2))
                         + "-" + substrings[4] + "-" + substrings[5] + "-" + substrings[6]
                         + "-" + substrings[7] + "-"
                         + substrings[8].Substring(0, 2);
                return macAddress;
            }

           
                return macAddress;
            
        }
        public Startup()
        {

           
            //  gridStoryBoard.Completed += new EventHandler(Story_Completed);
            //   lanStoryBoard.Completed += new EventHandler(Story_Completed);
            /*
            if (e != null)
            {
                engine = e;
                router = e.Router;
            }
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            InitializeComponent();
            worker.RunWorkerAsync();
            */
            InitializeComponent();
            // loadRouter();
            /*
            List<Router> routers = new List<Router>();
           Router r = new Router();
            r.Ip = "sdf";
            r.BrandName="dfsfs";
            routers.Add(r);

            // lis.ItemsSource = routerss;
            //   ListBox.items
           
           // comboBox. = router;
           // comboBox.DisplayMemberPath = "Ip + BrandName ";
           */

            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += worker_ProgressChanged;
            this.DataContext = this;
            Console.WriteLine("dsfsf");



            worker.RunWorkerAsync();

        }

        public void InitializeRouter()
        {


            //  XmlSerializer SerializerObj = new XmlSerializer(typeof(Router));
            //FileStream ReadFileStream = new FileStream(@MainWindow.appDirectory+"/router.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
            router = createRouter(decryptRouter());
            // Load the object saved above by using the Deserialize function
         //   router = (Router)SerializerObj.Deserialize(ReadFileStream);
            previousIp = router.Ip;
            router.Password = "sdfs";
            engine = new RouterEngine(router);
            ;
            Console.WriteLine("requests n" + router.Requests.Count);



            


            // engine.updateStatus();



            // Cleanup
           
        }

        void saveRouter()
        {
            encryptRouter(router);
        }



        public void GetDefaultGateway()
        {

            GatewayIPAddressInformation address;
            List<NetworkInterface> cards = NetworkInterface.GetAllNetworkInterfaces().ToList();
            List<IPAddress> ipAdress = new List<IPAddress>();
            foreach (NetworkInterface card in cards)
            {
                if (card != null)
                {

                    address = card.GetIPProperties().GatewayAddresses.FirstOrDefault();
                    if (address != null)
                    {
                        if (address.Address != null)
                        {
                            ipAdress.Add(address.Address);
                            if (PingHost(address.Address.ToString()))
                            {
                                if(previousIp!= address.Address.ToString())
                                {
                                    router.Ip = address.Address.ToString();
                                    fileChanged = true;
                                }
                                
                                
                            }
                        }

                    }

                }

            }

        }




        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = new Ping();
            try
            {
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException)
            {
                // Discard PingExceptions and return false;
            }
            return pingable;
        }


        public void getListRouters()
        {

            XmlSerializer ser = new XmlSerializer(routers.GetType());

            var request = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/reguez/myRouter/master/routers/routers.xml");
            request.Timeout = 3000;
            var response = (HttpWebResponse)request.GetResponse();


            var responseString =


            // Load the object saved above by using the Deserialize function
            routers = (List<Router>)ser.Deserialize(new StreamReader(response.GetResponseStream()));
            //    comboBox.item
        }

        public Router getRouter(string brandname, string model)
        {

            Router router = null;
        //    XmlSerializer ser = new XmlSerializer(typeof(Router));

            var request = (HttpWebRequest)WebRequest.Create("https://raw.githubusercontent.com/reguez/myRouter/master/routers/" + brandname + model + ".mtlc");

            var response = (HttpWebResponse)request.GetResponse();

            var responseString =

                router = createRouter(decryptRouter(response.GetResponseStream()));
            // Load the object saved above by using the Deserialize function
           // router = (Router)ser.Deserialize(new StreamReader(response.GetResponseStream()));

            return router;
        }
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
           

            Console.WriteLine("started ");
            Console.WriteLine("start2 ");
            Console.WriteLine(MainWindow.appDirectory);
            
            if (File.Exists(MainWindow.appDirectory + "/router.mtlc"))
            {
                Console.WriteLine("initializing");
                InitializeRouter();
            }
            else
            {
                

                Console.WriteLine("started ");


                //getting a list of all routers 
                
                worker.ReportProgress(2);
                if (!listRouters)
                {
                    Random rnd = new Random();
                    int nbr = rnd.Next(1000, 2000);
                    Thread.Sleep(nbr);
                    try
                    {
                        getListRouters();
                        listRouters = true;
                    }
                    catch (WebException ex)
                    {

                        worker.ReportProgress(3);
                        Console.WriteLine(ex.Status);
                    }

                    //  finally( ex.)
                    return;
                }


                //donwloading the router configuration 

                worker.ReportProgress(4);
                if (!downloadedConfig)
                {
                    router = getRouter(router.BrandName, router.Model);
                    downloadedConfig = true;
                    fileChanged = true;
                }



                //getRouter()
                /*
                if (engine == null)
                {
                    worker.ReportProgress(5);
                    InitializeRouter();
                    Thread.Sleep(3000);
                    Console.WriteLine("router null ");
                    worker.ReportProgress(10);
                }

                */

            }

            worker.ReportProgress(10);
            Console.WriteLine("sdfsdf ");




            //   Thread.Sleep(3000);
            //if router has an ip  try to ping
           
            if ((router.Ip != null )&& ( (router.Ip!="")||(router.Ip!="0.0.0.0")))
            {
                ;
                //the router object has an ip 

                //try ping 
                ;
                if (!checkAlive())
                {
                    //router not alive 
                    ;
                    //router not alive maybe different ip ?
                    GetDefaultGateway();
                    if (!checkAlive())
                    {
                        // router is dead
                        success = false;
                        worker.ReportProgress(53);
                        return;
                    }



                }

                else
                {
                    ;
                    //router is alive 
                    //  validate mac adresse

                  string mac = Network.GetMacAddress(router.Ip);

                ;

                    if (router.Mac != null)
                    {
                        if (mac != null && !router.Mac.StartsWith("nomac") && mac != router.Mac)
                        {
                            Console.WriteLine("not identical");

                        }
                    }

                  
;
                  
                }



            }
            // we dont have an ip  let's get one
            else
            {
                ;
                GetDefaultGateway();
                if ((router.Ip != null) && ((router.Ip != "") || (router.Ip != "0.0.0.0")))
                {

                    if (!checkAlive())
                    {
                        success = false;
                        worker.ReportProgress(53);
                        return;
                    }
                    else
                    {
                        //router has an now an ip 

                        //get mac adress 
                        ;
                        // getting mac adress if avaiable
                        string mac = Network.GetMacAddress(router.Ip);
                        mac = null;
                        ;
                        if (mac != null)
                        {
                            router.Mac = mac;
                            ;
                        }
                        else
                        {
                            router.Mac = "nomac" + Guid.NewGuid().ToString("N");
                            ;
                        }
                        fileChanged = true;
                    }


                }
                
            }

          ;

            worker.ReportProgress(20);
            engine = new RouterEngine(router);
            HttpWebResponse response = null;
            try
            {
                Console.WriteLine(engine.username.Name + " " + engine.username.Value);
                Console.WriteLine(engine.password.Name + " " + engine.password.Value);
                engine.executeRequest("authentication");
              
                success = true;
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
          
                    if ((int)response.StatusCode == 401)
                    {
                        worker.ReportProgress(30);

                        authentication = true;
                        success = false;
                        return;

                    }
                    else
                    {
                        //couldnot connect
                        Console.WriteLine("dssdfsdf" + router.Ip);
                        worker.ReportProgress(40);
                        Console.WriteLine(ex.Status);
                        success = false;
                        return;
                    }
                }
                else
                {

                    //couldnot connect
                    Console.WriteLine("dssdfsdf" + router.Ip);
                    worker.ReportProgress(40);
                    Console.WriteLine(ex.Status);
                    success = false;
                    return;

                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();

                }
            }










        }
         private bool checkAlive()
        {
            Ping ping = new Ping();
            try
            {
                PingReply reply = ping.Send(router.Ip, 3000);


                if (reply == null || reply.Status != IPStatus.Success)
                {
                
                  
                    return false;
                }
                else
                {
                    TcpClient TcpScan = new TcpClient();

                    try

                    {

                        // Try to connect 

                        TcpScan.Connect(router.Ip, 80);
                        return true;

                        // If there's no exception, we can say the port is open 

                        //    success = true;

                    }

                    catch

                    {

                        // An exception occured, thus the port is probably closed 
                        worker.ReportProgress(50);

                        return false;

                    }

                }
            }

            catch (PingException ex)
            {
                return false;
            }
           
        }
      void  changeImage(string uri)
        {
        
            Storyboard sb = this.FindResource("transition") as Storyboard;
            Storyboard.SetTarget(sb, this.imgRouterr);
            sb.Begin();
        }
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (e.ProgressPercentage == 2)
            {
                Storyboard sb = this.FindResource("transition_refresh") as Storyboard;
                Storyboard.SetTarget(sb, this.imgRouterr);
                sb.Begin();
                info.Content = "Getting Routers List";
                

            }
            if (e.ProgressPercentage == 3)
            {
                info.Content = "Error getting routers list";

            }

            if (e.ProgressPercentage == 4)
            {
                Storyboard sb = this.FindResource("transition_download") as Storyboard;
                Storyboard.SetTarget(sb, this.imgRouterr);
                sb.Begin();
                info.Content = "Downloading router config";

            }
            if (e.ProgressPercentage == 10)
            {
                Storyboard sb = this.FindResource("transition_find") as Storyboard;
                Storyboard.SetTarget(sb, this.imgRouterr);
                sb.Begin();
                info.Content = "looking for router";

            }
            if (e.ProgressPercentage == 20)
            {
                Storyboard sb = this.FindResource("transition_connect") as Storyboard;
                Storyboard.SetTarget(sb, this.imgRouterr);
                sb.Begin();
                info.Content = "connecting to router";
            }
            if (e.ProgressPercentage == 30)
            {
                info.Content = "authenticating";
            }
            if (e.ProgressPercentage == 40)
            {
                info.Content = "could not  found aneey router";
                fadeIn(retry);


                // lanStoryBoard.Completed += delegate { Console.WriteLine("complited"); changeLanColor(Colors.Red); lanStoryBoard = new Storyboard(); };

            }
            if (e.ProgressPercentage == 53)
            {

                info.Content = "could not found any router check your network";

                storyBoard = new Storyboard();
                fadeIn(retry);

               /*
                lanStoryBoard.Stop();
                lanStoryBoard = new Storyboard();

                lanStoryBoard.Completed += delegate
                {
                    lanStoryBoard = new Storyboard();

                    makeShadow(10, 2, Colors.Red);
                };

                removeShadow();

            */
            }
            if (e.ProgressPercentage == 50)
            {

                info.Content = "could not  found any router";
                storyBoard = new Storyboard();
                fadeIn(retry);
                /*
                lanStoryBoard.Stop();
                lanStoryBoard = new Storyboard();

                lanStoryBoard.Completed += delegate
                {
                    lanStoryBoard = new Storyboard();

                    makeShadow(10, 2, Colors.Red);
                };

                removeShadow();

            */
            }
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            if (listRouters && !downloadedConfig)
            {
                fadeOutGrid(secondGrid);
                gridStoryBoard.Completed += delegate { gridStoryBoard = new Storyboard(); fadeInGrid(firstGrid); };
                comboBox.ItemsSource = routers;
                return;

            }
            if (authentication)
            {
                Console.WriteLine("needed  authenitcation");
                startAuthenticationAnimation();
                /*
                lanStoryBoard.Completed += delegate { Console.WriteLine("delegate"); };
                changeLanColor(Colors.Red);
                */
                // Authentification auth = new Authentification(engine);
                //auth.Show();
                // this.Hide();

            }
            if (success)
            {
                ;
                if (fileChanged)
                {
                    saveRouter();
                }
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
           // Console.WriteLine("ip"+router.Ip);
            Console.WriteLine("worker complete");

        }
        Storyboard lanStoryBoard = new Storyboard();

        private void fadeOut(Object selected)
        {
            DoubleAnimation da = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
            storyBoard.Children.Add(da);
            Storyboard.SetTarget(da, (DependencyObject)selected);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
            storyBoard.Completed += delegate { ((System.Windows.UIElement)selected).Visibility = System.Windows.Visibility.Collapsed; };
            storyBoard.Begin();
        }
        private void fadeIn(Object selected)
        {
            ((System.Windows.UIElement)selected).Visibility = System.Windows.Visibility.Visible;
            DoubleAnimation da = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
            storyBoard.Children.Add(da);
            Storyboard.SetTarget(da, (DependencyObject)selected);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));

            storyBoard.Begin();
        }



        private void startAuthenticationAnimation()

        {
            fadeOut(retry);
            fadeOut(info);
            // fadeIn(authenticationStack);

            TranslateTransform trans = new TranslateTransform();
            secondGrid.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(0, -35, TimeSpan.FromSeconds(1));
            // DoubleAnimation anim2 = new DoubleAnimation(left, newX - left, TimeSpan.FromSeconds(10));
            // trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            anim1.Completed += delegate { fadeIn(authenticationStack); };
            trans.BeginAnimation(TranslateTransform.YProperty, anim1);


        }
        private void move()
        {

            TranslateTransform trans = new TranslateTransform();
            imgRouterr.RenderTransform = trans;
            DoubleAnimation anim1 = new DoubleAnimation(0, -35, TimeSpan.FromSeconds(1));
            // DoubleAnimation anim2 = new DoubleAnimation(left, newX - left, TimeSpan.FromSeconds(10));
            // trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
        }
        private void reloadRouter(Color color)
        {
            routerEffect.Direction = 0;
            routerEffect.ShadowDepth = 0;
            routerEffect.BlurRadius = 10;
            if (routerEffect.Color != color)
            {
                lanStoryBoard.Children.Clear();
                ColorAnimation ca2 = new ColorAnimation(routerEffect.Color, color, new Duration(TimeSpan.FromMilliseconds(500)));
                lanStoryBoard.Children.Add(ca2);
                Storyboard.SetTarget(ca2, imgRouterr);
                Storyboard.SetTargetProperty(ca2, new PropertyPath("Effect.Color"));

                lanStoryBoard.Begin();
            }
        }
        private void loadRouter()
        {



            TimeSpan duration1 = TimeSpan.FromMilliseconds(2000);
            DoubleAnimation db = new DoubleAnimation(0, 360, TimeSpan.FromSeconds(2));
            //  lanStoryBoard.Children.Clear();
            lanStoryBoard.Children.Add(db);
            Storyboard.SetTarget(db, imgRouterr);
            Storyboard.SetTargetProperty(db, new PropertyPath("(Effect).Direction"));
            lanStoryBoard.RepeatBehavior = RepeatBehavior.Forever;
            lanStoryBoard.Begin();

        }
        private void makeShadow(double blurRadius,double shadowDepth,Color color)
        {
          

            TimeSpan duration1 = TimeSpan.FromMilliseconds(2000);
            DoubleAnimation db = new DoubleAnimation(routerEffect.BlurRadius,blurRadius , TimeSpan.FromMilliseconds(500));
            DoubleAnimation db2 = new DoubleAnimation(routerEffect.ShadowDepth, shadowDepth, TimeSpan.FromMilliseconds(500));
          //  DoubleAnimation db3 = new DoubleAnimation(routerEffect.Direction, 0, TimeSpan.FromMilliseconds(500));


            lanStoryBoard.Children.Clear();
            lanStoryBoard.Children.Add(db);
            lanStoryBoard.Children.Add(db2);
            ColorAnimation ca2 = new ColorAnimation(routerEffect.Color, color, new Duration(TimeSpan.FromMilliseconds(500)));
            lanStoryBoard.Children.Add(ca2);
            Storyboard.SetTarget(ca2, imgRouterr);
            Storyboard.SetTargetProperty(ca2, new PropertyPath("Effect.Color"));
            //   lanStoryBoard.Children.Add(db3);

            Storyboard.SetTarget(db, imgRouterr);
            Storyboard.SetTargetProperty(db, new PropertyPath("(Effect).BlurRadius"));
            Storyboard.SetTarget(db2, imgRouterr);
            Storyboard.SetTargetProperty(db2, new PropertyPath("(Effect).ShadowDepth"));
          //  Storyboard.SetTarget(db3, imgRouterr);
            //Storyboard.SetTargetProperty(db3, new PropertyPath("(Effect).Direction"));
            // lanStoryBoard.RepeatBehavior = RepeatBehavior.Forever;
            lanStoryBoard.Begin();
        }
        private void removeShadow()
        {

            TimeSpan duration1 = TimeSpan.FromMilliseconds(2000);
            DoubleAnimation db = new DoubleAnimation(routerEffect.BlurRadius, 0, TimeSpan.FromMilliseconds(500));
            DoubleAnimation db2 = new DoubleAnimation(routerEffect.ShadowDepth, 0, TimeSpan.FromMilliseconds(500));
            DoubleAnimation db3 = new DoubleAnimation(routerEffect.Direction, 0, TimeSpan.FromMilliseconds(500));


            lanStoryBoard.Children.Clear();
            lanStoryBoard.Children.Add(db);
            lanStoryBoard.Children.Add(db2);
            lanStoryBoard.Children.Add(db3);

            Storyboard.SetTarget(db, imgRouterr);
            Storyboard.SetTargetProperty(db, new PropertyPath("(Effect).BlurRadius"));
            Storyboard.SetTarget(db2, imgRouterr);
            Storyboard.SetTargetProperty(db2, new PropertyPath("(Effect).ShadowDepth"));
            Storyboard.SetTarget(db3, imgRouterr);
            Storyboard.SetTargetProperty(db3, new PropertyPath("(Effect).Direction"));
            // lanStoryBoard.RepeatBehavior = RepeatBehavior.Forever;
            lanStoryBoard.Begin();
        }


        private void changeLanColor(Color color)
        {


            routerEffect.Direction = 0;
            routerEffect.ShadowDepth = 0;
            routerEffect.BlurRadius = 10;
            if (routerEffect.Color != color)
            {
                lanStoryBoard.Children.Clear();
                ColorAnimation ca2 = new ColorAnimation(routerEffect.Color, color, new Duration(TimeSpan.FromMilliseconds(500)));
                lanStoryBoard.Children.Add(ca2);
                Storyboard.SetTarget(ca2, imgRouterr);
                Storyboard.SetTargetProperty(ca2, new PropertyPath("Effect.Color"));

                lanStoryBoard.Begin();
            }


        }

        private void fadeOutGrid(Object selectedGrid)
        {
            gridStoryBoard.Children.Clear();
            DoubleAnimation da = new DoubleAnimation(1, 0, TimeSpan.FromSeconds(1));
            gridStoryBoard.Children.Add(da);
            Storyboard.SetTarget(da, (DependencyObject)selectedGrid);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
            gridStoryBoard.Completed += delegate { ((System.Windows.UIElement)selectedGrid).Visibility = System.Windows.Visibility.Collapsed; Console.WriteLine("hello 1"); gridStoryBoard.Children.Clear(); };
            gridStoryBoard.Begin();
        }

        private void fadeInGrid(DependencyObject selectedGrid)
        {

            ((System.Windows.UIElement)selectedGrid).Visibility = System.Windows.Visibility.Visible;
            DoubleAnimation da = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(1));
            gridStoryBoard.Children.Add(da);
            Storyboard.SetTarget(da, selectedGrid);
            Storyboard.SetTargetProperty(da, new PropertyPath("Opacity"));
            gridStoryBoard.Begin();
        }
        //confirm
        private void button_Click(object sender, RoutedEventArgs e)
        {
            router = (Router)comboBox.SelectedItem;


            fadeOutGrid(firstGrid);
            gridStoryBoard.Completed += delegate { gridStoryBoard = new Storyboard(); fadeInGrid(secondGrid); loadRouter(); ; worker.RunWorkerAsync(); };



            // fadeInGrid(secondGrid);
            /* TranslateTransform translateTransform1 = new TranslateTransform();
             grid.RenderTransform = translateTransform1;
             DoubleAnimation anim1 = new DoubleAnimation(0, -50, TimeSpan.FromSeconds(5));
             // DoubleAnimation anim2 = new DoubleAnimation(0, newX - left, TimeSpan.FromSeconds(10));
             translateTransform1.BeginAnimation(TranslateTransform.YProperty, anim1);
            // trans.BeginAnimation(TranslateTransform.XProperty, anim2);
     */



        }

        private void retry_Click(object sender, RoutedEventArgs e)
        {
            fadeOut(retry);
            lanStoryBoard.Completed += delegate
            {
                lanStoryBoard = new Storyboard();
                lanStoryBoard.Completed += delegate { lanStoryBoard = new Storyboard(); loadRouter(); };
                makeShadow(10,2,Colors.Blue);
            };



                 removeShadow();


            worker.RunWorkerAsync();
            // fadeOutGrid(secondGrid);
            //  move();
            //startAuthenticationAnimation();

        }

        private void connect(object sender, RoutedEventArgs e)
        {
            try
            {
                engine.username.Value = txtUsername.Text;
                engine.password.Value = txtPassword.Text;
                engine.executeRequest("authentication");
                
                saveRouter();
                MainWindow main = new MainWindow();
                main.Show();
                this.Close();

                // success = true;
            }
            catch (WebException ex)
            {
                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if (ex.Status == WebExceptionStatus.ProtocolError)
                {

                    if ((int)response.StatusCode == 401)
                    {
                       

                        authentication = true;
                        error.Content = "Username or password incorrect";
                        error.Visibility = Visibility.Visible;
                        return;

                    }
                    else
                    {
                        error.Content = "Could not connect to router";
                        error.Visibility = Visibility.Visible;
                        return;
                    }
                }
                else
                {

                    error.Content = "Could not connect to router";
                    error.Visibility = Visibility.Visible;
                    return;

                }
            }
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
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

                FileStream fileStream = new FileStream(@MainWindow.appDirectory + "/router.mtlc", FileMode.Create);
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

            FileStream fsCrypt = new FileStream(@MainWindow.appDirectory + "/router.mtlc", FileMode.Open);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt,
                RMCrypto.CreateDecryptor(pdb.GetBytes(32), pdb.GetBytes(16)),
                CryptoStreamMode.Read);



            return cs;

        }


        private static CryptoStream decryptRouter(Stream stream)
        {
            

            string theKey = @"mykeyismyroutercreatedbyoussamareguezliveinhammemzriba";
            byte[] salt = new byte[] { 0x26, 0xdc, 0xff, 0x00, 0xad, 0xed, 0x7a, 0xee, 0xc5, 0xfe, 0x07, 0xaf, 0x4d, 0x08, 0x22, 0x3c };
            Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(theKey, salt);



            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(stream,
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
    }
}
