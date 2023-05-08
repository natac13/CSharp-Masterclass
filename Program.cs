using System;

namespace HelloWorld
{

  class Program
  {

    static void Main(string[] args)
    {
      TicTacToe game = new TicTacToe();

      game.StartGame();
    }
  }


  class TicTacToe
  {

    private string[,] gameBoard = new string[3, 3] {
      { "1", "2", "3" },
      { "4", "5", "6" },
      { "7", "8", "9" }
    };

    private string player1 = "X";
    private string player2 = "O";
    private string currentPlayer = "X";

    private int player1Wins;
    private int player2Wins;

    public TicTacToe()
    {
      this.player1Wins = 0;
      this.player2Wins = 0;
    }

    public void StartGame()
    {
      Console.Clear();
      this.CreateBoard();

      while (true)
      {
        Console.WriteLine("Player {0} turn", currentPlayer);
        Console.WriteLine("Enter a number to place your mark");
        string input = Console.ReadLine() ?? "";

        if (input == "q")
        {
          break;
        }

        bool success = int.TryParse(input, out int number);

        if (!success)
        {
          Console.WriteLine("Please enter a valid number");
          continue;
        }

        bool markPlaced = this.PlaceMark(number);

        if (!markPlaced)
        {
          continue;
        }

        if (Checker(gameBoard))
        {
          Console.WriteLine("Player {0} wins!", currentPlayer);
          Console.WriteLine($"Press any key to exit; or press 'r' to restart");

          if (currentPlayer == player1)
          {
            player1Wins++;
          }
          else if (currentPlayer == player2)
          {
            player2Wins++;
          }

          string restart = Console.ReadLine() ?? "";

          if (restart == "r")
          {
            this.Restart();
            continue;
          }

          break;
        }

        this.ChangePlayer();
        this.CreateBoard();
      }
    }

    private void Restart()
    {
      Console.WriteLine($"Current standings: Player 1: {player1Wins} Player 2: {player2Wins}");

      this.gameBoard = new string[3, 3] {
              { "1", "2", "3" },
              { "4", "5", "6" },
              { "7", "8", "9" }
            };
      this.CreateBoard();
    }

    private void ChangePlayer()
    {
      if (currentPlayer == player1)
      {
        currentPlayer = player2;
      }
      else
      {
        currentPlayer = player1;
      }
    }

    private int[] GetCorrodinates(int spot)
    {
      switch (spot)
      {
        case 1:
          return new int[2] { 0, 0 };
        case 2:
          return new int[2] { 0, 1 };
        case 3:
          return new int[2] { 0, 2 };
        case 4:
          return new int[2] { 1, 0 };
        case 5:
          return new int[2] { 1, 1 };
        case 6:
          return new int[2] { 1, 2 };
        case 7:
          return new int[2] { 2, 0 };
        case 8:
          return new int[2] { 2, 1 };
        case 9:
          return new int[2] { 2, 2 };
        default:
          throw new Exception("Invalid spot");
      }
    }
    private bool PlaceMark(int spot)
    {
      string mark = currentPlayer;


      int[] corrodinates = new int[2];
      try
      {
        corrodinates = GetCorrodinates(spot);
      }
      catch (Exception e)
      {
        Console.WriteLine(e.Message);
        return false;
      }

      int x = corrodinates[0];
      int y = corrodinates[1];

      if (gameBoard[x, y] == player1 || gameBoard[x, y] == player2)
      {
        Console.WriteLine("Spot is already taken");
        return false;
      }
      gameBoard[x, y] = mark;
      return true;
    }

    public void CreateBoard()
    {
      Console.WriteLine("   |   |   ");
      Console.WriteLine(" {0} | {1} | {2} ", gameBoard[0, 0], gameBoard[0, 1], gameBoard[0, 2]);
      Console.WriteLine("___|___|___");
      Console.WriteLine("   |   |   ");
      Console.WriteLine(" {0} | {1} | {2} ", gameBoard[1, 0], gameBoard[1, 1], gameBoard[1, 2]);
      Console.WriteLine("___|___|___");
      Console.WriteLine("   |   |   ");
      Console.WriteLine(" {0} | {1} | {2} ", gameBoard[2, 0], gameBoard[2, 1], gameBoard[2, 2]);
      Console.WriteLine("   |   |   ");
    }
    public static bool Checker(string[,] board)
    {

      for (int i = 0; i < board.GetLength(0); i++)
      {
        // Check rows
        if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
        {
          return true;
        }
        // Check columns
        if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
        {
          return true;
        }
      }


      // Check diagonals
      if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
      {
        return true;
      }

      if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
      {
        return true;
      }


      return false;
    }
  }
}
