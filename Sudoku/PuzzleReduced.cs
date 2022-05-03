using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    internal class PuzzleReduced
    {
        /* ------PuzzleReduced------
         * Holds puzzle ready for user to attempt
         * Has a PuzzleGenerator
         * Some gridsquares from PuzzleGenerator are replaced with 0
         * Puzzle has one unique solution
         */

        private PuzzleGenerator _generator;
        private int[,] _puzzleStart;
        // private int _numberOfZeros = 0; for debugging
        private Random _random = new Random();
        private int _uniqueSolutionCount = 0;

        public PuzzleReduced(PuzzleGenerator gen)
        {
            _generator = gen;

            CreatePuzzleStart(_generator.FullPuzzle, 25);
            // _numberOfZeros = CountZeros(); // for debugging
        }

        private int CountZeros() // for debugging
        {
            int count = 0;
            foreach(int num in _puzzleStart)
            {
                if(num == 0)
                    count++;
            }
            return count;
        }

        private void CreatePuzzleStart(int[,] board, int difficulty)
        {
            // pick a coordinate
            // remember num in that coordinate
            // replace that num with 0
            // check if puzzle has one solution
            // repeat until desired amount of 0's exist in board

            int i = 0;
            while (i < difficulty)
            {
                int x = _random.Next(0, 9);
                int y = _random.Next(0, 9);
                if(board[x, y] != 0)
                {
                    board[x, y] = 0;

                    Solve(board);
                    if (_uniqueSolutionCount == 1)
                    {
                        i++;
                    }
                    else
                    {
                        board[x, y] = _generator.FullPuzzle[x, y];
                    }
                    _uniqueSolutionCount = 0;
                }

            }
            _puzzleStart = board;
        }

        private void Solve(int[,] board)
        {
            int x, y;
            if (FindNextZero(out x, out y, board))
            {
                for(int num = 0; num < _generator.Size; num++)
                {
                    if(isValidPlacement(board, x, y, num))
                    {
                        board[x,y] = num;
                        Solve(board);
                    }
                }
                board[x, y] = 0;
            }

            else
            {
                _uniqueSolutionCount++;
            }
        }

        private bool FindNextZero(out int x, out int y, int[,] board)
        {
            x = 0; y = 0;
            while(x < _generator.Size)
            {
                while (y < _generator.Size)
                {
                    if (board[x, y] == 0)
                    {
                        return true;
                    }
                    y++;
                }
                x++;
            }
            return false;
        }

        private bool isValidPlacement(int[,] board, int row, int col, int num)
        {
            if (UsedInRow(board, num, row) || UsedInColumn(board, num, col) || UsedInSquare(board, num, row, col))
                return false;
            else
                return true;
        }

        private bool UsedInRow(int[,] board, int num, int row)
        {
            for (int i = 0; i < _generator.Size; i++)
            {
                if (board[row, i] == num)
                {
                    return true;
                }
            }
            return false;
        }

        private bool UsedInColumn(int[,] board, int num, int col)
        {
            for (int i = 0; i < _generator.Size; i++)
            {
                if (board[i, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInSquare(int[,] board, int num, int row, int col)
        {
            int sqrtBoardLength = (int)Math.Sqrt(_generator.Size);
            int startRow = (row / sqrtBoardLength) * sqrtBoardLength;
            int startCol = (col / sqrtBoardLength) * sqrtBoardLength;
            for (int i = 0; i < sqrtBoardLength; i++)
            {
                for (int j = 0; j < sqrtBoardLength; j++)
                {
                    if (board[startRow + i, startCol + j] == num)
                        return true;
                }
            }
            return false;
        }

    }
}
