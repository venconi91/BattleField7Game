using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class Field
    {
        private int fieldSize;
        private string emptySymbol;
        // counter of numbers property
        private int counterOfNumbersOnField;

        // change location of Random random = new Random(); 

        private string[,] field;

        public Field(int fieldSize, string emptySymbol)
        {
            this.fieldSize = fieldSize;
            this.emptySymbol = emptySymbol;
            this.field = new String[fieldSize, fieldSize];
            this.CounterOfNumbersOnField = 0;

            FillField();
        }

        

        private void FillField() {
            FillCellsWithEmptySymbol();
            FillCellsWithNumbers();
        }

        private void FillCellsWithEmptySymbol()
        {
            for (int col = 0; col <= this.fieldSize - 1; col++)
            {
                for (int row = 0; row <= this.fieldSize - 1; row++)
                {
                    this.field[col, row] = "-";
                }
            }

        }

        public string[,] FieldBoard
        {
            get
            {
                return this.field;
            }
        }

        public int CounterOfNumbersOnField 
        {
            get
            {
                return this.counterOfNumbersOnField;
            }
            private set 
            {
                this.counterOfNumbersOnField = value;
            }
        }

        private void FillCellsWithNumbers()
        {
            int i;
            int j;

            while (this.counterOfNumbersOnField + 1 <= 0.3 * this.fieldSize * this.fieldSize)
            {
                i = getRandomNumber(0, this.fieldSize - 1);
                j = getRandomNumber(0, this.fieldSize - 1);

                if (this.field[i, j] == "-")
                {
                    this.field[i, j] = Convert.ToString(getRandomNumber(1, 5));
                    this.counterOfNumbersOnField++;

                    if (this.counterOfNumbersOnField >= 0.15 * this.fieldSize * this.fieldSize)
                    {
                        int flag = getRandomNumber(0, 1);
                        if (flag == 1)
                        {
                            break;
                        }
                    }
                }
            }
        }
        private static int getRandomNumber(int min, int max)
        {
            Random random = new Random();
            return Convert.ToInt32(random.Next(min, max));
        }
    }
}
