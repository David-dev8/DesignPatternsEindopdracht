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
    public class Piece
    {
        public MovementPattern Movement { get; set; }
        public Color Color { get; set; }
        public Square Square { get; set; }
        public string Image { get; set; }

        public Piece(string image, Color color, MovementPattern movementPattern) 
        {
            Image = image;
            Color = color;
            Movement = movementPattern;
            Square = null;
        }
    }
}
