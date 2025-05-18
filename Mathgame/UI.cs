using System;

namespace Mathgame
{
  public class UI
  {
    #region Properties
    /// <summary>
    /// Score property to keep track of the user's score.
    /// </summary>
    private int Score { get; set; } = 0;
    /// <summary>
    /// History property to keep track of the math examples and their results.
    /// </summary>
    readonly Dictionary<int, MathExample> history = [];
    #endregion

    #region Constructors
    /// <summary>
    /// Main constructor for the UI class.
    /// </summary>
    /// <param name="includeWelcomeMessage"></param>
    public UI(bool includeWelcomeMessage)
    {
      if (includeWelcomeMessage)
      {
        WriteWelcomeMessage();
      }
      PlayGame();
    }
    #endregion

    #region Methods
    /// <summary>
    /// Logs the history of the game.
    /// </summary>
    /// <param name="example"></param>
    /// <param name="userResult"></param>
    void LogHistory(MathExample example, int userResult)
    {
      history.Add(userResult, example);

    }
    /// <summary>
    /// Writes a welcome message to the console.
    /// </summary>
    private static void WriteWelcomeMessage()
    {
      Console.WriteLine("Welcome to the Math Game!");
      Console.WriteLine("You will be asked a series of math questions.");
    }
    /// <summary>
    /// Displays the history of the game.
    /// </summary>
    private void SeeHistory()
    {
      foreach (var item in history)
      {
        Console.WriteLine($"ID: {item.Key} | Example: {item.Value.Example} | Result: {item.Value.Result} | Your result: {item.Key}");
      }
      PlayAnotherGame();
    }
    /// <summary>
    /// Main game loop that continues until the user decides to quit.
    /// </summary>
    public void PlayGame()
    {
      while (true)
      {
        PlaySingleRound();

        if (!PlayAnotherGame())
        {
          HandlePostGameMenu();
          return;
        }
      }
    }
    /// <summary>
    /// Plays a single round of the game.
    /// </summary>
    private void PlaySingleRound()
    {
      char selectedOperator = GetOperatorFromUser();
      var mathExample = new MathExample(selectedOperator);

      if (!TryGetUserAnswer(mathExample, out int answer))
      {
        Console.WriteLine("Please enter a valid number.");
        return;
      }

      if (mathExample.CheckAnswer(answer))
      {
        AddPoint();
      }
      else
      {
        Console.WriteLine("No point was added");
      }

      LogHistory(mathExample, answer);
      DisplayScore();
    }
    /// <summary>
    /// Prompts the user for an answer and checks if it's valid.
    /// </summary>
    /// <param name="example"></param>
    /// <param name="answer"></param>
    /// <returns></returns>
    private static bool TryGetUserAnswer(MathExample example, out int answer)
    {
      example.Show();
      Console.WriteLine("Please enter your answer:");
      string? input = Console.ReadLine();
      return int.TryParse(input, out answer);
    }
    /// <summary>
    /// Handles the post-game menu options.
    /// </summary>
    private void HandlePostGameMenu()
    {
      Console.WriteLine("1. See history | 2. Play again | 3. Quit");
      string? result = Console.ReadLine();
      switch (result)
      {
        case "1":
          SeeHistory();
          break;
        case "2":
          PlayGame();
          break;
        case "3":
          Console.WriteLine("Thanks for playing!");
          return;
        default:
          Console.WriteLine("Invalid choice, quitting.");
          Environment.Exit(0);
          return;
      }
    }
    /// <summary>
    /// Gets the operator from the user.
    /// </summary>
    /// <returns></returns>
    private static char GetOperatorFromUser()
    {
      Console.WriteLine("Choose an operator");
      Console.WriteLine("1. addition | 2. subtraction | 3. multiplication | 4. division");
      string? input = Console.ReadLine();

      return input switch
      {
        "1" => '+',
        "2" => '-',
        "3" => '*',
        "4" => '/',
        _ => DefaultOperator()
      };
    }
    /// <summary>
    /// Handles the default case for operator selection.
    /// </summary>
    /// <returns></returns>
    private static char DefaultOperator()
    {
      Console.WriteLine("Invalid choice, defaulting to addition.");
      return '+';
    }

    private void DisplayScore()
    {
      Console.WriteLine($"Your score is {Score}");
    }
    /// <summary>
    /// Adds a point to the score.
    /// </summary>

    private void AddPoint()
    {
      Score++;
    }
    /// <summary>
    /// Asks the user if they want to play another game.
    /// </summary>
    /// <returns></returns>
    private static bool PlayAnotherGame()
    {
      Console.WriteLine("Do you want to play another game? (y/n)");
      string? input = Console.ReadLine();
      return input != null && input.Equals("y", StringComparison.OrdinalIgnoreCase);
    }

    #endregion
  }
}