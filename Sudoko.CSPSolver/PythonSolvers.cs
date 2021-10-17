using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Python.Included;
using Python.Runtime;
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


    //public class Z3PythonDotNetSolver : PythonSolverBase
    //{

    //    public override SudokuGrid Solve(SudokuGrid s)
    //    {
    //        //System.Diagnostics.Debugger.Break();

    //        //For some reason, the Benchmark runner won't manage to get the mutex whereas individual execution doesn't cause issues
    //        //using (Py.GIL())
    //        //{
    //        // create a Python scope
    //        using (PyScope scope = Py.CreateScope())
    //        {
    //            // convert the Person object to a PyObject
    //            PyObject pySudoku = s.ToPython();

    //            // create a Python variable "person"
    //            scope.Set("sudoku", pySudoku);

    //            // the person object may now be used in Python
    //            string code = Resources.SelfCallSolver_py;
    //            scope.Exec(code);
    //            var result = scope.Get("solvedSudoku");
    //            var toReturn = result.As<SudokuGrid>();
    //            return toReturn;
    //        }
    //        //}

    //    }

    //}

    public class CSPPythonNativeSolver : PythonSolverBase
    {


        public override SudokuGrid Solve(SudokuGrid s)
        {

            //using (Py.GIL())
            //{
            // create a Python scope
            using (PyScope scope = Py.CreateScope())
            {
                // convert the Person object to a PyObject
                PyObject pyCells = s.Cells.ToPython();

                // create a Python variable "person"
                scope.Set("instance", pyCells);

                // the person object may now be used in Python
                string code = Resources.CSPSolver_py;
                scope.Exec(code);
                var result = scope.Get("r");
                var managedResult = result.As<int[][]>();
                //var convertesdResult = managedResult.Select(objList => objList.Select(o => (int)o).ToArray()).ToArray();
                return new SudokuGrid() { Cells = managedResult };
            }
            //}

        }

        protected override void InstallPythonComponents()
        {
            base.InstallPythonComponents();
            Installer.TryInstallPip();
    
            // TODO installer aima
            Installer.PipInstallModule("z3");
            Installer.PipInstallModule("z3-solver");
        }



    }


}
