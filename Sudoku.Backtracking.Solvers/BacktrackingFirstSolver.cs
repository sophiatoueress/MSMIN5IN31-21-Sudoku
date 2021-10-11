using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Shared;

namespace Sudoku.Backtracking.Solvers
{
   public class BacktrackingFirstSolver : ISolverSudoku
    {
        public SudokuGrid Solve(SudokuGrid s)
        {

            Backtrack(s, 0, 0);
            return s;
        }

        public bool Backtrack(SudokuGrid s,int x, int y)
        {
            if (x==8 && y ==8)
            {
                return true;
            }
            if (x > 8)
            {
                return Backtrack(s, 0, y + 1);
            }
            int[] possibilies = s.GetPossibilities(x, y);
            foreach (int i in possibilies)
            {
                s.Cells[x][y] = i;
                if (Backtrack(s,x+1,y))
                {
                    return true;
                }
            }
            return false;
        }


    }
}
