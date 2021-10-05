namespace Sudoku.Shared
{
    public class EmptySolver : ISolverSudoku
    {
        public SudokuGrid Solve(SudokuGrid s)
        {
            return s.CloneSudoku();
        }
    }
}