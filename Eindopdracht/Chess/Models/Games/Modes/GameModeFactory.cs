using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games.Modes
{
    public class GameModeFactory
    {
        /// <summary>
        /// This method creates a game based on a given input
        /// </summary>
        /// <param name="gameMode"> The gamemode to create as a string</param>
        /// <returns>A newly created game</returns>
        public static Game CreateGame(String gameMode) {
            return gameMode switch
            {
                "Atomic chess" => new AtomicChess(),
                "Four player chess" => new FourPlayerChess(),
                "Pawnstorm chess" => new PawnStormChess(),
                "Random chess" => new RandomChess(),
                "Corrupted chess" => new CorruptedChess(),
                _ => new ClassicalChess(),
            };
        }
    }
}
