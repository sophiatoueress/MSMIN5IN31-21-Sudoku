using System;
using System.Text;
using Keras.Models;
using Sudoku.Shared;

namespace Sudoku.NeuralNetworkSolver
{
	public class NeuralNetworkSolver:ISolverSudoku
	{
        private const string modelPath = @"Models\sudoku.model";
		private static BaseModel model = NeuralNetHelper.LoadModel(modelPath);

        public SudokuGrid Solve(SudokuGrid s)
		{
			return NeuralNetHelper.SolveSudoku(s, model);
		}

        static string GetLocalPath(string relativePath)
        {
            return System.IO.Path.Combine(Environment.CurrentDirectory, relativePath);
        }
	}
}