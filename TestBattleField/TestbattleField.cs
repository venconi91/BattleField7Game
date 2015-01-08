using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BattleFieldNamespace;

namespace TestBattleField
{
    [TestClass]
    public class TestbattleField
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckForStringInputShouldThrowException()
        {
            Validator.checkStringForValidCoordinates("asdf 5", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckInputForEmptyString()
        {
            Validator.checkStringForValidCoordinates("", 5);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void CheckForOutOFRangeExecption()
        {
            Validator.checkStringForValidCoordinates("20 10", 5);
        }

        [TestMethod]
        public void TestMaxNumberOfMines()
        {
            SquareField sf = new SquareField(5);

            int currentNumberOfMines = sf.MineCounter;
            double maxNumberOfMines = 0.3 * 5 * 5;

            Assert.IsTrue(currentNumberOfMines > maxNumberOfMines);

        }

        [TestMethod]
        public void TestMinNumberOfMinesShouldReturnTrue()
        {
            SquareField sf = new SquareField(5);

            int currentNumberOfMines = sf.MineCounter;
            double minNumberOfMines = 0.15 * 5 * 5;

            Assert.IsTrue(currentNumberOfMines > minNumberOfMines);

        }
    }
}
