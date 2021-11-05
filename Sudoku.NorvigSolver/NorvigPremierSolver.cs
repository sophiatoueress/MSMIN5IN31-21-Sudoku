using Sudoku.Shared;
using System.Globalization;
using System.Text;
using System.Linq;

namespace Sudoku.NorvigSolver
{
    public  class NorvigPremierSolver : ISolverSudoku
    {

        

        public SudokuGrid Solve(SudokuGrid sorel)
        {
            var stringSudoku = sorel.Cells.Aggregate("",
                (strRows, row) => strRows + row.Aggregate("",
                    (strCells, cell) => strCells + cell.ToString(CultureInfo.InvariantCulture)));
            var dictSudoku = LinqSudokuSolver.parse_grid(stringSudoku);
            var dictSolution = LinqSudokuSolver.search(dictSudoku);
            var toReturn = new SudokuGrid();
            foreach (var strCellPair in dictSolution)
            {
                var rowIndex = strCellPair.Key[0] - 'A';
                var colIndex = strCellPair.Key[1] - '1';
                toReturn.Cells[rowIndex][colIndex] = int.Parse(strCellPair.Value, CultureInfo.InvariantCulture);
            }

            return toReturn;
        }

    }

    public class NorvigDeuxiemeSolver : ISolverSudoku
    {
        // besoin d'aide pour la conversion

        //public static Sudoku Solve(Sudoku S)
        //{
        //    if (S == null || S.is_solved())
        //    {
        //        return new Sudoku(S);
        //    }
        //    int k = S.least_count();
        //    Possible p = S.possible(k);
        //    for (int i = 1; i <= 9; i++)
        //    {
        //        if (p.is_on(i))
        //        {
        //            Sudoku S1 = new Sudoku(S);
        //            if (S1.assign(k, i))
        //            {
        //                if (Solve(S1))
        //                {
        //                    return S1;
        //                }
        //            }
        //        }
        //    }



        public SudokuGrid Solve(SudokuGrid sorel)
        {
            var stringSudoku = sorel.Cells.Aggregate("",
                (strRows, row) => strRows + row.Aggregate("",
                    (strCells, cell) => strCells + cell.ToString(CultureInfo.InvariantCulture)));
            var dictSudoku = LinqSudokuSolver.parse_grid(stringSudoku);
            var dictSolution = LinqSudokuSolver.search(dictSudoku);
            var toReturn = new SudokuGrid();
            foreach (var strCellPair in dictSolution)
            {
                var rowIndex = strCellPair.Key[0] - 'A';
                var colIndex = strCellPair.Key[1] - '1';
                toReturn.Cells[rowIndex][colIndex] = int.Parse(strCellPair.Value, CultureInfo.InvariantCulture);
            }

            return toReturn;
        }

    }


}
