﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class BattleField
    {
        private const int MinBattleFieldSize = 1;
        private const int MaxBattleFieldSize = 10;

        private int size;
        private int DetonatedMines;

        public BattleField(int size)
        {
            this.Size = size;
            this.DetonatedMines = 0;
        }

        public int Size
        {
            //get
            //{
            //    return this.size;
            //}

            //set
            //{
            //    if (value < MinBattleFieldSize || value > MaxBattleFieldSize)
            //    {
            //        throw new ArgumentOutOfRangeException("The battlefield size must be between 1 and 10.");
            //    }

            //    this.size = value;
            //}
        }
    }
}
