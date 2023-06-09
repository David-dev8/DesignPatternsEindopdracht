﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Chess.Converters
{
    /// <summary>
    /// Converts a brush into brush based on the amount of times this object is called, every even use will get 1 color and every uneven use gets another.
    /// </summary>
    public class DiagonalAlternationToBrushConverter : IMultiValueConverter
    {
        private int count = 0;

        private static SolidColorBrush[] _alternatingBrushes = new SolidColorBrush[]
        {
            new SolidColorBrush(new Color() { A = 100, G = 100, R = 100, B = 100 }),
            new SolidColorBrush(new Color() { A = 100, G = 100, R = 0, B = 100 })
        };

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if(values[1] == null)
            {
                count++;
                return new SolidColorBrush(Colors.Transparent);
            }
            int rowCount = (int)values[0];

            SolidColorBrush colorBrush = _alternatingBrushes[(count + (int)(count / rowCount)) % _alternatingBrushes.Length];
            count++;
            return colorBrush;
        }

        public object[] ConvertBack(object values, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
