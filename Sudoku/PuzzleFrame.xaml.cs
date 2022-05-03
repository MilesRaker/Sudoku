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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sudoku
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PuzzleFrame : Page
    {
        private PuzzleManager _puzzle;
        private string[,] _imageURIs = new string[9,9];
        private Image[,] _gridImages = new Image[9,9];
        private Flyout[,] _flyoutGrid = new Flyout[9,9];
        private Button[,] _buttonGrid = new Button[9,9];

        // frame constructor
        public PuzzleFrame()
        {
            _puzzle = new PuzzleManager(9, 25);
            InitializeFlyoutPicker(2);
            InitializeButtons();
            InitializeGridImages(2);

            this.InitializeComponent();
            this.InitializeGrid();

            //Image00.Source = new BitmapImage(new Uri("ms-appx:///Icons/Set2/Asset 9.svg")); 
        }

        private void InitializeButtons()
        {
            for (int x = 0; x < _puzzle.Generator.Size; x++)
            {
                for (int y = 0; y < _puzzle.Generator.Size; y++)
                {
                    if (_puzzle.Generator.PuzzleStart[x, y] == 0)
                    {
                        _buttonGrid[x, y] = new Button();
                        _buttonGrid[x, y].HorizontalAlignment = HorizontalAlignment.Stretch;
                        _buttonGrid[x, y].VerticalAlignment = VerticalAlignment.Stretch;
                        _buttonGrid[x, y].Flyout = _flyoutGrid[x, y];
                        Grid.SetRow(_buttonGrid[x, y], x);
                        Grid.SetColumn(_buttonGrid[x, y], y);
                    }
                }
            }
        }

        private void InitializeFlyoutPicker(int setNum)
        {
            for (int x = 0; x < _puzzle.Generator.Size; x++)
            {
                for (int y = 0; y < _puzzle.Generator.Size; y++)
                {
                    _flyoutGrid[x, y] = new Flyout();
                    _flyoutGrid[x, y].Content = InitializePickerGrid(setNum);
                }
            }
        }

        private Grid InitializePickerGrid(int setNum)
        {
            Grid pickerGrid = new Grid();
            ColumnDefinition col0 = new ColumnDefinition();
            col0.Width = new GridLength(100);
            ColumnDefinition col1 = new ColumnDefinition();
            col1.Width = new GridLength(100);
            ColumnDefinition col2 = new ColumnDefinition();
            col2.Width = new GridLength(100);
            RowDefinition row0 = new RowDefinition();
            row0.Height = new GridLength(100);
            RowDefinition row1 = new RowDefinition();
            row1.Height = new GridLength(100);
            RowDefinition row2 = new RowDefinition();
            row2.Height = new GridLength(100);
            pickerGrid.ColumnDefinitions.Add(col0);
            pickerGrid.ColumnDefinitions.Add(col1);
            pickerGrid.ColumnDefinitions.Add(col2);
            pickerGrid.RowDefinitions.Add(row0);
            pickerGrid.RowDefinitions.Add(row1);
            pickerGrid.RowDefinitions.Add(row2);
            Image[] pickerGridImages = AssignImagesToPickerGrid(setNum);
            for(int i = 0; i < pickerGridImages.Length; i++)
            {
                pickerGrid.Children.Add(pickerGridImages[i]);
            }
            return pickerGrid;
        }

        private Image[] AssignImagesToPickerGrid(int setNum)
        {
            // create image array
            // assign grid.row & grid.column
            // assign image array as child to pickergrid
            Image[] images = new Image[9];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = new Image();
                images[i].Source = new BitmapImage(new Uri($"ms-appx:///Icons/Set{setNum}/Asset {i + 1}.svg"));
                Grid.SetRow(images[i], i / 3);
                Grid.SetColumn(images[i], i % 3);
            }
            return images;
        }

        private void InitializeGrid()
        {
            Grid board = new Grid();
            board.Margin = new Thickness(0, 100, 80, 150);
            ColumnDefinition col0 = new ColumnDefinition();
            ColumnDefinition col1 = new ColumnDefinition();
            ColumnDefinition col2 = new ColumnDefinition();
            ColumnDefinition col3 = new ColumnDefinition();
            ColumnDefinition col4 = new ColumnDefinition();
            ColumnDefinition col5 = new ColumnDefinition();
            ColumnDefinition col6 = new ColumnDefinition();
            ColumnDefinition col7 = new ColumnDefinition();
            ColumnDefinition col8 = new ColumnDefinition();
            RowDefinition row0 = new RowDefinition();
            RowDefinition row1 = new RowDefinition();
            RowDefinition row2 = new RowDefinition();
            RowDefinition row3 = new RowDefinition();
            RowDefinition row4 = new RowDefinition();
            RowDefinition row5 = new RowDefinition();
            RowDefinition row6 = new RowDefinition();
            RowDefinition row7 = new RowDefinition();
            RowDefinition row8 = new RowDefinition();
            board.ColumnDefinitions.Add(col0);
            board.ColumnDefinitions.Add(col1);
            board.ColumnDefinitions.Add(col2);
            board.ColumnDefinitions.Add(col3);
            board.ColumnDefinitions.Add(col4);
            board.ColumnDefinitions.Add(col5);
            board.ColumnDefinitions.Add(col6);
            board.ColumnDefinitions.Add(col7);
            board.ColumnDefinitions.Add(col8);
            board.RowDefinitions.Add(row0);
            board.RowDefinitions.Add(row1);
            board.RowDefinitions.Add(row2);
            board.RowDefinitions.Add(row3);
            board.RowDefinitions.Add(row4);
            board.RowDefinitions.Add(row5);
            board.RowDefinitions.Add(row6);
            board.RowDefinitions.Add(row7);
            board.RowDefinitions.Add(row8);

            NineFrame.Children.Add(board);
            for(int x = 0; x < _puzzle.Generator.Size; x++)
            {
                for (int y = 0; y < _puzzle.Generator.Size; y++)
                {
                    if(_puzzle.Generator.PuzzleStart[x, y] == 0)
                    {
                        board.Children.Add(_buttonGrid[x, y]);
                        _buttonGrid[x, y].Content = _gridImages[x, y];
                    }
                    else
                    {
                        board.Children.Add(_gridImages[x, y]);
                    }
                }
            }
        }

        private void InitializeGridImages(int setNum)
        {
            for (int x = 0; x < _puzzle.Generator.Size; x++)
            {
                for (int y = 0; y < _puzzle.Generator.Size; y++)
                {
                    _gridImages[x,y] = new Image(); 
                    _gridImages[x, y].Source = new BitmapImage(new Uri($"ms-appx:///Icons/Set{setNum}/Asset {_puzzle.Generator.PuzzleStart[x, y]}.svg"));
                    Grid.SetRow(_gridImages[x, y], x);
                    Grid.SetColumn(_gridImages[x, y], y);
                }
            }
        }

    }
}
