using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Shared;


namespace Sudoku.ORToolsSolvers
{
   public class ORToolsSimpleSolver:ISolverSudoku
    {
        public SudokuGrid Solve(SudokuGrid s)
        {
            return s;
        }
    }
}
