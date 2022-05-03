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
        private PuzzleGenerator _generator;
        public PuzzleGenerator Generator { get { return _generator; } }
        private PuzzleReduced _reduced;

        public PuzzleManager(int size)
        {
            _generator = new PuzzleGenerator(size);
            _reduced = new PuzzleReduced(_generator);
            while (true) { };
        }
    }
}
