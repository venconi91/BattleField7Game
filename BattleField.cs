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
        private int killedNumbers;
        private string[,] Field;
        private int fieldSize;

        public BattleField(Field field, int fieldSize)
        {
            this.field = field;
            this.detonatedBombs = 0;
            this.killedNumbers = 0;
            this.Field = field.GameField;
            this.fieldSize = fieldSize;
        }

        public int KilledNumbers 
        {
            get
            {
                return this.killedNumbers;
            }
        }
        public int DetonatedBombs
        {
            get
            {
                return this.detonatedBombs;
            }
        }

        public bool RemainBombsForDetonating() {
            int undetonatedBombs = field.MineCounter- killedNumbers;
            bool remainUndetonatedBombs = undetonatedBombs > 0;

            return remainUndetonatedBombs;
        }
        public void DetonateCell(int row, int column)
        {
            if ((Field[row, column] == "X") || ((Field[row, column]) == "-"))
            {
                throw new ArgumentOutOfRangeException("Cannot detonate the cell");
            }

            int cellNumber = Convert.ToInt32(Field[row, column]);

            switch (cellNumber)
            {
                case 1:
                    DetonateCellWithNumberOne(row, column);
                    Printer.PrintOnConsole(Field);
                    detonatedBombs++;
                    break;
                case 2:
                    DetonateCellWithNumberTwo(row, column);
                    Printer.PrintOnConsole(Field);
                    detonatedBombs++;
                    break;
                case 3:
                    DetonateCellWithNumberThree(row, column);
                    Printer.PrintOnConsole(Field);
                    detonatedBombs++;
                    break;
                case 4:
                    DetonateCellWithNumberFour(row, column);
                    Printer.PrintOnConsole(Field);
                    detonatedBombs++;
                    break;
                case 5:
                    DetonateCellWithNumberFive(row, column);
                    Printer.PrintOnConsole(Field);
                    detonatedBombs++;
                    break;
                default:
                    throw new Exception("invalid number");
            }
        }

        public void DetonateCellWithNumberOne(int row, int column)
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
        public void DetonateCellWithNumberTwo(int row, int column)
        {
            DetonateCellWithNumberOne(row, column);

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

        public void DetonateCellWithNumberThree(int row, int column)
        {
            DetonateCellWithNumberTwo(row, column);

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

        public void DetonateCellWithNumberFour(int row, int column)
        {
            DetonateCellWithNumberThree(row, column);

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
        public void DetonateCellWithNumberFive(int row, int column)
        {
            DetonateCellWithNumberFour(row, column);

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
