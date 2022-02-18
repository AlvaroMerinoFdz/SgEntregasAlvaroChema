using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SgEntregasAlvaroChema.MyConverters
{
    public class GreatherThanConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //throw new NotImplementedException();
            double.TryParse(value.ToString(), out double doubleValue);
            double.TryParse(parameter.ToString(), out double doubleParameter);
            return doubleValue > doubleParameter;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
