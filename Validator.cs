using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class Validator
    {
        public static Boolean IsInFieldBoundary(int row, int col, int fieldSize)
        {
            if ((row >= 0) && (row <= fieldSize - 1) && (col >= 0) && (col <= fieldSize - 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int[] checkStringForValidCoordinates(string inputCoordinates, int fieldSize) {
            string[] rowAndColumnSplit = inputCoordinates.Split(' ');
            int row;
            int column;

            if ((rowAndColumnSplit.Length) <= 0)
            {
                throw new IndexOutOfRangeException("Empty coordinates are not allowed");
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

            if ((IsOutOfField(row, column, fieldSize)))
            {
                throw new IndexOutOfRangeException("This Move Is Out Of Area.");
            }
            int[] coordinates = new int[2] { row, column };
            return coordinates;
        }

        public static bool IsOutOfField(int row, int column, int fieldSize)
        {
            if ((row >= 0) && (row <= fieldSize - 1) && (column >= 0) && (column <= fieldSize - 1))
            {
                return false;
            }
            return true;
        }
    }
}
