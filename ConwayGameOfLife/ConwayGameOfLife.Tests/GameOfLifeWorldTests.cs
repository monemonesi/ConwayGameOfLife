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
    class GameOfLifeWorldTests
    {
        GameOfLifeWorld MediumSizeUniverse = new GameOfLifeWorld(10, 10);
        GameOfLifeWorld simpleUniverse = new GameOfLifeWorld(4, 5);

        [Test]
        public void ShouldSetAllDeadCellsWhenInitialise()
        {
            int indexCell = 0;
            for (int row = 0; row < MediumSizeUniverse.TotalRows; row++)
            {
                for (int col = 0; col < MediumSizeUniverse.TotalColumns; col++)
                {
                    Assert.AreEqual(CellState.Dead, MediumSizeUniverse.GridCells[indexCell].CurrentCellState);
                }
            }
        }

        [Test]
        public void Initialize_ProducetheRightNumberOfTests()
        {
            int universeSize = simpleUniverse.GridCells.Count;
            int expectedSize = 20;

            Assert.AreEqual(expectedSize, universeSize);
        }

        [TestCase(0, 9, 9)]
        [TestCase(0, 0, 0)]
        [TestCase(9, 9, 99)]
        [TestCase(4, 3, 43)]
        [TestCase(1, 1, 11)]
        [TestCase(2, 2, 22)]
        public void GetCellByLocationShould_ReturnCorrectCell(int row, int col, int expectedIndex)
        {
            Cell cell = MediumSizeUniverse.GetCellByLocation(row, col);

            Assert.AreEqual(expectedIndex, cell.IndexCell);
        }

        [TestCase(1, 1, 6)]
        [TestCase(2, 2, 12)]
        [TestCase(0, 0, 0)]
        [TestCase(3, 4, 19)]
        public void Simple_GetCellByLocation_ShouldReturnCorrectCell(int row, int col, int expectedIndex)
        {


            Cell cell = simpleUniverse.GetCellByLocation(row, col);

            Assert.AreEqual(expectedIndex, cell.IndexCell);
        }

        [TestCase(-1, 11)]
        [TestCase(-1, -1)]
        [TestCase(11, 11)]
        [TestCase(10, 10)]
        public void GetCellByLocation_ShouldReturnNullWhenOutOfRange(int indexOutOfRangeR, int indexOutOfRangeC)
        {

            Cell cellToFind = MediumSizeUniverse.GetCellByLocation(indexOutOfRangeR, indexOutOfRangeC);

            Assert.IsNull(cellToFind);
        }

        [TestCase(0, new int[] {1,5,6})]
        [TestCase(4, new int[] {3,8,9})]
        [TestCase(15, new int[] {10,11,16 })]
        [TestCase(19, new int[] { 13,14,18})]
        [TestCase(6, new int[] { 0, 1, 2, 5, 7, 10, 11, 12 })]
        public void GetNeighboursIndex_ShouldAssignCorrectNeighbours
            (int idCell, int[] expectedNeighbours)
        {
            IList<Cell> neighbours = new List<Cell>();
            neighbours = simpleUniverse.GetNeighboursOfCell(idCell);

            IList<int> neighboursId = new List<int>();
            foreach (Cell cell in neighbours)
            {
                neighboursId.Add(cell.IndexCell);
            }

            Assert.AreEqual(expectedNeighbours, neighboursId);
        }

        [TestCase(0, new CellState[] {CellState.Dead, CellState.Dead, CellState.Dead })]
        public void GetNeighboursState_ShouldReturnTheCorrectStateOfNeighbours
            (int idCell, CellState[] expectedNeighboursState)
        {
            IList<CellState> neighboursState = new List<CellState>();
            neighboursState = simpleUniverse.GetNeighboursState(idCell);

            Assert.AreEqual(expectedNeighboursState, neighboursState);
        }

        [TestCase(0,0)]
        public void GetLivingNeighbours_ShouldReturnZeroWheTheGameStarts
            (int idCell, int expectedAliveNeighbours)
        {
            int AliveNeighbours = simpleUniverse.GetNumberOfAliveNeighbours(idCell);

            Assert.AreEqual(expectedAliveNeighbours, AliveNeighbours);
        }


    }
}
