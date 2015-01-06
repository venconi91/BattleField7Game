using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class Field
    {
        private int fieldSize;
        // counter of numbers property
        private int mineCounter;

        // change location of Random random = new Random(); 

        private string[,] field;

        public Field(int fieldSize) {
            this.fieldSize = fieldSize;
            this.field = new String[fieldSize, fieldSize];
            this.MineCounter = 0;


            FillEmptyCells();
            FillNumberCells();
        }

        
        private void FillEmptyCells()
        {
            for (int col = 0; col <= this.fieldSize - 1; col++)
            {
                for (int row = 0; row <= this.fieldSize - 1; row++)
                {
                    this.field[col, row] = "-";
                }
            }

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
            private set 
            {
                this.mineCounter = value;
            }
        }

        private void FillNumberCells()
        {
            int i;
            int j;

            while (this.mineCounter + 1 <= 0.3 * this.fieldSize * this.fieldSize)
            {
                Random random = new Random();
                i = Convert.ToInt32(random.Next(0, this.fieldSize - 1));
                j = Convert.ToInt32(random.Next(0, this.fieldSize - 1));

                if (this.field[i, j] == "-")
                {
                    this.field[i, j] = Convert.ToString(random.Next(1, 5));
                    this.mineCounter++;

                    if (this.mineCounter >= 0.15 * this.fieldSize * this.fieldSize)
                    {
                        int flag = Convert.ToInt32(random.Next(0, 1));
                        if (flag == 1)
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
