using Chess.Models.Games;
using Chess.Models.Movement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Models.Pieces
{
    /// <summary>
    /// The piece class represents a chess piece
    /// </summary>
    public class Piece
    {
        public MovementPattern Movement { get; set; }
        public Color Color { get; set; }
        public string Image { get; set; }

        /// <summary>
        /// Creates a chess piece
        /// </summary>
        /// <param name="image">The icon for this chess piece</param>
        /// <param name="color">The color of this chess piece</param>
        /// <param name="movementPattern">The movementpatern this piece has</param>
        public Piece(string image, Color color, MovementPattern movementPattern) 
        {
            Image = image;
            Color = color;
            Movement = movementPattern;
        }
    }
}
