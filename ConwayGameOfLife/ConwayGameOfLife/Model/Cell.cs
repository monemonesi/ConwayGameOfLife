using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Model
{
    public class Cell : ObservableBase
    {
        private CellState _currentCellState;

        public CellState CurrentCellState
        {
            get { return _currentCellState; }
            set
            {
                _currentCellState = value;
                OnNotifyPropertyChanged();
            }
        }
        public int RowIndex { get; set; }
        public int ColumnIndex { get; set; }
        public int IndexCell { get; set; }
        //public List<int> NeighBoursIndex { get; set; }


        #region Constructors
        public Cell(int _row, int _col)
        {
            RowIndex = _row;
            ColumnIndex = _col;
            CurrentCellState = CellState.Dead;
        }

        public Cell(int _row, int _col, int idCell, CellState _cellState)
        {
            RowIndex = _row;
            ColumnIndex = _col;
            IndexCell = idCell;
            CurrentCellState = _cellState;
        }

        public Cell(int _row, int _col, int idCell)
            : this(_row, _col, idCell, CellState.Dead)
        {
        }

        public Cell(Cell cellToCopy) :
            this(cellToCopy.RowIndex, cellToCopy.ColumnIndex,cellToCopy.IndexCell, cellToCopy._currentCellState)
        {
        }
        #endregion



    }
}
