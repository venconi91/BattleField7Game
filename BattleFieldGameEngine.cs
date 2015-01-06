using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class BattleFieldGameEngine
    {
        //private const int MinBattleFieldSize = 1;
        //private const int MaxBattleFieldSize = 10;
        private const string EmptyFieldSymbol = "-";
        //private const string DetonatedMineSymbol = "X";

        //private const double MinNumberOFMines = 0.15;
        //private const double MaxNumberOfMines = 0.3;

        int counterOfNumbers = 0;

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
                bool canParseFieldSize = int.TryParse(userInput, out parsedFieldSize);


                if (!(Int32.TryParse(userInput, out parsedFieldSize)))
                {
                    parsedFieldSize = -1;
                }
            }
            while (parsedFieldSize < 2 || parsedFieldSize > 10);

            return parsedFieldSize;
        }


        public void Start()
        {
            fieldSize = ReadFieldSize();

            Field field = new Field(fieldSize, EmptyFieldSymbol);

            string[,] Field = field.GameField;

            counterOfNumbers = field.CounterOfNumbersOnField;

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

                    battleField.DetonateCell(row, column, Field);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Move");
                }

            }
            int detonatedBombs = battleField.DetonatedBombs;

            Console.WriteLine("Game Over.Detonated Mines {0}", detonatedBombs);
        }

        public bool IsOutOfField(int row, int column)
        {
            if ((row >= 0) && (row <= fieldSize - 1) && (column >= 0) && (column <= fieldSize - 1))
            {
                return false;
            }
            return true;
        }

    }
}