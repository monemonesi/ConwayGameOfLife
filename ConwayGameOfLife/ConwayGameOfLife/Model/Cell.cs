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

        public Cell(int _row, int _col, CellState _cellState)
        {
            RowIndex = _row;
            ColumnIndex = _col;
            CurrentCellState = _cellState;
        }

        public Cell(int _row, int _col,int idCell)
        {
            RowIndex = _row;
            ColumnIndex = _col;
            IndexCell =idCell;
            CurrentCellState = CellState.Dead;
        }

        //public Cell(int idCell, CellState cellState)
        //{
        //    IndexCell = idCell;
        //    CurrentCellState = cellState;
        //}

        public Cell(Cell cellToCopy)
        {
            IndexCell = cellToCopy.IndexCell;
            CurrentCellState = cellToCopy.CurrentCellState;
            RowIndex = cellToCopy.RowIndex;
            ColumnIndex = cellToCopy.ColumnIndex;
            //NeighBoursIndex = cellToCopy.NeighBoursIndex;
        }
        #endregion



    }
}
