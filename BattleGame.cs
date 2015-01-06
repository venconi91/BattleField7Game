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

        private static int getRandomNumber(int min, int max)
        {
            Random random = new Random();
            return Convert.ToInt32(random.Next(min, max));
        }

        //string[,] Field;


        public void DetonateCell(int row, int column, string[,] Field)
        {
            int cellNumber;

            if ((Field[row, column] == "X") || ((Field[row, column]) == "-"))
            {
                cellNumber = 0;
            }
            else
            {
                cellNumber = Convert.ToInt32(Field[row, column]);
            }
            switch (cellNumber)
            {
                case 1:
                    {
                        DetonateCellWithNumberOne(row, column, Field);

                        WriteFieldOnTheConsole(Field);

                        detonatedBombs++;

                        break;
                    }
                case 2:
                    {
                        DetonateCellWithNumberTwo(row, column, Field);

                        WriteFieldOnTheConsole(Field);

                        detonatedBombs++;
                        break;
                    }
                case 3:
                    {
                        DetonateCellWithNumberThree(row, column, Field);

                        WriteFieldOnTheConsole(Field);

                        detonatedBombs++;
                        break;
                    }

                case 4:
                    {
                        DetonateCellWithNumberFour(row, column, Field);

                        WriteFieldOnTheConsole(Field);

                        detonatedBombs++;
                        break;
                    }
                    ;
                case 5:
                    {
                        DetonateCellWithNumberFive(row, column, Field);

                        WriteFieldOnTheConsole(Field);

                        detonatedBombs++;
                        break;
                    }
                    ;

                default:
                    {
                        Console.WriteLine("Invalid Move!");
                        Console.WriteLine();
                        break;
                    }
            }
        }

        int detonatedBombs = 0;


        public int ReadFieldSize()
        {
            string userInput;
            int userInputNumber;

            do
            {
                Console.WriteLine("Please Enter Valid Size Of The Field.");
                Console.Write("FieldSize = ");

                userInput = Console.ReadLine();

                if (!(Int32.TryParse(userInput, out userInputNumber)))
                {
                    userInputNumber = -1;
                }
            }
            while (userInputNumber < 2 || userInputNumber > 10);

            return userInputNumber;
        }

        int killedNumbers = 0;

        
        public void Start()
        {
            fieldSize = ReadFieldSize();

            Field gameField = new Field(fieldSize, EmptyFieldSymbol); // rename it ro field

            string[,] Field = gameField.FieldBoard; // rename it field.gameField

            counterOfNumbers = gameField.CounterOfNumbersOnField;
            //string[,] FieldWithEmptyCells = FillFieldWithEmptyCells(Field);

            //FillFieldWithNumbers(fieldSize, FieldWithEmptyCells);

            Console.WriteLine();

            WriteFieldOnTheConsole(Field);

            while (killedNumbers < counterOfNumbers)
            {
                Console.Write("Please Enter Coordinates : ");

                try
                {
                    string inputRowAndColumn = Console.ReadLine();
                    string[] rowAndColumnSplit = inputRowAndColumn.Split(' ');
                    int row;
                    int column;

                    if ((rowAndColumnSplit.Length) <= 0)
                    {
                        throw new IndexOutOfRangeException("Negative values are not allowed");
                    }
                    else
                    {
                        // to format bool res = int.TryParse(text1, out num1);
                        // if (res == false) ..

                        if (!(int.TryParse(rowAndColumnSplit[0], out row)))
                        {
                            throw new Exception("Input should be number");
                        }
                        if (!(int.TryParse(rowAndColumnSplit[1], out column)))
                        {
                            throw new Exception("Input should be number");
                        }
                    }

                    if ((IsOutOfField(row, column)))
                    {
                        throw new IndexOutOfRangeException("This Move Is Out Of Area.");
                    }

                    DetonateCell(row, column, Field);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Move");
                }

            }

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

        private void WriteFieldOnTheConsole(string[,] Field)
        {


            Console.Write("   ");
            for (int k = 0; k <= fieldSize - 1; k++)
            {
                Console.Write(k + " ");
            }
            Console.WriteLine();
            Console.Write("   ");
            for (int k = 0; k <= fieldSize - 1; k++)
            {
                Console.Write("--");
            }
            Console.WriteLine();

            for (int i = 0; i <= fieldSize - 1; i++)
            {
                Console.Write(i + "| ");
                for (int j = 0; j <= fieldSize - 1; j++)
                {
                    Console.Write(Field[i, j] + " ");
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        public void DetonateCellWithNumberOne(int row, int column, string[,] Field)
        {
            Field[row, column] = "X";
            killedNumbers++;
            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if ((Field[row - 1, column - 1] != "X") && (Field[row - 1, column - 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 1, column - 1] = "X";
            }

            if ((row + 1 <= fieldSize - 1) && (column - 1 >= 0))
            {
                if ((Field[row + 1, column - 1] != "X") && (Field[row + 1, column - 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 1, column - 1] = "X";
            }

            if ((row - 1 >= 0) && (column + 1 <= fieldSize - 1))
            {
                if ((Field[row - 1, column + 1] != "X") && (Field[row - 1, column + 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 1, column + 1] = "X";
            }

            if ((row + 1 <= fieldSize - 1) && (column + 1 <= fieldSize - 1))
            {
                if ((Field[row + 1, column + 1] != "X") && (Field[row + 1, column + 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 1, column + 1] = "X";
            }
        }
        public void DetonateCellWithNumberTwo(int row, int column, string[,] Field)
        {
            DetonateCellWithNumberOne(row, column, Field);

            if (row - 1 >= 0)
            {
                if ((Field[row - 1, column] != "X") && (Field[row - 1, column] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 1, column] = "X";
            }

            if (column - 1 >= 0)
            {
                if ((Field[row, column - 1] != "X") && (Field[row, column - 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row, column - 1] = "X";
            }

            if (column + 1 <= fieldSize - 1)
            {
                if ((Field[row, column + 1] != "X") && (Field[row, column + 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row, column + 1] = "X";
            }

            if (row + 1 <= fieldSize - 1)
            {
                if ((Field[row + 1, column] != "X") && (Field[row + 1, column] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 1, column] = "X";
            }
        }

        public void DetonateCellWithNumberThree(int row, int column, string[,] Field)
        {
            DetonateCellWithNumberTwo(row, column, Field);

            if (row - 2 >= 0)
            {
                if ((Field[row - 2, column] != "X") && (Field[row - 2, column] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 2, column] = "X";
            }

            if (column - 2 >= 0)
            {
                if ((Field[row, column - 2] != "X") && (Field[row, column - 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row, column - 2] = "X";
            }

            if (column + 2 <= fieldSize - 1)
            {
                if ((Field[row, column + 2] != "X") && (Field[row, column + 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row, column + 2] = "X";
            }

            if (row + 2 <= fieldSize - 1)
            {
                if ((Field[row + 2, column] != "X") && (Field[row + 2, column] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 2, column] = "X";
            }
        }

        public void DetonateCellWithNumberFour(int row, int column, string[,] Field)
        {
            DetonateCellWithNumberThree(row, column, Field);

            if ((row - 1 >= 0) && (column - 2 >= 0))
            {
                if ((Field[row - 1, column - 2] != "X") && (Field[row - 1, column - 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 1, column - 2] = "X";
            }

            if ((row + 1 <= fieldSize - 1) && (column - 2 >= 0))
            {
                if ((Field[row + 1, column - 2] != "X") && (Field[row + 1, column - 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 1, column - 2] = "X";
            }

            if ((row - 2 >= 0) && (column - 1 >= 0))
            {
                if ((Field[row - 2, column - 1] != "X") && (Field[row - 2, column - 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 2, column - 1] = "X";
            }

            if ((row + 2 <= fieldSize - 1) && (column - 1 >= 0))
            {
                if ((Field[row + 2, column - 1] != "X") && (Field[row + 2, column - 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 2, column - 1] = "X";
            }

            if ((row - 1 >= 0) && (column + 2 <= fieldSize - 1))
            {
                if ((Field[row - 1, column + 2] != "X") && (Field[row - 1, column + 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 1, column + 2] = "X";
            }

            if ((row + 1 <= fieldSize - 1) && (column + 2 <= fieldSize - 1))
            {
                if ((Field[row + 1, column + 2] != "X") && (Field[row + 1, column + 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 1, column + 2] = "X";
            }

            if ((row - 2 >= 0) && (column + 1 <= fieldSize - 1))
            {
                if ((Field[row - 2, column + 1] != "X") && (Field[row - 2, column + 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 2, column + 1] = "X";
            }

            if ((row + 2 <= fieldSize - 1) && (column + 1 <= fieldSize - 1))
            {
                if ((Field[row + 2, column + 1] != "X") && (Field[row + 2, column + 1] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 2, column + 1] = "X";
            }
        }
        public void DetonateCellWithNumberFive(int row, int column, string[,] Field)
        {
            DetonateCellWithNumberFour(row, column, Field);

            if ((row - 2 >= 0) && (column - 2 >= 0))
            {
                if ((Field[row - 2, column - 2] != "X") && (Field[row - 2, column - 2] != "-"))
                {
                    killedNumbers++;
                }

                Field[row - 2, column - 2] = "X";
            }

            if ((row + 2 <= fieldSize - 1) && (column - 2 >= 0))
            {
                if ((Field[row + 2, column - 2] != "X") && (Field[row + 2, column - 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 2, column - 2] = "X";
            }

            if ((row - 2 >= 0) && (column + 2 <= fieldSize - 1))
            {
                if ((Field[row - 2, column + 2] != "X") && (Field[row - 2, column + 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row - 2, column + 2] = "X";
            }

            if ((row + 2 <= fieldSize - 1) && (column + 2 <= fieldSize - 1))
            {
                if ((Field[row + 2, column + 2] != "X") && (Field[row + 2, column + 2] != "-"))
                {
                    killedNumbers++;
                }
                Field[row + 2, column + 2] = "X";
            }
        }
    }
}