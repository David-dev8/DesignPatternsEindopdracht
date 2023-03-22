using Chess.Models.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class Move
    {
        public Square Start {get; set;}
        public Square Destination {get; set;}

        public void Make(Game game)
        {

        }

        public void Undo(Game game)
        {
        }
    }
}
