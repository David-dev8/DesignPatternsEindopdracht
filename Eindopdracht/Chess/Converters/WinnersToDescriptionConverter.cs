using Chess.Models.Games;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Chess.Converters
{
    public class WinnersToDescriptionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<Player> players = (IEnumerable<Player>)value;
            return players == null ? "" :
                (!players.Any() ? "Game ended in a draw!" : $"Congratulations, {string.Join(',', players.Select(player => player.Name))} won the game!");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
