using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class PuzzleManager
    {
        /* -------PuzzleManager-------
         * Manages the state of a puzzle as a user solves it
         * Methods compare the current state of the puzzle to the solved version
         * 
         */

        public int[,] DemoSudokuBoard = new int[9, 9] { {9,6,8,1,3,5,2,4,7 },
                                                        {1,3,7,8,4,2,9,5,6 },
                                                        {4,2,5,9,6,7,3,8,1 },
                                                        {7,8,2,6,1,3,4,9,5 },
                                                        {3,1,4,5,9,6,7,6,2 },
                                                        {5,9,6,2,7,4,8,1,3 },
                                                        {8,7,9,3,5,1,6,2,4 },
                                                        {6,4,1,7,2,9,5,3,8 },
                                                        {2,5,3,4,8,6,1,7,9 }};
    }
}
