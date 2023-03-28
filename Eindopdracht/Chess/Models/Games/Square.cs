using Chess.Base;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games
{
    /// <summary>
    /// The square is one of the squares on the chessboard
    /// </summary>
    public class Square: Observable
    {
        /// <summary>
        /// The piece standing on this square
        /// </summary>
        private Piece _piece;
        public Piece Piece
        {
            get
            {
                return _piece;
            }
            set
            {
                _piece = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Returns wether or not this space already has a piece on it
        /// </summary>
        public bool IsOccupied
        {
            get
            {
                return Piece != null;
            }
        }
    }
}
