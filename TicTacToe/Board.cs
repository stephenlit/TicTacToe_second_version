using System.Security.Cryptography.X509Certificates;

public class Board
{
    public char[,] GameBoard { get; private set; }


    public Board()
    {
        GameBoard = new char[3, 3]
        {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}
        };
    }
    public void DisplayBoard()
    {
        Console.WriteLine("-------------");
        for (int row = 0; row < 3; row++)
        {
            Console.Write("| ");
            for (int col = 0; col < 3; col++)
            {
                Console.Write($"{GameBoard[row, col]} | ");
            }
            Console.WriteLine("\n-------------");
        }
    }

    public bool IsValidMove(int row, int col)
    {
        //check if the move is within the bounds of the board
        if (row < 0 || row > 2 || col < 0 || col > 2)
        {
            return false;
        }
        //check if the cell is already occupied
        if (GameBoard[row, col] != ' ')
        {
            return false;
        }
        return true;
    }

    public void MakeMove(int row, int col, char symbol)
    {
        GameBoard[row, col] = symbol;
    }
    public bool CheckWin(char symbol)
    {
        // Check rows
        for (int row = 0; row < 3; row++)
        {
            if (GameBoard[row, 0] == symbol && GameBoard[row, 1] == symbol && GameBoard[row, 2] == symbol)
            {
                return true;
            }
        }

        // Check columns
        for (int col = 0; col < 3; col++)
        {
            if (GameBoard[0, col] == symbol && GameBoard[1, col] == symbol && GameBoard[2, col] == symbol)
            {
                return true;
            }
        }

        // Check diagonals
        if (GameBoard[0, 0] == symbol && GameBoard[1, 1] == symbol && GameBoard[2, 2] == symbol)
        {
            return true;
        }
        if (GameBoard[0, 2] == symbol && GameBoard[1, 1] == symbol && GameBoard[2, 0] == symbol)
        {
            return true;
        }

        return false;
    }
    public bool IsFull()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (GameBoard[row, col] == ' ')
                {
                    return false;
                }
            }
        }
        return true;
    }
    public void ResetBoard()
    {
        GameBoard = new char[3, 3]
        {
            {' ', ' ', ' '},
            {' ', ' ', ' '},
            {' ', ' ', ' '}
        };
    }
    public void ClearBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                GameBoard[row, col] = ' ';
            }
        }
    }
    public void ClearCell(int row, int col)
    {
        GameBoard[row, col] = ' ';
    }
    public void SetCell(int row, int col, char symbol)
    {
        GameBoard[row, col] = symbol;
    }
}