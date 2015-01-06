using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BattleFieldNamespace
{
    class BattleFieldGame //: BattleGame // tuka naslediavame osbhtata igra i pravilata
    {

        static void Main(string[] args)
        {
            GameEngine BF = new GameEngine();

            BF.Start();
        }
    }
}
