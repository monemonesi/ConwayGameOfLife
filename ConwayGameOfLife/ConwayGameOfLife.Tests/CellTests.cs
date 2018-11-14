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
        [TestCase(1,1)]
        public void CreateDeadCell(int row,int col)
        {
            Cell cell = new Cell(row, col);

            CellState currentState = cell.CurrentCellState;


            Assert.AreEqual(CellState.Dead, currentState);
        }

        [TestCase(1, 1, CellState.Alive)]
        public void CreateCellWithSpecificCellState(int row, int col, CellState cellState)
        {
            Cell cell = new Cell(row, col, cellState);

            CellState currentState = cell.CurrentCellState;


            Assert.AreEqual(cellState, currentState);
        }
    }
}
