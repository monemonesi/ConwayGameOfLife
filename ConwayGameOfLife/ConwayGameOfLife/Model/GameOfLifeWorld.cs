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
        public int Rows { get; set; }
        public int Columns { get; set; }


        public ObservableCollection<Cell> GridCells
        {
            get { return _gridCells; }
            set { _gridCells = value; }
        }


        public GameOfLifeWorld(int numberOfRows, int numberOfCols)
        {
            Rows = numberOfRows;
            Columns = numberOfCols;
            InitialiseGameOfLifeWorld();
        }

        private void InitialiseGameOfLifeWorld()
        {
            GridCells = new ObservableCollection<Cell>();
            int index = 0;
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    GridCells.Add(new Cell(index));
                    index++;
                }
            }
        }

        public Cell GetCellByLocation(int findRow, int findCol)
        {
            if (findRow >= Rows || findRow < 0)
                return null;
            if (findCol >= Columns || findCol < 0)
                return null;
            int indexCell = findRow * Columns + findCol;
            return GridCells[indexCell];
        }
    }
}
