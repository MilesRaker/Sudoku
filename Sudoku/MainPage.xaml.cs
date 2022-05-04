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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Sudoku
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Back.Visibility = Visibility.Collapsed;
            MyFrame.Navigate(typeof(WilliamSudoku));
            Welcome.IsSelected = true;
            //WorkingPuzzle.Navigate(typeof(PuzzleFrame), null);
            //PuzzleGenerator puzzle = new PuzzleGenerator();
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen=!MySplitView.IsPaneOpen;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.CanGoBack)
            {
                MyFrame.GoBack();
                Welcome.IsSelected = true;
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Welcome.IsSelected)
            {
                Back.Visibility = Visibility.Collapsed;
                MyFrame.Navigate(typeof(WilliamSudoku));
                Titletext.Text = "Welcome to William's Game Room";
            }
            else if (Game.IsSelected)
            {
                Back.Visibility = Visibility.Visible;
                MyFrame.Navigate(typeof(PuzzleFrame));
                Titletext.Text = "SudokuCat for kids";
            }
        }
    }
}
