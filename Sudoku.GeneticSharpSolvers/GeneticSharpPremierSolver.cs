using Sudoku.Shared;
using GeneticSharp.Domain;
using GeneticSharp.Extensions.Sudoku;
using GeneticSharp.Domain.Selections;
using GeneticSharp.Domain.Crossovers;
using GeneticSharp.Domain.Mutations;
using GeneticSharp.Domain.Populations;
using GeneticSharp.Domain.Terminations;
using GeneticSharp.Domain.Chromosomes;
using System.Linq;

namespace Sudoku.GeneticSharpSolvers
    {
        public class GeneticSharpPremierSolver : ISolverSudoku
        {
        private const int populationMinSize=100;
        private const int populationMaxSize=100;
        private const double fitnessThreshold=0;
        private const int generationNb=10;

        public SudokuGrid Solve(SudokuGrid s)
            {
                var sudoku = new SudokuBoard();

                for (int ridx=0; ridx<9;ridx++)
                {
                    for(int cidx = 0; cidx < 9; cidx++)
                    {
                        sudoku.SetCell(ridx, cidx, s.Cells[ridx][cidx]);
                    }
                }
               
                IChromosome chromosome = new SudokuPermutationsChromosome(sudoku);
                //var fitness = SudokuTestHelper.Eval(chromosome, sudoku, 50, 0, 10);
                var fitness = new SudokuFitness(sudoku);
                var selection = new EliteSelection();
                var crossover = new UniformCrossover();
                var mutation = new UniformMutation();

                var population = new Population(populationMinSize, populationMaxSize, chromosome);
                var ga = new GeneticAlgorithm(population, fitness, selection, crossover, mutation)
                {
                    Termination = new OrTermination(new ITermination[]
                    {
                    new FitnessThresholdTermination(fitnessThreshold),
                    new GenerationNumberTermination(generationNb)
                    })
                };

                ga.Start();

                var bestIndividual = ((ISudokuChromosome)ga.Population.BestChromosome);
                var solution = bestIndividual.GetSudokus().First();
            //return solutions.Max(solutionSudoku => fitness.Evaluate(solutionSudoku));


            var toReturn = s.CloneSudoku();

            for (int ridx = 0; ridx < 9; ridx++)
            {
                for (int cidx = 0; cidx < 9; cidx++)
                {
                    toReturn.Cells[ridx][cidx]=solution.GetCell(ridx,cidx);
                }
            }
            return toReturn ;

            }


        }


    }
         