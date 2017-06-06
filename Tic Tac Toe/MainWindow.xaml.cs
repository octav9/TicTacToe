using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        /// <summary>
        /// Holds the current value of every cell.
        /// </summary>
        private MarkType[] cells;

        /// <summary>
        /// True if it's player 1's turn.
        /// </summary>
        private bool Player1Turn;

        /// <summary>
        /// True if the game ended.
        /// </summary>
        private bool GameOver;
        private Brush brushes;

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            NewGame();
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        private void NewGame()
        {
            cells = new MarkType[9];
            for (int i = 0; i < 9; i++) cells[i] = 0;

            Player1Turn = true;

            // Convert the buttons into a list.
            Container.Children.Cast<Button>().ToList().ForEach(button => { button.Content = string.Empty;button.Background = Brushes.White; });

            GameOver = false;
        }

        /// <summary>
        /// Handles a button click event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (GameOver) NewGame();

            //Convert the sender to a button.
            var button = (Button)sender;

            // Find out the position of the button.
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);
            var index = column + row * 3;

            // If the cell is free fill it and make it the next player's turn.
            if (cells[index] == MarkType.Free)
            {
                cells[index] = Player1Turn ? MarkType.Cross : MarkType.Nought;
                button.Content = Player1Turn ? "X" : "O";
                button.Foreground = Player1Turn ? Brushes.Red : Brushes.Blue;
                CheckForWinner();
                Player1Turn ^= true;
            }
        }

        private void CheckForWinner()
        {
            if(cells[0]!=MarkType.Free)
            {
                if (cells[0]==(cells[0]&cells[1]&cells[2])|| cells[0] == (cells[0] & cells[3] & cells[6])|| cells[0] == (cells[0] & cells[4] & cells[8]))
                {
                    if(Player1Turn)
                    {
                        MessageBox.Show("X won!");
                    }
                    else MessageBox.Show("O won!");
                    GameOver = true;
                }
            }
            if (cells[3] != MarkType.Free)
            {
                if (cells[3] == (cells[3] & cells[4] & cells[5]))
                {
                    if (Player1Turn)
                    {
                        MessageBox.Show("X won!");
                    }
                    else MessageBox.Show("O won!");
                    GameOver = true;
                }
            }
            if (cells[6] != MarkType.Free)
            {
                if (cells[6] == (cells[6] & cells[7] & cells[8]) || cells[6] == (cells[6] & cells[2] & cells[4]))
                {
                    if (Player1Turn)
                    {
                        MessageBox.Show("X won!");
                    }
                    else MessageBox.Show("O won!");
                    GameOver = true;
                }
            }
            if (cells[1] != MarkType.Free)
            {
                if (cells[1] == (cells[1] & cells[4] & cells[7]))
                {
                    if (Player1Turn)
                    {
                        MessageBox.Show("X won!");
                    }
                    else MessageBox.Show("O won!");
                    GameOver = true;
                }
            }
            if (cells[2] != MarkType.Free)
            {
                if (cells[2] == (cells[2] & cells[5] & cells[8]))
                {
                    if (Player1Turn)
                    {
                        MessageBox.Show("X won!");
                    }
                    else MessageBox.Show("O won!");
                    GameOver = true;
                }
            }
            if (cells[0] != MarkType.Free & cells[1] != MarkType.Free & cells[2] != MarkType.Free & cells[3] != MarkType.Free & cells[4] != MarkType.Free & cells[5] != MarkType.Free & cells[6] != MarkType.Free & cells[7] != MarkType.Free & cells[8] != MarkType.Free&GameOver==false)
            {
                MessageBox.Show("Stalemate!");
                GameOver = true;
            }
        }
    }
}
