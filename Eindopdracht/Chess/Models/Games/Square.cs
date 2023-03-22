using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games
{
    public class Square
    {
        public Piece Piece { get; set; }

        public Square() 
        {
            Piece = null;
        }

        public bool IsOccupied()
        {
            return Piece != null;
        }
    }
}
