using Chess.Models.Games;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public abstract class MoveFactory
    {
        public abstract Move CreateMove(Square start, Square destination, MoveOptions[] options = null);
    }
}
