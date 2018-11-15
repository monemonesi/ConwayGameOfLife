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
        [Test]
        public void ShouldSetAllDeadCellsWhenInitialise()
        {
            GameOfLifeWorld universe = new GameOfLifeWorld(10, 10);
            int indexCell = 0;
            for (int row = 0; row < universe.Rows; row++)
            {
                for (int col = 0; col < universe.Columns; col++)
                {
                    Assert.AreEqual(CellState.Dead, universe.GridCells[indexCell].CurrentCellState);
                }
            }
        }
    }
}
