using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Chess.Converters
{

    /// <summary>
    /// Converts a pair of inputs into a boolean indicating if the first value is found within the second
    /// </summary>
    public class IsContainedInCollectionConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object item = values[0];
            var collection = (IEnumerable<object>)values[1];
            return collection.Contains(item);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
