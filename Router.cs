using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myRouter
{

    [Serializable()]
    public class Router : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
        private Boolean reconnectSupport = false;
        private String model;
        private String ip;

        private String default_username;

        private String default_password;


        private string modulation="---";
        private string status="---";
        private int upStream = 0;
        private int downStream=0;
        private string internet = "0.0.0.0";
        private string adslState = "---";
        private string mac ;




        public String Internet
        {
            get { return internet; }
            set
            {


                internet = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Internet"));

            }

        }



        public String Mac
        {
            get { return mac; }
            set
            {


                mac = value;
              

            }

        }


        public Boolean ReconnectSupport
        {
            get { return reconnectSupport; }
            set
            {


                reconnectSupport = value;
              
            }

        }

        public String AdslState
        {
            get { return adslState; }
            set
            {


                adslState = value;
                OnPropertyChanged(new PropertyChangedEventArgs("AdslState"));

            }

        }




        public Boolean checkInternetStat()
        {
            if(!internet.Equals("") ||! internet.Equals("0.0.0.0"))
            {
                return true;
            }
            return false;
        }
        public Boolean checkAdslState()
        {
            if (downStream == 0)
            {
                return false;

            }
            return true;

        }

        private string brandName;

        public String BrandName
        {
            get { return brandName; }
            set
            {


                brandName = value;
           

            }

        }

        public String Ip
        {
            get { return ip; }
            set {


               ip = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Ip"));

            }

        }

       

        public String Modulation
        {
            get { return modulation; }


            set {

                modulation = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Modulation"));


            }

        }

        public String Status
        {
            get { return status; }
            set {
                status = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Status"));

                }

        }

        public int DownStream
        {
            get { return downStream; }
            set { downStream = value;
                OnPropertyChanged(new PropertyChangedEventArgs("DownStream"));

            }
           
        }



        public int UpStream
        {
            get { return upStream; }
            set { upStream = value;

                OnPropertyChanged(new PropertyChangedEventArgs("UpStream"));
            }

        }

        public String Model
        {
            get { return model; }
            set { model = value; }

        }



        public String Default_username
        {
            get { return default_username; }
            set { default_username = value; }

        }


        public String Default_password
        {
            get { return default_password; }
            set { default_password = value; }

        }


        private String username;
        private String password;
        private String authentication;
        List<Request> requests;

        public String Username
        {
            get { return username; }
            set { username= value; }

        }
        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Authentication
        {
            get { return authentication; }
            set { authentication = value; }
        }

        public List<Request> Requests
        {
            get { return requests; }
            set { requests = value; }
        }

       

        public Router() {

        }

        

   
    }
}
