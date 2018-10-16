using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace myRouter
{
    public class Testes : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
            myPing ping = (myPing)value;

            if (ping != null)
            {
                if (ping.Name != null)
                {
                    return ping.Name + " (" + ping.Ip+")";
                }
                else
                {
                    return ping.Ip;
                }
            }
           
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        
    }
}
