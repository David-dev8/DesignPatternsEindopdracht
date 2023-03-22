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
    public class ArrayFlattenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ICollection<object> currentIteration = (ICollection<object>)value;
            while(currentIteration.Any(element => element is Array)) { 
                IList<object> newIteration = new List<object>();
                foreach(var item in currentIteration)
                {
                    if(item is Array array)
                    {
                        foreach(var element in array)
                        {
                            newIteration.Add(element);
                        }
                    } 
                    else
                    {
                        newIteration.Add(item);
                    }
                }
                currentIteration = newIteration;
            }
            return currentIteration;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
