using System;
using System.Collections.Generic;
using System.Text;
using Sudoku.Shared;
using Kermalis.SudokuSolver.Core;

namespace Sudoku.HumanTechnique
{
    public class HumanTechniquePremierSolver:ISolverSudoku
    {
        private Solver _solver;
        public SudokuGrid Solve(SudokuGrid s)
        {
            Puzzle p = ConvertSudokuGridToPuzzle(s);

            return s;
        }

        public Puzzle ConvertSudokuGridToPuzzle(SudokuGrid s)
        {
            String tempGrid = s.ToString().Replace("0", "-").Replace(".", "-");

            int[][] board = new int [9][];
            int l = 0;

            for (int i = 0; i < tempGrid.Length; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    board[i][j] = tempGrid[l];
                    l++;
                }
            }

            Puzzle p = new Puzzle(board, false);

            return p;
        }


    }
}
