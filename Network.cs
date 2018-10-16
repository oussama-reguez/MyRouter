using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApplication4;

namespace myRouter

{
    public class   Network : INotifyPropertyChanged
    {
       private String speed="0";
        private String upload = "0";
        private String download = "0";
        private String  bytesSent = "0";
        private String bytesReceived = "0";
        private String interfaceName = "dfdf";
        private  static NetworkInterface nic;
        public static ObservableCollection<myPing> pings;
        private myPing ping;

        private  int connectedDevices = 0;
        private string internetIp="0.0.0.0";
        private string lanState="---";
        private string internetState="---";

        private string localIp;
        private string netMask;


        public int ConnectedDevices
        {
            get
            {

                return connectedDevices;
            }



            set
            {
                connectedDevices = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ConnectedDevices"));
            }


        }

        public String InternetState
        {
            get
            {

                return internetState;
            }



            set
            {
                internetState = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InternetState"));
            }


        }


        public ObservableCollection<myPing> Pings
        {
            get
            {

                return pings;
            }



            set
            {
                pings= value;
                
            }


        }

        public String LanState
        {
            get
            {

                return lanState;
            }



            set
            {
                lanState = value;
                OnPropertyChanged(new PropertyChangedEventArgs("LanState"));
            }


        }

        public String InternetIp
        {
            get
            {

                return internetIp;
            }



            set
            {
                internetIp = value;
                Console.WriteLine("value changed");
                OnPropertyChanged(new PropertyChangedEventArgs("InternetIp"));
            }


        }

        public static string GetMacAddress(string ipAddress)
        {
            string macAddress = null;
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

            else
            {
                return "null";
            }
        }
        public Boolean checkInternetState()
        {
            try
            {
               InternetIp= getIp();
            }
            catch (System.Net.WebException ex)
            {
                InternetIp = "0.0.0.0";
                return false;
            }

            return true;
        }

        public Boolean checkLanState(Router router)
        {
            Ping ping = new Ping();
            PingReply reply = ping.Send(router.Ip);
            if (reply.Status== IPStatus.Success)
            {
                return false;
            }
            return true;
        }



        static uint ToUInt(string ipAddress)
        {

            var ip = IPAddress.Parse(ipAddress);

            var bytes = ip.GetAddressBytes();

            Array.Reverse(bytes);

            return BitConverter.ToUInt32(bytes, 0);

        }

        static IPAddress ToIPAddress(uint ipInt)
        {

            var bytes = BitConverter.GetBytes(ipInt);

            Array.Reverse(bytes);

            return new IPAddress(bytes);

        }


       public Task<PingReply> PingAsync(string address)
        {


            var tcs = new TaskCompletionSource<PingReply>();
            Ping ping = new Ping();
            ping.PingCompleted += (obj, sender) =>
            {

                if (sender.Reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("alive host at the moment ");
                   // ConnectedDevices++;

                }

                tcs.SetResult(sender.Reply);

            };
            ping.SendAsync(address, new object());
            return tcs.Task;
        }


        public  void getAliveHost(String from, String to)
        {
//ConnectedDevices = 0;
            IPNetwork ipnetwork = IPNetwork.Parse(localIp,netMask);

           
            int count = 0;
         

            List<Task<PingReply>> pingTasks = new List<Task<PingReply>>();
            foreach (var ip in IPNetwork.ListIPAddress(ipnetwork))
            {
                pingTasks.Add(PingAsync(ip.MapToIPv4().ToString()));
              //  Console.WriteLine();

            }
           

            //Wait for all the tasks to complete
            Task.WaitAll(pingTasks.ToArray());
            int i = 0;
            //Now you can iterate over your list of pingTasks

            Console.WriteLine("coun" + pingTasks.Count);
            foreach (var pingTask in pingTasks)
            {
                //pingTask.Result is whatever type T was declared in PingAsync

                //  Console.WriteLine(pingTask.GetType);

                if (pingTask.Result.Status == IPStatus.Success)
                {
                    i++;
                }


            }

            ConnectedDevices = i;
        }

        public myPing Ping
        {
            get { return ping; }
            set
            {


                ping = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Ping"));

            }

        }

        public String Speed
        {
            get { return speed; }
            set
            {


               speed = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Speed"));

            }

        }

       

        public string getIp()
        {

          
            // myRouter.MAI
            return (new WebClient().DownloadString(@"http://icanhazip.com").Trim());
        }

