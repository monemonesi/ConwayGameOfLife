using ConwayGameOfLife.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Tests
{
    [TestFixture]
    class GameOfLifeWorldTests
    {
        GameOfLifeWorld universe = new GameOfLifeWorld(10, 10);

        [Test]
        public void ShouldSetAllDeadCellsWhenInitialise()
        {
            int indexCell = 0;
            for (int row = 0; row < universe.Rows; row++)
            {
                for (int col = 0; col < universe.Columns; col++)
                {
                    Assert.AreEqual(CellState.Dead, universe.GridCells[indexCell].CurrentCellState);
                }
            }
        }

        [TestCase(0, 9, 9)]
        [TestCase(0, 0, 0)]
        [TestCase(9, 9, 99)]
        [TestCase(4, 3, 43)]
        [TestCase(1, 1, 11)]
        [TestCase(2, 2, 22)]
        public void GetCellByLocationShouldReturnCorrectCell(int row, int col, int expectedIndex)
        {
            Cell cell = universe.GetCellByLocation(row, col);

            Assert.AreEqual(expectedIndex, cell.IndexCell);
        }

        [TestCase(1, 1, 6)]
        [TestCase(2,2,12)]
        public void Simple_GetCellByLocationShouldReturnCorrectCell(int row, int col, int expectedIndex)
        {
            GameOfLifeWorld simpleUniverse = new GameOfLifeWorld(4, 5);

            Cell cell = simpleUniverse.GetCellByLocation(row, col);

            Assert.AreEqual(expectedIndex, cell.IndexCell);
        }

        [TestCase(-1, 11)]
        [TestCase(-1, -1)]
        [TestCase(11, 11)]
        [TestCase(10,10)]
        public void ShouldReturnNullWhenOutOfRange(int indexOutOfRangeR, int indexOutOfRangeC)
        {

            Cell cellToFind = universe.GetCellByLocation(indexOutOfRangeR, indexOutOfRangeC);

            Assert.IsNull(cellToFind);
        }

    }
}
