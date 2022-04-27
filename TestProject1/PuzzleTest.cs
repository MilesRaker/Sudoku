using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace TestProject1
{
    [TestClass]
    public class PuzzleTest
    {
        private static int[,] _sudokuOne =  new int[9, 9] { { 8,2,4,9,5,3,6,7,1 },
                                                            { 6,3,5,8,1,7,9,2,4 },
                                                            { 7,1,9,6,2,4,8,5,3 },
                                                            { 5,8,7,2,9,1,3,4,6 },
                                                            { 1,4,2,7,3,6,5,8,9 },
                                                            { 3,9,6,4,8,5,2,1,7 },
                                                            { 2,6,1,5,4,9,7,3,8 },
                                                            { 4,7,8,3,6,2,1,9,5 },
                                                            { 9,5,3,1,7,8,4,6,2 } };

        [TestMethod]
        public void TestUsedInRow()
        {
            // arrange
            Puzzle puzzle = new Puzzle();
            
            puzzle._puzzleSolved = new int[9, 9] { { 0,2,4,9,5,3,6,7,1 },
                                                { 6,3,5,8,1,7,9,2,4 },
                                                { 7,1,9,6,2,4,8,5,3 },
                                                { 5,8,7,2,9,1,3,4,6 },
                                                { 1,4,2,7,3,6,5,8,9 },
                                                { 3,9,6,4,8,5,2,1,7 },
                                                { 2,6,1,5,4,9,7,3,8 },
                                                { 4,7,8,3,6,2,1,9,5 },
                                                { 9,5,3,1,7,8,4,6,2 } };
            int num = 8;
            // act
            bool output = puzzle.UsedInRow(num, 0);
            // assert
            Assert.AreEqual(false, output);
        }
    }
}