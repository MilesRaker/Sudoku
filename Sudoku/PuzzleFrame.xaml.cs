using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sudoku
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PuzzleFrame : Page
    {
        public PuzzleFrame()
        {
            this.InitializeComponent();
            //foreach(int index in DemoSudokuboard)
            //{
            //    switch (DemoSudokuBoard[index])
            //    {
            //        case 1: 
            //        case 2:
            //        case 9: Array of gridsquares.Source = "./Icons/Set1/Asset 9";

            //    }
            //}

        }
    }
}
