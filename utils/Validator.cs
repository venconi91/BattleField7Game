using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    public static class Validator
    {

        public static int[] checkStringForValidCoordinates(string inputCoordinates, int fieldSize)
        {

            string[] rowAndColumnSplit = inputCoordinates.Split(' ');

            int row;
            int column;

            if ((rowAndColumnSplit.Length) <= 0)
            {
                throw new IndexOutOfRangeException("Empty coordinates are not allowed");
            }

            bool canParseRow = int.TryParse(rowAndColumnSplit[0], out row);
            bool canParseCol = int.TryParse(rowAndColumnSplit[1], out column);

            if (!canParseRow)
            {
                throw new Exception("Can not parse row number by userInput");
            }
            if (!canParseCol)
            {
                throw new Exception("Can not parse col number by userInput");
            }

            bool isOutOfField = IsOutOfField(row, column, fieldSize);
            if (isOutOfField)
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
