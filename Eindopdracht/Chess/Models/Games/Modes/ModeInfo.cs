using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Games.Modes
{
    /// <summary>
    /// Stores information for a particular game mode
    /// </summary>
    public class ModeInfo
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ModeInfo(string name, string description) 
        { 
            Name = name;
            Description = description;
        }
    }
}
