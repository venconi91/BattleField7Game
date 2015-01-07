using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class GameEngine
    {
        public void Start()
        {
            int fieldSize = UserInput.ReadFieldSize();

            SquareField field = new SquareField(fieldSize);

            int[] squareFieldSizes = new int[1] { fieldSize };
            Field2DFactory.Factory.Get("rectangle", squareFieldSizes);

            Printer.PrintOnConsole(field.GameField);

            BattleField battleField = new BattleField(field);

            while (battleField.RemainBombsForDetonating())
            {
                Console.Write("Please Enter Coordinates : ");

                try
                {
                    int[] coordinates = UserInput.GetValidCoordinates(fieldSize);

                    int row = coordinates[0];
                    int column = coordinates[1];

                    battleField.Detonate(row, column);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Move");
                }
            }

            Console.WriteLine("Game Over. Detonated Mines: {0}", battleField.DetonatedBombs);
        }

    }
}