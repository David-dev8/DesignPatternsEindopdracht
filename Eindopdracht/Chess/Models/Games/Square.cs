using Chess.Base;
using Chess.Models.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games
{
    public class Square: Observable
    {
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
                if(_piece != null) // TODO
                {
                    _piece.Square = this;
                }
                NotifyPropertyChanged();
            }
        }

        public Square() 
        {
        }

        public bool IsOccupied()
        {
            return Piece != null;
        }
    }
}
