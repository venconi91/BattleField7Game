using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    public class SquareField : IField
    {
        private const double MinMinesFactor = 0.15;
        private const double MaxMinesFactor = 0.3;

        private int fieldSize;
        private string[,] field;
        private int mineCounter;

        public SquareField(int fieldSize)
        {
            this.fieldSize = fieldSize;
            this.field = new String[fieldSize, fieldSize];
            this.mineCounter = 0;

            FillField();
        }

        public string[,] GameField
        {
            get
            {
                return this.field;
            }
        }

        public int MineCounter
        {
            get
            {
                return this.mineCounter;
            }
        }
        public int[] FieldSize
        {
            get
            {
                return new int[1]{fieldSize};
            }
        }

        private void FillField()
        {
            FillEmptyCells();
            FillNumberCells();
        }

        private void FillEmptyCells()
        {
            for (int col = 0; col < this.fieldSize; col++)
            {
                for (int row = 0; row < this.fieldSize; row++)
                {
                    this.field[col, row] = "-";
                }
            }
        }

        private void FillNumberCells()
        {
            Random random = new Random();

            double maxNumberOfMines = MaxMinesFactor * this.fieldSize * this.fieldSize;
            double minNumberOfMines = MinMinesFactor * this.fieldSize * this.fieldSize;

            while (this.mineCounter < maxNumberOfMines)
            {
                int randomRowPosition = Convert.ToInt32(random.Next(0, this.fieldSize));
                int randomColPosition = Convert.ToInt32(random.Next(0, this.fieldSize));

                string currentCellSymbol = this.field[randomRowPosition, randomColPosition];

                if (currentCellSymbol == "-")
                {
                    this.field[randomRowPosition, randomColPosition] = Convert.ToString(random.Next(1, 6));
                    this.mineCounter++;

                    if (this.mineCounter >= minNumberOfMines)
                    {
                        bool areMinesEnough = Convert.ToInt32(random.Next(0, 1)) == 1;

                        if (areMinesEnough)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
