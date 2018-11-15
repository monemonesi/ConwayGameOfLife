//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ConwayGameOfLife.Model
//{
//    /// <summary>
//    /// Represent the universe in a particolar moment
//    /// </summary>
//    public class Universe
//    {
//        private readonly Cell[,] universeCells;

//        public int Rows { get; set; }
//        public int Columns { get; set; }

//        public Universe(int _rows, int _cols)
//        {
//            Rows = _rows;
//            Columns = _cols;
//            universeCells = new Cell[Rows, Columns];

//            InitialiseUniverse();
//        }

//        private void InitialiseUniverse()
//        {
//            for (int row = 0; row < Rows; row++)
//            {
//                for (int col = 0; col < Columns; col++)
//                {
//                    universeCells[row, col] = new Cell(row, col, CellState.Dead);
//                }
//            }
//        }

//        public Cell GetCell(int findRow, int findCol)
//        {

//            if (findRow >= Rows || findRow < 0)
//                return null;
//            if (findCol >= Columns || findCol < 0)
//                return null;
//            return universeCells[findRow, findCol];
//        }
//    }
//}
