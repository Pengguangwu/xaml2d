using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI;

namespace RestaurantManager.Extensions
{
    public class BooleanToColorConverter : IValueConverter
    {
        private bool StringToBool;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            string returnValue = Colors.Transparent.ToString();
            StringToBool = false;
           if (value.ToString().Length > 0 )
            {
                StringToBool = true;
            }
          
            returnValue = StringToBool ? Colors.Red.ToString() : Colors.Transparent.ToString();
          
            return returnValue;

        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
