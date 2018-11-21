﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ConwayGameOfLife.Model
{
    public class GameOfLifeWorld : ObservableBase
    {
        

        private ObservableCollection<Cell> _gridCells;
        private bool _isGameRunning;

        public int TotalRows { get; set; }
        public int TotalColumns { get; set; }

        public Dictionary<int,IList<Cell>> Neighbours { get; set; }

        public ObservableCollection<Cell> GridCells
        {
            get { return _gridCells; }
            private set { _gridCells = value; }
        }

        public bool IsGameRunning
        {
            get { return _isGameRunning; }
            set
            {
                _isGameRunning = value;
                OnNotifyPropertyChanged();
            }
        }


        #region Constructur
        public GameOfLifeWorld(int numberOfRows, int numberOfCols)
        {
            TotalRows = numberOfRows;
            TotalColumns = numberOfCols;

            GridCells = new ObservableCollection<Cell>();

            Neighbours = new Dictionary<int, IList<Cell>>();

            InitialiseGameOfLifeWorld();
            DefineCellsNeighbours();
        }
        #endregion

        #region methods

        private void InitialiseGameOfLifeWorld()
        {
            int index = 0;
            for (int row = 0; row < TotalRows; row++)
            {
                for (int col = 0; col < TotalColumns; col++)
                {
                    GridCells.Add(new Cell(row, col, index));
                    index++;
                }
            }
        }

        private void DefineCellsNeighbours()
        {
            foreach (Cell cell in GridCells)
            {
                int cellRow = cell.RowIndex;
                int cellCol = cell.ColumnIndex;
                int CellId = cell.IndexCell;

                IList<Cell> cellNeighbours = new List<Cell>();

                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        Cell possibleNeighbour = GetCellByLocation(cellRow + i, cellCol + j);
                        bool isValidNeighbour = CheckTheNeighbour(possibleNeighbour, i , j);
                        if (isValidNeighbour)
                        {
                            cellNeighbours.Add(possibleNeighbour);
                        }
                    }
                }
                Neighbours.Add(CellId, cellNeighbours);
            }
        }

        private bool CheckTheNeighbour(Cell possibleNeighbour, int relativeRow, int relativeCol)
        {
            if (possibleNeighbour == null) // out of the universe
                return false;
            if (relativeRow == 0 && relativeCol == 0)//possible neighbour is my cell
                return false;

            return true;
        }

        public Cell GetCellByLocation(int findRow, int findCol)
        {
            if (findRow >= TotalRows || findRow < 0)
                return null;
            if (findCol >= TotalColumns || findCol < 0)
                return null;
            int indexCell = findRow * TotalColumns + findCol;
            return GridCells[indexCell];
        }

        public IList<Cell> GetNeighboursOfCell(int idCell)
        {
            IList<Cell> associatedNeighbours = new List<Cell>();
            if (Neighbours.TryGetValue(idCell, out associatedNeighbours))
            {
                return associatedNeighbours;
            }
            return null;
        }

        public IList<CellState> GetNeighboursState(int idCell)
        {
            IList<CellState> neighboursState = new List<CellState>();
            IList<Cell> associatedNeighbours = new List<Cell>();
            associatedNeighbours = GetNeighboursOfCell(idCell);

            foreach (Cell neighbour in associatedNeighbours)
            {
                neighboursState.Add(neighbour.CurrentCellState);
            }

            return neighboursState;
        }

        public int GetAliveNeighbours(int idCell)
        {
            int aliveNeighbours = 0;

            IList<Cell> associatedNeighbours = new List<Cell>();
            associatedNeighbours = GetNeighboursOfCell(idCell);

            foreach (Cell neighbour in associatedNeighbours)
            {
                bool isAlive = (neighbour.CurrentCellState == CellState.Alive);
                if (isAlive)
                {
                    aliveNeighbours++;
                }
            }
            return aliveNeighbours;
        }

        public void ToggleCellState(Point point, double gridWidthPixels, double gridHeightPixels)
        {
            bool isInGrid = gridWidthPixels > 0 && gridHeightPixels > 0;
            bool canToggle = (point != null && IsGameRunning == false && isInGrid);

            if (canToggle)
            {
                //find the cell to toggle
                int colLoc = (int)(point.X / gridWidthPixels) * TotalColumns;
                int rowLoc = (int)(point.Y / gridHeightPixels) * TotalRows;

                Cell cellToToggle = GetCellByLocation(rowLoc, colLoc);

                if(cellToToggle != null)
                {
                    if (cellToToggle.CurrentCellState == CellState.Dead)
                        cellToToggle.CurrentCellState = CellState.Alive;
                    else if (cellToToggle.CurrentCellState == CellState.Alive)
                        cellToToggle.CurrentCellState = CellState.Dead;
                }
            
            }

        }

        #endregion
    }
}
