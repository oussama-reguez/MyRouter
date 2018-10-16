using MahApps.Metro.Controls;
using myRouter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

namespace WpfApplication4
{
    /// <summary>
    /// Interaction logic for feedback.xaml
    /// </summary>
    public partial class feedback : MetroWindow
    {
        public feedback()
        {
            InitializeComponent();
        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string subject = "MyRouter feedBack";
            string content = "";
            if (name.Text != "")
            {
                subject = name.Text + "'s MyRouter feedBack";
            }

            if (email.Text != "")
            {
                content += "Email from " + email.Text + ":";
            }
            content += description.Text;
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    // Configure the client
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    // client.Credentials = new NetworkCredential("myrouteruserfeedback@gmail.com", "nfjmwqulzamxttzf");
                    // acwcybxcrghokxtx
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    MailMessage message = new MailMessage(
                    "myrouteruserfeedback@gmail.com",
                    "oussamareguez@gmail.com", // Recipient field
                    subject, // Subject of the email message
                    content // Email message body
                    );
                    client.Credentials = new System.Net.NetworkCredential("myrouteruserfeedback@gmail.com", "acwcybxcrghokxtx");

                    client.Send(message);
                    feedBackDialog.Visibility = Visibility.Collapsed;
                    success.Visibility = Visibility.Visible;
                }

            }
            catch(Exception ex)
            {
                feedBackDialog.Visibility = Visibility.Collapsed;
                success.Visibility = Visibility.Visible;
            }
           
        }

       
        private void close_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
