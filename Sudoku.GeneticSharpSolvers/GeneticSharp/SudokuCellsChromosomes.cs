using System.Collections.Generic;
using System.Linq;
using GeneticSharp.Domain.Chromosomes;
using GeneticSharp.Domain.Randomizations;
using Sudoku.GeneticSharpSolvers;
using Sudoku.Shared;

namespace Sudoku.GeneticAlgorithmSolver
{
    /// <summary>
    /// This simple chromosome simply represents each cell by a gene with value between 1 and 9, accounting for the target mask if given
    /// </summary>
    public class SudokuCellsChromosome : ChromosomeBase, ISudokuChromosome
    {
        /// <summary>
        /// The target sudoku board to solve
        /// </summary>
        private readonly SudokuGrid _targetSudoku;

        public SudokuCellsChromosome() : this(null)
        {
        }

        /// <summary>
        /// Constructor that accepts a Sudoku to solve
        /// </summary>
        /// <param name="targetCore.Sudoku">the target sudoku to solve</param>
        public SudokuCellsChromosome(SudokuGrid targetSudoku) : base(81)
        {
            _targetSudoku = targetSudoku;
            for (int i = 0; i < Length; i++)
            {
                ReplaceGene(i, GenerateGene(i));
            }
        }

        /// <summary>
        /// Generates genes with digits for each index within the 81 Sudoku cells
        /// </summary>
        /// <param name="geneIndex"></param>
        /// <returns>a gene with a digit for the corresponding cell index</returns>
        public override Gene GenerateGene(int geneIndex)
        {
            var rowIndex = geneIndex / 9;
            var colIndex = geneIndex % 9;
            //If a target mask exist and has a digit for the cell, we use it.
            if (_targetSudoku != null && _targetSudoku.Cells[rowIndex][colIndex] != 0)
            {
                return new Gene(_targetSudoku.Cells[rowIndex][colIndex]);
            }
            var rnd = RandomizationProvider.Current;
            // otherwise we use a random digit.
            return new Gene(rnd.GetInt(1, 10));
        }

        public override IChromosome CreateNew()
        {
            return new SudokuCellsChromosome(_targetSudoku);
        }

        /// <summary>
        /// Builds a single Sudoku from the 81 genes
        /// </summary>
        /// <returns>A Sudoku board built from the 81 genes</returns>
        public IList<SudokuGrid> GetSudokus()
        {
            var cellsArray = GetGenes().Select(g => (int)g.Value).ToArray().ToJaggedArray(9);
            var sudoku = new SudokuGrid(){Cells = cellsArray };
            return new List<SudokuGrid>(new[] { sudoku });
        }
    }
}
