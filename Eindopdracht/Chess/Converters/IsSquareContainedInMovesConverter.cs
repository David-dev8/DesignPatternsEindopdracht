using Chess.Models.Games;
using Chess.Models.Moves;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Chess.Converters
{

    /// <summary>
    /// A converter that converts 2 values into a list of moves indicating wether the first input is part of the second
    /// </summary>
    public class IsSquareContainedInMovesConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            List<Move> moves = (List<Move>)values[1];
            Square square = (Square)values[0];
            return moves.Any(move => move.Destination == square);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
