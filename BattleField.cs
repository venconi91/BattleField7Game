using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class BattleField
    {
        private Field field;
        private int detonatedBombs;

        public BattleField(Field field)
        {
            this.field = field;
            this.detonatedBombs = 0;
        }


    }
}
