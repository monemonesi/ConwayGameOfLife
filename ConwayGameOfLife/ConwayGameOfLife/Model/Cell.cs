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
        public int Row { get; set; }
        public int Column { get; set; }

        #region Constructors
        public Cell(int _row, int _col)
        {
            Row = _row;
            Column = _col;
            CurrentCellState = CellState.Dead;
        }

        public Cell(int _row, int _col,CellState _cellState)
        {
            Row = _row;
            Column = _col;
            CurrentCellState = _cellState;
        }
        #endregion

        public CellState CurrentCellState
        {
            get { return _currentCellState; }
            set
            {
                _currentCellState = value;
                OnNotifyPropertyChanged();
            }
        }

    }
}
