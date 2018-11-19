using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Model
{
    public class GameOfLifeWorld : ObservableBase
    {
        

        private ObservableCollection<Cell> _gridCells;
        private bool _isGameRunning;

        public ObservableCollection<Cell> GridCells
        {
            get { return _gridCells; }
            private set { _gridCells = value; }
        }
        public int TotalRows { get; set; }
        public int TotalColumns { get; set; }
        //private int _totalRows;

        //public int TotalRows
        //{
        //    get { return _totalRows; }
        //    set
        //    {
        //        _totalRows = value;
        //        OnNotifyPropertyChanged();
        //    }
        //}

        //private int _totalColumns;

        //public int TotalColumns
        //{
        //    get { return _totalColumns; }
        //    set
        //    {
        //        _totalColumns = value;
        //        OnNotifyPropertyChanged();
        //    }
        //}




        public Dictionary<int, IList<int>> NeighboursId { get; set; }

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
            NeighboursId = new Dictionary<int, IList<int>>();

            InitialiseGameOfLifeWorld();

            //DefineCellsNeighbours();
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

            for (int idCell = 0; idCell < GridCells.Count; idCell++)
            {
                Cell cellToCheck = new Cell(GridCells[idCell]);
                IList<int> neighboursCellIds = new List<int>();

                int cellRow = cellToCheck.RowIndex;
                int cellCol = cellToCheck.ColumnIndex;

                for (int j = -1; j < 1; j++)
                {
                    for (int k = -1; k < 1; k++)
                    {
                        if (j == 0 && k == 0)
                            return; // do not consider the same cell

                        int rowToExplore = cellRow + j;
                        int colToExplore = cellCol + j;

                        //Cell neighbour = new Cell(this.GetCellByLocation(rowToExplore, colToExplore));

                        //if( neighbour != null)
                        //{
                        //    neighboursCellIds.Add(neighbour.IndexCell);
                        //}
                        
                    }
                }

                NeighboursId.Add(idCell, neighboursCellIds);
            }//END forEachCell
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

        public IList<int> GetNeighboursOfCell(int idCell)
        {
            return NeighboursId[idCell];
        }
        #endregion
    }
}
