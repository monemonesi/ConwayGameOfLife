using ConwayGameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.ViewModel
{

    public class GameOfLifeVM
    {
        private int initialTotalRows = 20;
        private int initialTotalColumns = 25;

        public GameOfLifeWorld GameOfLifeWorld { get; set; }

        #region constructor
        public GameOfLifeVM()
        {

            GameOfLifeWorld = new GameOfLifeWorld(initialTotalRows, initialTotalColumns);

            //initialize Commands
        }
        #endregion
    }
}
