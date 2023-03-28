using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Chess.Converters
{
    public class DiagonalAlternationToBrushConverter : IValueConverter
    {
        private int count = 0;

        private static SolidColorBrush[] _alternatingBrushes = new SolidColorBrush[]
        {
            new SolidColorBrush(new Color() { A = 100, G = 100, R = 100, B = 100 }),
            new SolidColorBrush(new Color() { A = 100, G = 100, R = 0, B = 100 })
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int rowCount = (int)value;

            SolidColorBrush colorBrush = _alternatingBrushes[(count + (int)(count / rowCount)) % _alternatingBrushes.Length];
            count++;
            return colorBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