        public ObservableCollection<myPing> defaultPingList()
        {
            ObservableCollection<myPing> pings = new ObservableCollection<myPing>();
            myPing ping0 = new myPing();
            ping0.Ip = "193.95.66.10";
            ping0.Country = "Tunisia";
            ping0.Active = true;
            myPing ping00 = new myPing();
            ping00.Ip = "193.95.66.10";
            ping00.Country = "Tunisia";
            ping00.Active = true;

            myPing ping000 = new myPing();
            ping000.Ip = "193.95.66.10";
            ping000.Country = "Tunisia";
            ping000.Active = true;

            myPing ping1 = new myPing();
            ping1.Ip = "176.31.147.189";
            ping1.Country = "France";
            ping1.Active = true;

            myPing ping2 = new myPing();
            ping2.Ip = "92.245.142.228";
            ping2.Country = "France";
            ping2.Active = true;


            myPing ping3 = new myPing();
            ping3.Ip = "80.11.172.1";
            ping3.Country = "France";
            ping3.Active = true;


            myPing ping4 = new myPing();
            ping4.Ip = "87.234.59.172";
            ping4.Country = "Germany";
            ping4.Active = true;


            myPing ping5 = new myPing();
            ping5.Ip = "217.91.223.105";
            ping5.Country = "Germany";
            ping5.Active = true;


            myPing ping6 = new myPing();
            ping6.Ip = "217.89.31.49";
            ping6.Country = "Germany";
            ping6.Active = true;

            myPing ping7 = new myPing();
            ping7.Ip = "80.45.150.106";
            ping7.Country = "United Kingdom";
            ping7.Active = true;
            myPing ping8 = new myPing();
            ping8.Ip = "82.109.13.100";
            ping8.Country = "United Kingdom";
            ping8.Active = true;

            myPing ping9 = new myPing();
            ping9.Ip = "213.229.125.145";
            ping9.Country = "United Kingdom";
            ping9.Active = true;

            myPing ping10 = new myPing();
            ping10.Ip = "145.131.154.245";
            ping10.Country = "Netherland";
            ping10.Active = true;

            myPing ping11 = new myPing();
            ping11.Ip = "185.42.86.5";
            ping11.Country = "Netherland";
            ping11.Active = true;

            myPing ping12 = new myPing();
            ping12.Ip = "146.185.189.61";
            ping12.Country = "Netherland";
            ping12.Active = true;

            myPing ping13 = new myPing();
            ping13.Ip = "83.238.177.210";
            ping13.Country = "Poland";
            ping13.Active = true;

            myPing ping14 = new myPing();
            ping14.Ip = "31.172.185.42";
            ping14.Country = "Poland";
            ping14.Active = true;


            myPing ping15 = new myPing();
            ping15.Ip = "194.246.106.17";
            ping15.Country = "Poland";
            ping15.Active = true;

           

            pings.Add(ping0);
            pings.Add(ping00);
            pings.Add(ping000);
            pings.Add(ping1);
            pings.Add(ping3);
            pings.Add(ping4);
            pings.Add(ping5);
            pings.Add(ping6);
            pings.Add(ping7);
            pings.Add(ping8);
            pings.Add(ping9);
            pings.Add(ping10);
            pings.Add(ping11);
            pings.Add(ping12);
            pings.Add(ping13);
            pings.Add(ping14);
            pings.Add(ping15);
           

            return pings;
        }
        public void initilializePingList()
        {
           if( !File.Exists(@MainWindow.appDirectory + "/ping_list.xml"))
            {
                //save ping list 
                pings = defaultPingList();
                // Create a new XmlSerializer instance with the type of the test class
                XmlSerializer SerializerObjj = new XmlSerializer(pings.GetType());

                // Create a new file stream to write the serialized object to a file

                TextWriter WriteFileStream = new StreamWriter(@WpfApplication4.MainWindow.appDirectory + "/ping_list.xml");
                SerializerObjj.Serialize(WriteFileStream, pings);

                // Cleanup
                WriteFileStream.Close();
            }
            else
            {
                pings = new ObservableCollection<myPing>();

                FileStream ReadFileStream = new FileStream(@MainWindow.appDirectory + "/ping_list.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                XmlSerializer SerializerObj = new XmlSerializer(pings.GetType());
                // Load the object saved above by using the Deserialize function
                pings = (ObservableCollection<myPing>)SerializerObj.Deserialize(ReadFileStream);


                ReadFileStream.Close();
            }

                                              
          
           


        }

        public void pingHost(int i)
        {
            Ping pingg = new Ping();
           Ping = pings[i];
          

            
            try
            {

                PingReply reply = pingg.Send(Ping.Ip);
                if (reply.Status == IPStatus.Success)
                {
                    
                    Ping.Value = reply.RoundtripTime.ToString();
                   // Console.WriteLine("ping Value" + ping.Value);
                }
                else
                {
                    Console.WriteLine("timeout hahi");
                    
                    Boolean found = false;
                    int k = 0;
                    while (found == false && k < pings.Count())
                    {
                        myPing thisPing = pings[k];
                        if (Ping.Country.Equals(thisPing.Country) && !Ping.Ip.Equals(thisPing.Ip))
                        {
                            found = true;
                            pingHost(k);
                           
                        }
                        k++;
                    }

                    if (k == pings.Count())
                    {

                        Ping.Value = "timeout";

                    }
                    
                    
                }



            }
            catch (PingException)
            {
                Console.WriteLine("problemo");
                Ping.Value = "timeout";
                return;
            }
           
        }



        public String Upload
        {
            get { return upload; }
            set
            {


                upload = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Upload"));

            }

        }


        public String Download
        {
            get { return download; }
            set
            {


                download = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Download"));
              

            }

        }



        public String InterfaceName
        {

            get { return interfaceName ; }
            set
            {


                interfaceName = value;
                OnPropertyChanged(new PropertyChangedEventArgs("InterfaceName"));

            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        public static IPEndPoint BestLocalEndPoint(IPEndPoint remoteIPEndPoint)
        {
            Socket testSocket = new Socket(remoteIPEndPoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
            testSocket.Connect(remoteIPEndPoint);
            return (IPEndPoint)testSocket.LocalEndPoint;
        }

        public void initialiseNetworkInterface(string RouterIp)
        {
            string serverIP = "192.168.0.1";
            long port = 80;
            long adress = IPAddress.Parse(serverIP).Address;
            IPEndPoint remoteEP = new IPEndPoint(adress, 80);
         
            NetworkInterface[] nicArr = NetworkInterface.GetAllNetworkInterfaces();
            List<NetworkInterface> goodAdapters = new List<NetworkInterface>();
            IPAddress ip = BestLocalEndPoint(remoteEP).Address;
            foreach (NetworkInterface nicnac in nicArr)
            {
                if (nicnac.SupportsMulticast && nicnac.GetIPv4Statistics().UnicastPacketsReceived >= 1 && nicnac.OperationalStatus.ToString() == "Up")
                {
                    goodAdapters.Add(nicnac);
                    //cmbInterface.Items.Add(nicnac.Name);
                }


            }
            foreach(NetworkInterface nicnac in goodAdapters)
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in nicnac.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {

                        {
                            
                            Console.WriteLine("ip mask " + unicastIPAddressInformation.Address.MapToIPv4().ToString());
                            Console.WriteLine("ip  " + unicastIPAddressInformation.IPv4Mask.ToString());
                            if (unicastIPAddressInformation.Address.MapToIPv4().ToString() == ip.MapToIPv4().ToString())
                            {
                                nic = nicnac;
                                localIp = unicastIPAddressInformation.Address.MapToIPv4().ToString();
                                netMask = unicastIPAddressInformation.IPv4Mask.ToString();
                                return;
                            }
                          



                        }
                    }
                }
            }

            
            
        }
        public void UpdateNetworkInterface()
        {
            //MessageBox.Show(cmbInterface.Items.Count.ToString());


            // Grab NetworkInterface object that describes the current interface


            // Grab the stats for that interface
           

            IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

            int bytesSentSpeed = (int)(interfaceStats.BytesSent - double.Parse(bytesSent)) / 1024;
                int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - double.Parse(bytesReceived)) / 1024;

                // Update the labels
             //   speed = nic.Speed.ToString();
             InterfaceName = nic.NetworkInterfaceType.ToString();
               // lblSpeed.Text = (nic.Speed).ToString("N0");
               bytesReceived = interfaceStats.BytesReceived.ToString("N0");
                bytesSent = interfaceStats.BytesSent.ToString("N0");
                Upload = bytesSentSpeed.ToString() + " KB/s";
                Download = bytesReceivedSpeed.ToString() + " KB/s";

                UnicastIPAddressInformationCollection ipInfo = nic.GetIPProperties().UnicastAddresses;

                foreach (UnicastIPAddressInformation item in ipInfo)
                {
                    if (item.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                       // labelIPAddress.Text = item.Address.ToString();
                        //uniCastIPInfo = item;
                        break;
                    }
                }

            
        }

        internal myPing PingHost(object p)
        {
            throw new NotImplementedException();
        }

        private bool CheckWhetherInSameNetwork(string firstIP, string subNet, string secondIP)
        {

            uint subnetmaskInInt = ConvertIPToUint(subNet);
            uint firstIPInInt = ConvertIPToUint(firstIP);
            uint secondIPInInt = ConvertIPToUint(secondIP);
            uint networkPortionofFirstIP = firstIPInInt & subnetmaskInInt;
            uint networkPortionofSecondIP = secondIPInInt & subnetmaskInInt;
            if (networkPortionofFirstIP == networkPortionofSecondIP)
            {
                return true;
            }
               
           


                return false;
        }
        public uint ConvertIPToUint(string ipAddress)
        {
            System.Net.IPAddress iPAddress = System.Net.IPAddress.Parse(ipAddress);
            byte[] byteIP = iPAddress.GetAddressBytes();
            uint ipInUint = (uint)byteIP[3] << 24;
            ipInUint += (uint)byteIP[2] << 16;
            ipInUint += (uint)byteIP[1] << 8;
            ipInUint += (uint)byteIP[0];
            return ipInUint;
        }

        public  bool PingHost(string nameOrAddress)
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

       public  String getIPv4Mask(NetworkInterface net)
        {

            foreach (UnicastIPAddressInformation unicastIPAddressInformation in net.GetIPProperties().UnicastAddresses)
            {
                if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                {


                    return unicastIPAddressInformation.IPv4Mask.ToString();

                }
            }

            return null;
        }


    }
}
