﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Models.Moves
{
    public class EnPassantCaptureDecorator : BaseMoveDecorator
    {
        public EnPassantCaptureDecorator(Move move) : base(move)
        {
        }
    }
}
