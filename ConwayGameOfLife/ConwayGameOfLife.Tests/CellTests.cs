﻿using ConwayGameOfLife.Model;
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
    }
}
