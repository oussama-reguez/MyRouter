using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace myRouter
{
    /// <summary>
    /// Interaction logic for Window5.xaml
    /// </summary>
    public partial class Window5 :MetroWindow
    {
        public Window5()
        {
            InitializeComponent();
        }


        void savePingList()
        {
            #region Save the object

            // Create a new XmlSerializer instance with the type of the test class
            XmlSerializer SerializerObj = new XmlSerializer(Network.pings.GetType());

            // Create a new file stream to write the serialized object to a file
            TextWriter WriteFileStream = new StreamWriter(@"d:\testping.xml");
            SerializerObj.Serialize(WriteFileStream, Network.pings);

            // Cleanup
            WriteFileStream.Close();

            #endregion
        }
        private string traceIp(string ip)
        {
            string key = "a73e8b6525cd881f7e650cf6926d8256d88c292f1bf0e5a000dc4faccb13da22";

            var request = (HttpWebRequest)WebRequest.Create("http://api.ipinfodb.com/v3/ip-country/?key=" + key + "&ip=" + "74.125.45.100" + "&format=xml");

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader tr = new StreamReader(response.GetResponseStream());
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
                                                    // Load the XML document from the secified file
            xmlDoc.Load(@"C:\Users\hello\Documents\er.xml");
            // Get elements
            XmlNodeList status = xmlDoc.GetElementsByTagName("loc");



            Console.WriteLine(status[0].InnerText);

            return status[0].InnerText;



        }

       
        private void addIp(object sender, RoutedEventArgs e)
        {
            if(name.Text==null || name.Text.Equals(""))
            {
                name.Text = "no name";
            }
            IPAddress address;
            if (IPAddress.TryParse(ip.Text, out address))
            {
                myPing ping = new myPing();
                ping.Name = name.Text;
                ping.Ip = ip.Text;
                ping.Active = true;
                switch (address.AddressFamily)
                {

                    case System.Net.Sockets.AddressFamily.InterNetwork:
                        try
                        {
                            
                            ping.Country = traceIp(ping.Ip);
                        }
                        catch(Exception ex)
                        {
                            ping.Country = "";
                        }
                        Network.pings.Add(ping);
                        savePingList();

                        this.Close();
                        break;
                    case System.Net.Sockets.AddressFamily.InterNetworkV6:
                        try
                        {

                            ping.Country = traceIp(ping.Ip);
                        }
                        catch (Exception ex)
                        {
                            ping.Country = "";
                        }
                        Network.pings.Add(ping);
                        PingSettings.fileChange = true;
                        
                        this.Close();
                        break;
                    default:
                        //add to
                        // umm... yeah... I'm going to need to take your red packet and...
                        break;
                }
            }
            else
            {
                MessageBox.Show("enter a valid ip adress");
            }


        }

        private void close_cllick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    }

