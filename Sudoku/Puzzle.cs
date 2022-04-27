using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Puzzle
    {
        /*  -------Puzzle-------
         * This class builds 9 x 9 Sudoku puzzles
         * Type Puzzle will be used as a member of PuzzleManager
         */

        private int[,] _puzzleSolved = new int[9, 9];
        private int[,] _puzzleStart = new int[9, 9];
        private int _difficultyLevel;
        private Random _random = new Random();


        public Puzzle()
        {

            // _difficultyLevel = difficultyLevel;
            _puzzleSolved = CreatePuzzleSolved();
            // _puzzleStart = createPuzzleStart();
        }

        private int[,] CreatePuzzleSolved()
        {
            int[,] puzzleSolved = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    // choose random number
                    // check if number works
                    // if it doesn't work, pick new random number and try again

                    // Optimization: have some datastructure that holds 1-9 and remembers which ones have been used in this row already
                    bool squareNotFilled = true;
                    while (squareNotFilled)
                    {
                        int rand = _random.Next(1, 9);
                        if (!UsedInRow(rand, i) && !UsedInColumn(rand, j) && !UsedInSquare(rand, i, j))
                        {
                            puzzleSolved[i, j] = rand;
                            squareNotFilled = false;
                        }

                    }

                }
            }
            // console output testing
            for(int i = 0; i < 9; i++)
            {
                Console.WriteLine();
                for(int j = 0; j < 9; j++)
                {
                    Console.Write(_puzzleSolved.GetValue(i, j).ToString() + " ");
                }
            }
            return puzzleSolved;
        }


        private bool IsGridComplete()
        {
            foreach(int num in _puzzleSolved)
            {
                if(num == 0)
                    return false;
            }
            return true;
        }

        private bool UsedInRow(int num, int row)
        {
            for(int i = 0; i < 9; i++)
            {
                if (_puzzleSolved[row, i] == num)
                {
                    return true;
                }
            }
            return false;
        }

        private bool UsedInColumn(int num, int col)
        {
            for(int i = 0; i < 9; i++)
            {
                if (_puzzleSolved[col, i] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInSquare(int num, int row, int col)
        {
            int startRow = (row / 3) * 3;
            int startCol = (col / 3) * 3;
            for (int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if (_puzzleSolved[startRow + i, startCol + j] == num)
                        return true;
                }
            }
            return false;
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
