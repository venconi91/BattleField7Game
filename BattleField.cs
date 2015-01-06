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

        public bool RemainBombsForDetonating()
        {
            int undetonatedBombs = field.MineCounter - killedNumbers;
            bool remainUndetonatedBombs = undetonatedBombs > 0;

            return remainUndetonatedBombs;
        }

        public void Detonate(int row, int column)
        {
            if ((Field[row, column] == "X") || ((Field[row, column]) == "-"))
            {
                throw new ArgumentOutOfRangeException("Cannot detonate the cell");
            }

            int cellNumber = Convert.ToInt32(Field[row, column]);

            DetonateArea(cellNumber, column, row);
            
            detonatedBombs++;
            Printer.PrintOnConsole(Field);
        }

        public void DetonateArea(int cellNumber, int col, int row)
        {
            Field[row, col] = "X";
            killedNumbers++;


            if (cellNumber >= 1)
            {
                MarkCell(row - 1, col - 1);
                MarkCell(row + 1, col + 1);
                MarkCell(row - 1, col + 1);
                MarkCell(row + 1, col - 1);
            }
            if (cellNumber >= 2)
            {
                MarkCell(row - 1, col);
                MarkCell(row + 1, col);
                MarkCell(row, col + 1);
                MarkCell(row, col - 1);
            }
            if (cellNumber >= 3)
            {
                MarkCell(row + 2, col);
                MarkCell(row - 2, col);
                MarkCell(row, col + 2);
                MarkCell(row, col - 2);
            }
            if (cellNumber >= 4)
            {
                MarkCell(row + 2, col + 1);
                MarkCell(row + 2, col - 1);
                MarkCell(row - 2, col + 1);
                MarkCell(row - 2, col - 1);
                MarkCell(row - 1, col + 2);
                MarkCell(row - 1, col - 2);
                MarkCell(row + 1, col + 2);
                MarkCell(row + 1, col - 2);

            }
            if (cellNumber == 5)
            {
                MarkCell(row - 2, col + 2);
                MarkCell(row - 2, col - 2);
                MarkCell(row + 2, col - 2);
                MarkCell(row + 2, col + 2);
            }
        }

        public void MarkCell(int row, int col)
        {
            bool isInRange = (row < fieldSize && row >= 0) && (col >= 0 && col < fieldSize);

            if (isInRange && (Field[row,col] != "X" && Field[row,col] != "-"))
            {
                killedNumbers++;
            }
            if (isInRange && Field[row, col] != "X")
            {
                Field[row, col] = "X";
            }
        }

    }
}
