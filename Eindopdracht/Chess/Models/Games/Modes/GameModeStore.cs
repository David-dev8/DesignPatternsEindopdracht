﻿using Chess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games.Modes
{
    /// <summary>
    /// Creates all possible GameModes
    /// </summary>
    public static class GameModeStore
    {
        /// <summary>
        /// Gets information of all possible GameModes
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<ModeInfo> GetModeInfos()
        {
            return new List<ModeInfo>()
            {
                new ModeInfo("Classic chess", "This is just classical chess. 2 players, normal board, no special pieces, no special interactions."),
                new ModeInfo("Atomic chess", "This is atomic chess, atomic refers to the fact that all pieces are highly volatile. Capturing a piece will result in the removal of all pieces within a 3 x 3 area with the captured piece as the centre (A kings radius)."),
                new ModeInfo("Four player chess", "Like classical chess this mode does not implement any new pieces or interactions, however it does implement double the players. Take on 3 other players or cooperate to win in this 4 player chess mode."),
                new ModeInfo("Pawnstorm chess", "In this mode one player plays chess just like normal on a normal board with normal pieces. The second player however will have no normal pieces except for a lot of pawns."),
                new ModeInfo("Random chess", "In this gamemode both players will still have all their normal pieces. But their starting possition will be randomised"),
                new ModeInfo("Corrupted chess", "Oh no! All pieces got corrupted and all of a sudden have completely different abilities. Can you handle the situation?"),
            };
        }
    }
}
