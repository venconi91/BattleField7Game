using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleFieldNamespace
{
    class Field2DFactory
    {
        public static class Factory
        {
            public static IField Get(string shape,int[] size)
            {
                switch (shape)
                {
                    case "rectangle":
                        return new SquareField(size[0]);
                    case "circle":
                        //return new Circle();
                    case "triangle":
                        //return new Triangle();
                        break;
                    default:
                        break;
                }

                return new SquareField(size[0]);
            }
        }
    }
}
