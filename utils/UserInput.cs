using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class UserInput
    {
        public const int MinFieldSize = 2;
        public const int MaxFieldSize = 10;

        public static int ReadFieldSize()
        {
            int parsedFieldSize;

            while (true)
            {
                Console.WriteLine("Please Enter Valid Size Of The Field.");
                Console.Write("FieldSize = ");

                string userInput = Console.ReadLine();

                bool canParseInput = Int32.TryParse(userInput, out parsedFieldSize);

                if (canParseInput && parsedFieldSize >= MinFieldSize && parsedFieldSize <= MaxFieldSize)
                {
                    return parsedFieldSize;
                }
            }
        }

        public static int[] GetValidCoordinates(int fieldSize)
        {
            string inputCoordinates = Console.ReadLine();
            string[] rowAndColumnSplit = inputCoordinates.Split(' ');

            int[] coordinates = Validator.checkStringForValidCoordinates(inputCoordinates, fieldSize);

            return coordinates;
        }
    }
}
