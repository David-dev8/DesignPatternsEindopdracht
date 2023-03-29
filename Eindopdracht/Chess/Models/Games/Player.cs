using Chess.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Chess.Models.Games
{

    /// <summary>
    /// This object stores a participant for a game
    /// </summary>
    public class Player: Observable
    {
        private int _score = 0;

        /// <summary>
        /// The name of the player
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The color this player plays as
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// The score of the player
        /// </summary>
        public int Score
        {
            get
            {
                return _score;
            }
            set
            {
                _score = value;
                NotifyPropertyChanged();
            }
        }

        public Player(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}
