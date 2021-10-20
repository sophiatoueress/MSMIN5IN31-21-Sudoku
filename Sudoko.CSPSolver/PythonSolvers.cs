using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Python.Included;
using Python.Runtime;
using Sudoko.CSPSolver;
using Sudoku.Shared;

namespace Sudoku.CSPSolvers
{

    public abstract class PythonSolverBase : ISolverSudoku
    {

        public PythonSolverBase()
        {
            SetupPython();
        }

        protected void SetupPython()
        {
            InstallPythonComponents();
            InitializePythonComponents();

        }

        protected virtual void InstallPythonComponents()
        {
            Installer.SetupPython().Wait();
        }

        protected virtual void InitializePythonComponents()
        {
            PythonEngine.Initialize();
            dynamic sys = PythonEngine.ImportModule("sys");
            Console.WriteLine("Python version: " + sys.version);
        }



        public abstract SudokuGrid Solve(SudokuGrid s);

    }



    public class CSPPythonPipSolver : PythonSolverBase
    {


        public override SudokuGrid Solve(SudokuGrid s)
        {

            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyScope scope = Py.CreateScope())
            {

                //Create one liner string sudoku as consumed by the pip Sudoku class
                var strSudoku = s.Cells.Aggregate("",
                    (sRows, row) => sRows + row.Aggregate("",
                        (sCells, cell) => sCells + cell.ToString(CultureInfo.InvariantCulture)));
                // convert the string object to a PyObject

                PyObject pyCells = strSudoku.ToPython();

                // create a Python variable "puzzle" according to the python script
                scope.Set("puzzle", pyCells);

                // the puzzle object may now be used in Python
                string code = Resources.CspAimaPipSolver_py;
                scope.Exec(code);
                var pySolution = scope.Get("solution");
                var managedSolution = pySolution.As<int[][]>();
                var toReturn = new SudokuGrid(){Cells = managedSolution };
                return toReturn;
            }
            //}

        }

        protected override void InstallPythonComponents()
        {
            base.InstallPythonComponents();
            Installer.TryInstallPip();
    
            Installer.PipInstallModule("aima3");
            
        }


    }

    public class CSPPythonPipSolver2 : CSPPythonPipSolver
    {
        //Solver with basic AIMA Pip parameters

        public override SudokuGrid Solve(SudokuGrid s)
        {

            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyScope scope = Py.CreateScope())
            {

                //Create one liner string sudoku as consumed by the pip Sudoku class
                var strSudoku = s.Cells.Aggregate("",
                    (sRows, row) => sRows + row.Aggregate("",
                        (sCells, cell) => sCells + cell.ToString(CultureInfo.InvariantCulture)));
                // convert the string object to a PyObject

                PyObject pyCells = strSudoku.ToPython();

                // create a Python variable "puzzle" according to the python script
                scope.Set("puzzle", pyCells);

                // the puzzle object may now be used in Python
                string code = Resources.CSPAimaPipSolver2;
                scope.Exec(code);
                var pySolution = scope.Get("solution");
                var managedSolution = pySolution.As<int[][]>();
                var toReturn = new SudokuGrid() { Cells = managedSolution };
                return toReturn;
            }
            //}

        }

    }

    public class CSPPythonPipSolver3 : CSPPythonPipSolver
    {
        //Solver to evaluate the influence of the mrv (minimum-remaining-values heuristic) parameter

        public override SudokuGrid Solve(SudokuGrid s)
        {

            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyScope scope = Py.CreateScope())
            {

                //Create one liner string sudoku as consumed by the pip Sudoku class
                var strSudoku = s.Cells.Aggregate("",
                    (sRows, row) => sRows + row.Aggregate("",
                        (sCells, cell) => sCells + cell.ToString(CultureInfo.InvariantCulture)));
                // convert the string object to a PyObject

                PyObject pyCells = strSudoku.ToPython();

                // create a Python variable "puzzle" according to the python script
                scope.Set("puzzle", pyCells);

                // the puzzle object may now be used in Python
                string code = Resources.CSPAimaPipSolver3;
                scope.Exec(code);
                var pySolution = scope.Get("solution");
                var managedSolution = pySolution.As<int[][]>();
                var toReturn = new SudokuGrid() { Cells = managedSolution };
                return toReturn;
            }
            //}

        }

    }

    public class CSPPythonPipSolver4 : CSPPythonPipSolver
    {
        //Solver to evaluate the influence of the lcv (least constraining-values heursitic) parameter

        public override SudokuGrid Solve(SudokuGrid s)
        {

            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyScope scope = Py.CreateScope())
            {

                //Create one liner string sudoku as consumed by the pip Sudoku class
                var strSudoku = s.Cells.Aggregate("",
                    (sRows, row) => sRows + row.Aggregate("",
                        (sCells, cell) => sCells + cell.ToString(CultureInfo.InvariantCulture)));
                // convert the string object to a PyObject

                PyObject pyCells = strSudoku.ToPython();

                // create a Python variable "puzzle" according to the python script
                scope.Set("puzzle", pyCells);

                // the puzzle object may now be used in Python
                string code = Resources.CSPAimaPipSolver4;
                scope.Exec(code);
                var pySolution = scope.Get("solution");
                var managedSolution = pySolution.As<int[][]>();
                var toReturn = new SudokuGrid() { Cells = managedSolution };
                return toReturn;
            }
            //}

        }

    }

    public class CSPPythonPipSolver5 : CSPPythonPipSolver
    {
        //Solver to evaluate the influence of the mac (Maintain arc consistency AC-3) parameter

        public override SudokuGrid Solve(SudokuGrid s)
        {

            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyScope scope = Py.CreateScope())
            {

                //Create one liner string sudoku as consumed by the pip Sudoku class
                var strSudoku = s.Cells.Aggregate("",
                    (sRows, row) => sRows + row.Aggregate("",
                        (sCells, cell) => sCells + cell.ToString(CultureInfo.InvariantCulture)));
                // convert the string object to a PyObject

                PyObject pyCells = strSudoku.ToPython();

                // create a Python variable "puzzle" according to the python script
                scope.Set("puzzle", pyCells);

                // the puzzle object may now be used in Python
                string code = Resources.CSPAimaPipSolver5;
                scope.Exec(code);
                var pySolution = scope.Get("solution");
                var managedSolution = pySolution.As<int[][]>();
                var toReturn = new SudokuGrid() { Cells = managedSolution };
                return toReturn;
            }
            //}

        }

    }

    public class CSPPythonPipSolver6 : CSPPythonPipSolver
    {
        //Solver to evaluate the influence of the forward_checking parameter (Prune neighbor values inconsistent with var=value)

        public override SudokuGrid Solve(SudokuGrid s)
        {

            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyScope scope = Py.CreateScope())
            {

                //Create one liner string sudoku as consumed by the pip Sudoku class
                var strSudoku = s.Cells.Aggregate("",
                    (sRows, row) => sRows + row.Aggregate("",
                        (sCells, cell) => sCells + cell.ToString(CultureInfo.InvariantCulture)));
                // convert the string object to a PyObject

                PyObject pyCells = strSudoku.ToPython();

                // create a Python variable "puzzle" according to the python script
                scope.Set("puzzle", pyCells);

                // the puzzle object may now be used in Python
                string code = Resources.CSPAimaPipSolver6;
                scope.Exec(code);
                var pySolution = scope.Get("solution");
                var managedSolution = pySolution.As<int[][]>();
                var toReturn = new SudokuGrid() { Cells = managedSolution };
                return toReturn;
            }
            //}

        }

    }


}
