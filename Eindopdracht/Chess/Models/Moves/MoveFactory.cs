using Chess.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class MoveFactory
    {
        public Move CreateMove(Square start, Square destination, MoveOptions[] options = null)
        {
            return new Move(start, destination);
        }
    }
}
