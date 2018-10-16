using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace myRouter
{ 

  
    
    public class myPing : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }
      
  private string ip;
        private string value;
        private string country;
        private Boolean selected;
        private Boolean active;
        private string name;



        public Boolean Active
        {
            get { return active; }
            set
            {


                this.active = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Active"));

            }

        }
        public Boolean Selected
        {
            get { return selected; }
            set
            {


                this.selected = value;
                Console.WriteLine(value);
                OnPropertyChanged(new PropertyChangedEventArgs("selected"));

            }

        }


        public string Value {
            get { return value; }
            set
            {


                this.value = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Value"));

            }



        }

        public string Name
        {
            get { return name; }
            set
            {


                this.name = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Name"));

            }



        }

        public string Ip
        {
            get { return ip; }
            set
            {


                ip = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Ip"));

            }



        }

        public string Country
        {
            get { return country; }
            set
            {


                this.country = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Country"));

            }



        }


    }
}
