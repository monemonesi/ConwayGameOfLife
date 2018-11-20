using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwayGameOfLife.Model
{
    public class LifeRules
    {
        public static CellState GetNextState(CellState currentState, int aliveNeighbours)
        {
            CellState nextState = currentState;

            switch (currentState)
            {
                case CellState.Alive:
                    if (aliveNeighbours < 2 || aliveNeighbours > 3)
                        nextState = CellState.Dead;
                    break;
                case CellState.Dead:
                    if (aliveNeighbours == 3)
                        nextState = CellState.Alive;
                    break;
                default:
                    break;
            }

            return nextState;
        }
    }
}
