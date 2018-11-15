//using ConwayGameOfLife.Model;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConwayGameOfLife.Tests
//{
//    [TestFixture]
//    class UniverseTests
//    {
//        [Test]
//        public void ShouldSetAllDeadCellsWhenInitialise()
//        {
//            Universe universe = new Universe(10, 10);

//            for (int row = 0; row < universe.Rows; row++)
//            {
//                for (int col = 0; col < universe.Columns; col++)
//                {
//                    Assert.AreEqual(CellState.Dead, universe.GetCell(row, col).CurrentCellState);
//                }
//            }
//        }

//        [TestCase(-1,11)]
//        [TestCase(-1,-1)]
//        [TestCase(11,11)]   
//        public void ShouldReturnNullWhenOutOfRange(int indexOutOfRangeR, int indexOutOfRangeC)
//        {
//            Universe universe = new Universe(5, 5);

//            Cell cellToFind = universe.GetCell(indexOutOfRangeR, indexOutOfRangeC);

//            Assert.IsNull(cellToFind);
//        }

//    }
//}
