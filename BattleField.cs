using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class BattleField
    {
        private const string EmptyFieldSymbol = "-";
        private const string DetonatedMineSymbol = "X";

        private IField field;
        private int detonatedBombs;
        private int killedNumbers;
        private string[,] Field;
        private int fieldSize;

        public BattleField(IField field)
        {
            this.field = field;
            this.Field = field.GameField;
            this.fieldSize = field.FieldSize[0];

            this.detonatedBombs = 0;
            this.killedNumbers = 0;
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
            bool canDetonate = (Field[row, column] != DetonatedMineSymbol) || ((Field[row, column]) != EmptyFieldSymbol);

            if (!canDetonate)
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
            Field[row, col] = DetonatedMineSymbol;
            killedNumbers++;


            if (cellNumber >= 1)
            {
                DetonateCell(row - 1, col - 1);
                DetonateCell(row + 1, col + 1);
                DetonateCell(row - 1, col + 1);
                DetonateCell(row + 1, col - 1);
            }
            if (cellNumber >= 2)
            {
                DetonateCell(row - 1, col);
                DetonateCell(row + 1, col);
                DetonateCell(row, col + 1);
                DetonateCell(row, col - 1);
            }
            if (cellNumber >= 3)
            {
                DetonateCell(row + 2, col);
                DetonateCell(row - 2, col);
                DetonateCell(row, col + 2);
                DetonateCell(row, col - 2);
            }
            if (cellNumber >= 4)
            {
                DetonateCell(row + 2, col + 1);
                DetonateCell(row + 2, col - 1);
                DetonateCell(row - 2, col + 1);
                DetonateCell(row - 2, col - 1);
                DetonateCell(row - 1, col + 2);
                DetonateCell(row - 1, col - 2);
                DetonateCell(row + 1, col + 2);
                DetonateCell(row + 1, col - 2);

            }
            if (cellNumber == 5)
            {
                DetonateCell(row - 2, col + 2);
                DetonateCell(row - 2, col - 2);
                DetonateCell(row + 2, col - 2);
                DetonateCell(row + 2, col + 2);
            }
        }

        public void DetonateCell(int row, int col)
        {
            bool isInRange = (row < fieldSize && row >= 0) && (col >= 0 && col < fieldSize);

            if (isInRange && (Field[row, col] != DetonatedMineSymbol && Field[row, col] != EmptyFieldSymbol))
            {
                killedNumbers++;
            }
            if (isInRange && Field[row, col] != DetonatedMineSymbol)
            {
                Field[row, col] = DetonatedMineSymbol;
            }
        }

    }
}
