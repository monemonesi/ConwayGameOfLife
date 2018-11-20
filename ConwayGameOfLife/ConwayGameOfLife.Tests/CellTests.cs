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
    public class CellTests
    {
        [TestCase(1,1)]
        public void CreateDeadCell(int row,int col)
        {
            Cell cell = new Cell(row, col);

            CellState currentState = cell.CurrentCellState;

            Assert.AreEqual(CellState.Dead, currentState);
        }

        [TestCase(1, 1,3, CellState.Alive)]
        public void CreateCellWithSpecificCellState(int row, int col, int index, CellState cellState)
        {
            Cell cell = new Cell(row, col, index, cellState);

            CellState currentState = cell.CurrentCellState;

            Assert.AreEqual(cellState, currentState);
        }

        [Test]
        public void CreateDeadCellFromIndex()
        {
            Cell cell = new Cell(1,1,2);
            CellState currentState = cell.CurrentCellState;

            Assert.AreEqual(CellState.Dead, currentState);
        }

        //[TestCase(1, CellState.Alive)]
        //[TestCase(1, CellState.Dead)]
        //[TestCase(0, CellState.Alive)]
        //[TestCase(0, CellState.Dead)]
        //public void CreateCellWithSpecificCellStateFromIndex(int indexCell, CellState cellState)
        //{
        //    Cell cell = new Cell(indexCell, cellState);

        //    CellState currentState = cell.CurrentCellState;

        //    Assert.AreEqual(cellState, currentState);
        //}


    }
}
