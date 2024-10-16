using System;
using System.Collections.Generic;
using System.Text;
using TicTacToeRendererLib.Enums;
using TicTacToeRendererLib.Renderer;

namespace TicTacToeSubmissionConole
{
    public class TicTacToe
    {
        private TicTacToeConsoleRenderer _boardRenderer;
        private PlayerEnum?[,] board = new PlayerEnum?[3, 3];
        private PlayerEnum currentPlayer = PlayerEnum.X;

        public TicTacToe()
        {
            _boardRenderer = new TicTacToeConsoleRenderer(10, 6);
            _boardRenderer.Render();
        }

        public void Run()
        {
            bool gameOver = false;

            while (!gameOver)
            {
                // FOR ILLUSTRATION CHANGE TO YOUR OWN LOGIC TO DO TIC TAC TOE
                Console.SetCursorPosition(2, 19);
                Console.Write($"Player {currentPlayer}");
                Console.SetCursorPosition(2, 20);
                Console.Write("Please Enter Row (0-2): ");
                var row = Console.ReadLine();
                Console.SetCursorPosition(2, 22);
                Console.Write("Please Enter Column (0-2): ");
                var column = Console.ReadLine();

                int rowNum = int.Parse(row);
                int colNum = int.Parse(column);

                if (IsValidMove(rowNum, colNum))
                {
                    // THIS JUST DRAWS THE BOARD (NO TIC TAC TOE LOGIC)
                    _boardRenderer.AddMove(rowNum, colNum, currentPlayer, true);
                    board[rowNum, colNum] = currentPlayer;

                    if (CheckWin(rowNum, colNum))
                    {
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine($"Player {currentPlayer} Congradulations you won the game.");
                        gameOver = true;
                    }
                    else if (IsBoardFull())
                    {
                        Console.SetCursorPosition(2, 24);
                        Console.WriteLine("You both Drew against each other.");
                        gameOver = true;
                    }
                    else
                    {
                        SwitchPlayer();
                    }
                }
                else
                {
                    Console.SetCursorPosition(2, 24);
                    Console.WriteLine("Invalid move! Try again.");
                }
            }
        }

        private bool IsValidMove(int row, int col)
        {
            if (row < 0 || row > 2 || col < 0 || col > 2)
                return false;
            if (board[row, col] != null)
                return false;
            return true;
        }

        private void SwitchPlayer()
        {
            if (currentPlayer == PlayerEnum.X)
                currentPlayer = PlayerEnum.O;
            else
                currentPlayer = PlayerEnum.X;
        }

        private bool CheckWin(int row, int col)
        {
            // Check row
            if (board[row, 0] == currentPlayer && board[row, 1] == currentPlayer && board[row, 2] == currentPlayer)
                return true;

            // Check column
            if (board[0, col] == currentPlayer && board[1, col] == currentPlayer && board[2, col] == currentPlayer)
                return true;

            // Check diagonals
            if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                return true;
            if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                return true;

            return false;
        }

        private bool IsBoardFull()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == null)
                        return false;
                }
            }
            return true;
        }
    }
}