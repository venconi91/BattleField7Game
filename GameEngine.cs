using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class GameEngine
    {
        //private const int MinBattleFieldSize = 1;
        //private const int MaxBattleFieldSize = 10;
        //private const string EmptyFieldSymbol = "-";
        //private const string DetonatedMineSymbol = "X";

        //private const double MinNumberOFMines = 0.15;
        //private const double MaxNumberOfMines = 0.3;

        int mineCount = 0;

        int fieldSize;

        public int ReadFieldSize()
        {
            string userInput;
            int parsedFieldSize;

            do
            {
                Console.WriteLine("Please Enter Valid Size Of The Field.");
                Console.Write("FieldSize = ");

                userInput = Console.ReadLine();

                if (!(Int32.TryParse(userInput, out parsedFieldSize)))
                {
                    parsedFieldSize = -1;
                }

            } while (parsedFieldSize < 2 || parsedFieldSize > 10);

            return parsedFieldSize;
        }


        public void Start()
        {
            fieldSize = ReadFieldSize();

            Field field = new Field(fieldSize);

            string[,] Field = field.GameField;

            mineCount = field.MineCounter;

            Console.WriteLine();

            Printer.PrintOnConsole(Field);

            BattleField battleField = new BattleField(field, fieldSize);


            while (battleField.RemainBombsForDetonating())
            {
                Console.Write("Please Enter Coordinates : ");

                try
                {
                    string inputCoordinates = Console.ReadLine();
                    string[] rowAndColumnSplit = inputCoordinates.Split(' ');

                    int[] coordinates = Validator.checkStringForValidCoordinates(inputCoordinates, fieldSize);

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