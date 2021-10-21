using System;
using System.Collections.Generic;
using System.Text;
using SudokuTools;
using Sudoku.Shared;

namespace SwarmIntelligenceSolver
{
    public class SwarmIntelligenceSimpleSolver : ISolverSudoku
    {
        private static EvolutionSolution _evo;
        private static IDisplayMatrix _disp;
        private static EvolutionStats _stats;

        public SudokuGrid Solve(SudokuGrid sudokuGrid)
        {
            int mo = 100;
            int mep = 5000;
            int me = 20;
            double worker = 0.90;
            int maxAge = 500;
            _disp = new ConsoleDisplayMatrix();
            _stats = new EvolutionStats();
            _evo = new EvolutionSolution(_disp, _stats);
            int[][] result = _evo.SolveB4ExtinctCount_Async(sudokuGrid.Cells, mo, mep, me, worker, maxAge).Result;
            SudokuGrid toReturn = new SudokuGrid() { Cells = result };
            return toReturn;
            

        }
    }
}
