using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class Puzzle
    {
        /*  -------Puzzle-------
         * This class builds 9 x 9 Sudoku puzzles
         * Type Puzzle will be used as a member of PuzzleManager
         */

        private int[,] _puzzleSolved = new int[9, 9];
        private int[,] _puzzleStart = new int[9, 9];
        private int _difficultyLevel;

        public Puzzle(int difficultyLevel)
        {
            _difficultyLevel = difficultyLevel;
            _puzzleSolved = createPuzzleSolved();
            _puzzleStart = createPuzzleStart();
        }

        private int[,] createPuzzleSolved()
        {
            throw new NotImplementedException();
        }

        private int[,] createPuzzleStart()
        {
            throw new NotImplementedException();
        }

        private bool isValidPlacement()
        {
            throw new NotImplementedException();
        }
    }
}
