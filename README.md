# MSMIN5IN31-21-Sudoku
Bienvenue sur le d�p�t du TP Sudoku.

Chaque groupe est invit� � cr�er un Fork de ce d�p�t principal muni d'un compte sur Github, travailler sur ce fork au sein du groupe, par le biais de validations, de push sur le server, et de pulls/tirages sur les machines locales des utilisateurs du groupe habilit�s sur le fork. Une fois le travail effectu� et remont� sur le fork, une pull-request sera cr��e depuis le fork vers le d�p�t principal pour fusion et �valuation.

Le fichier de solution "Sudoku.sln" constitue l'environnement de base du travail et s'ouvre dans Visual Studio Community (attention � bien ouvrir la solution et ne pas rester en "vue de dossier").
En l'�tat, la solution contient:
- Un r�pertoire Puzzles contenant 3 fichiers de Sudokus de difficult�s diff�rentes
- Un projet Sudoku.Shared: il consitue la librairie de base de l'application et fournit la d�finition de la classe repr�sentant un Sudoku (SudokuGrid) et l'interface � impl�menter par les solvers de sudoku (ISolverSudoku).
- Un projet Sudoku.Z3Solvers qui fournit plusieurs exemples de solvers utilisant la librairie z3 gr�ce au package Nuget correspondant, et qui illustre �galement l'utilisation de Python depuis le langage c# via  Python.Net gr�ce aux packages Nuget correspondants.
- Un projet Sudoku.Benchmark de Console permettant de tester les solvers de Sudoku de fa�on individuels ou dans le cadre d'un Benchmark comparatif. Ce projet r�f�rence les projets de solvers, et c'est celui que vous devez lancer pour tester votre code.

Les groupes de travail sont invit�s � �jouter � la solution leur propre projet de librairie sur le mod�le du projet z3 en exemple.

https://data-notes.co/biologically-inspired-ai-differential-evolution-particle-swarm-optimization-and-firefly-e8d953497978

https://www.sciencedirect.com/science/article/pii/S0020025516320904

https://dev.heuristiclab.com/trac.fcgi/wiki/Features

https://github.com/pixelsyndicate/Sudoku_Evolution_Solution

https://github.com/fisenkodv/sudoku-combinatorial-evolution-solver

https://docs.microsoft.com/en-us/archive/msdn-magazine/2016/november/test-run-solving-sudoku-using-combinatorial-evolution

https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.parallelloopstate.break?redirectedfrom=MSDN&view=net-5.0#System_Threading_Tasks_ParallelLoopState_Break