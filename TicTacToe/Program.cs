public class TicTacToe
{
    private static bool isGameOver;
    private static string player1Name = string.Empty;
    private static string player2Name = string.Empty;
    private static string currentPlayerName = string.Empty;


    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Tic Tac Toe!");
        // Get player names
        do
        {
            System.Console.WriteLine("Enter Player 1's name:");
            player1Name = Console.ReadLine() ?? string.Empty;
            // Check if the name is empty or contains only whitespace
            // If it is, prompt the user to enter a valid name
            if (string.IsNullOrWhiteSpace(player1Name))
            {
                System.Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            }
        } while (string.IsNullOrWhiteSpace(player1Name));
        do
        {
            System.Console.WriteLine("Enter Player 2's name:");
            player2Name = Console.ReadLine() ?? string.Empty;
            // Check if the name is empty or contains only whitespace
            // If it is, prompt the user to enter a valid name
            if (string.IsNullOrWhiteSpace(player2Name))
            {
                System.Console.WriteLine("Name cannot be empty. Please enter a valid name.");
            }
        } while (string.IsNullOrWhiteSpace(player2Name));



        // Initialize players and board
        Players player1 = new Players(player1Name, 'X');
        Players player2 = new Players(player2Name, 'O');
        //set current player to player1
        currentPlayerName = player1.Name;
        // Initialize the game board
        Board gameBoard = new Board();
        // Display the initial game board
        gameBoard.DisplayBoard();

        // Loop until the game is over
        while (!isGameOver)
        {
            System.Console.WriteLine($"{currentPlayerName}'s turn. Enter your move (row and column)(example: 1-2):");
            // Get the current player's move
            string input = Console.ReadLine() ?? string.Empty;
            // Split the input into row and column
            string[] parts = input.Split('-');
            if (parts.Length != 2 || !int.TryParse(parts[0], out int row) || !int.TryParse(parts[1], out int col))
            {
                System.Console.WriteLine("Invalid input. Please enter your move in the format 'row-column' (example: 1-2):");
                continue;
            }
            // Adjust for 0-based indexing
            row--;
            col--;
            // Check if the move is valid
            if (!gameBoard.IsValidMove(row, col))
            {
                System.Console.WriteLine("Invalid move. Try again.");
                continue;
            }
            // Make the move on the board
            gameBoard.MakeMove(row, col, currentPlayerName == player1.Name ? player1.Symbol : player2.Symbol);
            // Display the updated board
            gameBoard.DisplayBoard();
            // Check for a win or draw
            if (gameBoard.CheckWin(currentPlayerName == player1.Name ? player1.Symbol : player2.Symbol))
            {
                System.Console.WriteLine($"{currentPlayerName} wins!");
                isGameOver = true;
                break;
            }
            else if (gameBoard.IsFull())
            {
                System.Console.WriteLine("It's a draw!");
                isGameOver = true;
                break;
            }
            // Switch players
            currentPlayerName = currentPlayerName == player1.Name ? player2.Name : player1.Name;
        }
    }
}