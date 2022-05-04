using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sudoku;

namespace Sudoku
{
    internal class PuzzleManager
    {
        /* -------PuzzleManager-------
         * Manages the state of a puzzle as a user solves it
         * Methods compare the current state of the puzzle to the solved version
         * 
         */
        public PuzzleGenerator Generator { get { return _generator; } }
        private PuzzleGenerator _generator;
        public int[,] UserInputs = new int[9, 9];


        public PuzzleManager(int size, int difficulty)
        {
            _generator = new PuzzleGenerator(size, difficulty);
        }
    }
}
