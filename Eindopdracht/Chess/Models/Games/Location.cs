using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games
{
    /// <summary>
    /// The location is a location on a 2 dimensional grid as pair of coordinates
    /// </summary>
    public class Location
    {
        public int Row { get; set; }
        public int Column { get; set; }

        /// <summary>
        /// Creates a location based on coordinates
        /// </summary>
        /// <param name="row">The Y value</param>
        /// <param name="column">The x value</param>
        public Location(int row, int column)
        {
            Row = row;
            Column = column;
        }   
    }
}
