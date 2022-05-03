using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class PuzzleGenerator
    {
        /*  -------PuzzleGenerator-------
         * This class builds N x N Sudoku puzzles
         * Every gridsquare is filled with valid numbers
         */
        public int[,] PuzzleStart { get { return _puzzleStart; } }
        public int[,] CompletePuzzle { get { return _completePuzzle; } }
        public int Size { get { return _size; } }

        private int[,] _puzzleStart;
        private Random _random = new Random();
        private int _uniqueSolutionCount = 0;

        //
        private int[,] _completePuzzle;
        private bool _isComplete = false;
        private int[] _nums;
        private int _size;
        public PuzzleGenerator(int size, int difficulty)
        {
            _size = size;
            InitializeNums();
            PlaceNum(0, 0, new int[_size, _size]);
            int[,] arrayCopy = new int[_size, _size];
            Array.Copy(_completePuzzle, arrayCopy, _size * _size);
            CreatePuzzleStart(arrayCopy, difficulty);
        }

        private void CreatePuzzleStart(int[,] board, int difficulty)
        {
            int i = 0;
            while (i < difficulty)
            {
                int x = _random.Next(0, 9);
                int y = _random.Next(0, 9);
                if (board[x, y] != 0)
                {
                    board[x, y] = 0;

                    Solve(board);
                    if (_uniqueSolutionCount == 1)
                    {
                        i++;
                    }
                    else
                    {
                        board[x, y] = _completePuzzle[x, y];
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
                for (int num = 0; num < _size; num++)
                {
                    if (isValidPlacement(board, x, y, num))
                    {
                        board[x, y] = num;
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
            while (x < _size)
            {
                while (y < _size)
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
        private void InitializeNums()
        {
            _nums = new int[_size];
            for (int i = 0; i < _size; i++)
            {
                _nums[i] = i + 1;
            }
            Random random = new Random();
            _nums = _nums.OrderBy(x => random.Next()).ToArray();
        }

        private void PlaceNum(int x, int y, int[,] board)
        {
            if (x == _size)
            {
                _completePuzzle = board;
                _isComplete = true;
                return;
            } // base case
            foreach (int num in _nums)
            {
                if (isValidPlacement(board, x, y, num))
                {
                    board[x, y] = num;

                    // number has been placed and the board is not yet complete
                    // recursively call PlaceNum to place the next num
                    if (y == _size - 1)
                    {
                        PlaceNum(x + 1, 0, board); // go to next row
                    }
                    else
                    {
                        PlaceNum(x, y + 1, board); // go to next column
                    }
                    if (_isComplete)
                        return;
                }
                // either not valid placement, or a recursive return
                // either way, try the next number in _nums
            }
            // no valid numbers in _nums, backtrack
            board[x, y] = 0; // unset value before backtracking
        }

        // ----------- PlaceNum Helpers ---------------

        private bool isValidPlacement(int[,] board, int row, int col, int num)
        {
            if (UsedInRow(board, num, row) || UsedInColumn(board, num, col) || UsedInSquare(board, num, row, col))
                return false;
            else
                return true;
        }

        private bool UsedInRow(int[,] board, int num, int row)
        {
            for (int i = 0; i < _size; i++)
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
            for (int i = 0; i < _size; i++)
            {
                if (board[i, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInSquare(int[,] board, int num, int row, int col)
        {
            int sqrtBoardLength = (int)Math.Sqrt(_size);
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
