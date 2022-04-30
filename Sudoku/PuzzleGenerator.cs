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
         * This class builds 9 x 9 Sudoku puzzles
         * Every gridsquare is filled with valid numbers
         */

        private int[,] _fullPuzzle;
        //private Random _random = new Random();
        //private bool _isComplete = false;
        private int[] _nums;
        public PuzzleGenerator(int size)
        {
            _nums = new int[size];
            for (int i = 1; i <= size; i++)
            {
                _nums[i-1] = i;
            }
            _fullPuzzle = PlaceNum(0, 0, new int[size, size]);
            while (true) { }
            // PlaceNum(0, 0, RandomOneThroughNine(), new List<int>(), new int[9, 9]);
            // _difficultyLevel = difficultyLevel;
            // _fullPuzzle = CreatePuzzleSolved();
            // _puzzleStart = createPuzzleStart();
        }
        private int[,] PlaceNum(int x, int y, int[,] board)
        {
            foreach (int num in _nums)
            {
                if(isValidPlacement(board, x, y, num))
                {
                    board[x,y] = num;
                    if (IsComplete(board))
                    {
                        return board;
                    }
                    // at this point a valid number has been placed and the board is not yet complete
                    // time to recursively call PlaceNum to place the next num
                    if(y == (int)Math.Sqrt(board.Length) - 1)
                    {
                        board = PlaceNum(x + 1, 0, board); // go to next row
                    }
                    else
                    {
                        board = PlaceNum(x, y + 1, board); // go to next column
                    }
                }
                // here either not valid placement, or a recursive return
                // either way, try the next number in _nums
            }
            // no valid numbers in _nums, gotta backtrack
            return board;
        }
        private bool IsComplete(int[,] board)
        {
            foreach (int entry in board)
            {
                if (entry == 0)
                {
                    return false;
                }
            }
            return true;
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
            for (int i = 0; i < (int) Math.Sqrt(board.Length); i++)
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
            for (int i = 0; i < (int)Math.Sqrt(board.Length); i++)
            {
                if (board[i, col] == num)
                    return true;
            }
            return false;
        }

        private bool UsedInSquare(int[,] board, int num, int row, int col)
        {
            int sqrtBoardLength = (int)Math.Sqrt((int)Math.Sqrt(board.Length));
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="QToTry">Starts as a random list of 1 through 9</param>
        /// <param name="QTried">Numbers tried for this particular spot</param>
        /// <param name="board"></param>
        //private void PlaceNum(int x, int y, List<int> QToTry, List<int> QTried, int[,] board)
        //{
        //    if (IsComplete(board)) // base case
        //    {
        //        _fullPuzzle = board;
        //        _isComplete = true;
        //        return;
        //    }
        //    PlaceNumRecursive(x, y, QToTry, QTried, board);

        //}

        //private void PlaceNumRecursive(int x, int y, List<int> QToTry, List<int> QTried, int[,] board)
        //{
        //    int qIndex = 0; // index for QToTry
        //    while (QToTry.Count > 0)
        //    {
        //        // select a num that hasn't been tried for this slot
        //        while (QTried.Contains(QToTry[qIndex]))
        //        {
        //            if(qIndex + 1 < QToTry.Count)
        //            {
        //                qIndex++; // check out the next number
        //            }
        //            else
        //            {
        //                return; // no numbers in QToTry will work, do backtrack
        //            }
        //        }
        //        int num = QToTry[qIndex];
        //        QTried.Add(num);

        //        if (isValidPlacement(board, x, y, num))
        //        {
        //            board[x, y] = num; // proposed placement valid, actually place in grid
        //            QToTry.Remove(num); // removes the used num from the list
        //            if (y == 8) // place in start of next row
        //            {
        //                PlaceNum(x + 1, 0, RandomOneThroughNine(), new List<int>(), board); // todo: new instance of Q
        //            }
        //            else // place in next column
        //            {
        //                List<int> QToTryCopy = new List<int>(QToTry);
        //                PlaceNum(x, y + 1, QToTryCopy, new List<int>(), board); // todo: new instance of Q
        //            }
        //        }
        //        if (_isComplete) // solution found and recorded, pop the call stack
        //        {
        //            return;
        //        }
        //        // if not valid placement, or if recursive call to PlaceNum() backtracks to here, test next num in QToTry
        //    }
        //    return; // Tried all nums in Q without success, backtrack
        //}


        ///// <summary>
        ///// Use to instantiate Q in PlaceNum()
        ///// </summary>
        ///// <returns></returns>
        //private List<int> RandomOneThroughNine()
        //{
        //    int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //    numbers = numbers.OrderBy(v => _random.Next()).ToArray();
        //    List<int> numbersList = numbers.ToList<int>(); 
        //    return numbersList;
        //}

        /// <summary>
        /// Check before placing value in gridsquare
        /// Calls UsedInRow(), UsedInColumn(), UsedInSquare();
        /// </summary>
        /// <param name="board"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="num"></param>
        /// <returns></returns>


        /*
        private int[,] CreatePuzzleSolved()
        {
            int[,] puzzleSolved = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                List<int> numbers = new List<int>();

                for (int j = 0; j < 9; j++)
                {
                    // choose random number
                    // check if number works
                    // if it doesn't work, pick new random number and try again

                    // Optimization: have some datastructure that holds 1-9 and remembers which ones have been used in this row already
                    bool squareNotFilled = true;
                     

                    while (squareNotFilled)
                    {
                        int rand = _random.Next(1, 10);
                        if (!numbers.Contains(rand) && !UsedInRow(puzzleSolved, rand, i) && 
                            !UsedInColumn(puzzleSolved, rand, j) && !UsedInSquare(puzzleSolved, rand, i, j))
                        {
                            numbers.Add(rand);
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
                    Console.Write(_fullPuzzle.GetValue(i, j).ToString() + " ");
                }
            }
            return puzzleSolved;
        }


        */
        //private int[,] createPuzzleStart()
        //{
        //    /* Loop{
        //     * remove entry random
        //     * if(!puzzle has exactly one solution)
        //     *  replace entry, try again
        //     * when(enough entries are removed)
        //     *  end loop}
        //     * return workingPuzzle
        //     */
        //    int[,] workingPuzzle = new int[9,9];
        //    workingPuzzle = _fullPuzzle;
        //    int numberOfEntries = 81;
        //    int difficulty = 30; // adjust to set difficulty level
        //    while(numberOfEntries > difficulty)
        //    {
        //        // pick random entry
        //        int row = _random.Next(1, 10);
        //        int col = _random.Next(1, 10);

        //        // remove and remember value
        //        int rememberValue = workingPuzzle[row, col];
        //        workingPuzzle[row, col] = 0;

        //        // test if removing that value is valid
        //        if (ExactlyOneSolutionExists(workingPuzzle))
        //        {
        //            numberOfEntries--;
        //        }
        //        else
        //        {
        //            workingPuzzle[row, col] = rememberValue;
        //        }
        //    }
        //    return workingPuzzle;
        //}

        //private bool ExactlyOneSolutionExists(int[,] workingPuzzle) // todo: this only finds one solution, refactor to find multiple solutions
        //{
        //    for (int row = 0; row < 9; row++)
        //    {
        //        for (int col = 0; col < 9; col++)
        //        {
        //            if(workingPuzzle[row, col] == 0)
        //            {
        //                // pick random number for entry
        //                // test if entry valid
        //                // if valid, insert into workingpuzzle
        //                // if not valid, try new random number
        //                bool entryNotFound = true;
        //                while (entryNotFound)
        //                {
        //                    int rand = _random.Next(1, 9);
        //                    if (isValidPlacement(workingPuzzle, row, col, rand))
        //                    {
        //                        workingPuzzle[row, col] = rand;
        //                        entryNotFound = false;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

    }
}
