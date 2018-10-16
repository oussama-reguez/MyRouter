using MahApps.Metro.Controls;
using myRouter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    /// 
    public static class AssemblyHlelper{
        public static DateTime GetLinkerTime(this Assembly assembly, TimeZoneInfo target = null)
        {
            var filePath = assembly.Location;
            const int c_PeHeaderOffset = 60;
            const int c_LinkerTimestampOffset = 8;

            var buffer = new byte[2048];

            using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                stream.Read(buffer, 0, 2048);

            var offset = BitConverter.ToInt32(buffer, c_PeHeaderOffset);
            var secondsSince1970 = BitConverter.ToInt32(buffer, offset + c_LinkerTimestampOffset);
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            var linkTimeUtc = epoch.AddSeconds(secondsSince1970);

            var tz = target ?? TimeZoneInfo.Local;
            var localTime = TimeZoneInfo.ConvertTimeFromUtc(linkTimeUtc, tz);

            return localTime;
        }
    }
    public partial class About :MetroWindow
    {
       
        public About()
        {
            InitializeComponent();
            string date = File.GetCreationTime(Assembly.GetExecutingAssembly().Location).ToString("dd/MM/yyy");
            string ver = Assembly.GetExecutingAssembly().GetName().Version.ToString();
           
           
            twitterLink.RequestNavigate += (sender, e) =>
            {
                System.Diagnostics.Process.Start(e.Uri.ToString());
            };
            facebookLink.RequestNavigate += (sender, e) =>
            {
                System.Diagnostics.Process.Start(e.Uri.ToString());
            };
            version.Content += ""+ver+"("+date+")";
            // var linkTimeLocal = Assembly.GetExecutingAssembly().GetLinkerTime();

          
            if (Updater.currentReleaseNote == null)
            {
                string releases = Updater.getCurrentReleaseNote();

               

                if (releases != null) {
                    releasePanel.Visibility = Visibility.Visible;
                    string regex = "<p[^>]*?>(?<TagText>.*?)</p>";
                    MatchCollection mc = Regex.Matches(releases, regex, RegexOptions.Singleline);

                    foreach (Match m in mc)
                    {
                        releaseNote.Text+=m.Groups["TagText"].Value;
                    }
                  
                }
            
                ;
            }
            else
            {

            }
        }
       

        public void hello()
        {

        }

        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            feedback feed = new feedback();
            feed.Show();
            //datausage
            MainWindow.nbrFeedback++;
            //datausage
        }

        private void checkUpdate(object sender, RoutedEventArgs e)
        {
            updateDialog update = new updateDialog();
            update.Show();
            //datausage
            MainWindow.nbrUpdate++;
            //datausage
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void twitterLink_Click(object sender, RoutedEventArgs e)
        {
            //datausage
            MainWindow.nbrTwitter++;
            //datausage
        }

        private void facebookLink_Click(object sender, RoutedEventArgs e)
        {
            //datausage
            MainWindow.nbrFacebook++;
            //datausage
        }
    }

}
