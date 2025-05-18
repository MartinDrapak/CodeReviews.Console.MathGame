using Mathgame.Interfaces;
using System;
using System.Linq;

namespace Mathgame
{
  /// <summary>
  /// Represents a single math example with a specific operator and result.
  /// </summary>
  class MathExample : IMathExample
  {
    #region Properties

    /// <summary>
    /// The string representation of the math example.
    /// </summary>
    public string Example { get; set; } = string.Empty; // Initialize to avoid CS8618

    /// <summary>
    /// The operator used in the math example.
    /// </summary>
    public char Operator { get; set; }

    /// <summary>
    /// The correct result of the math example.
    /// </summary>
    public int Result { get; set; }

    #endregion

    #region Constructors

    /// <summary>
    /// Initializes a new instance of the MathExample class with the specified operator.
    /// </summary>
    /// <param name="_operator">The operator to use in the example.</param>
    public MathExample(char _operator)
    {
      Operator = _operator;
      Generate();
    }

    #endregion

    #region Methods

    /// <summary>
    /// Generates a random math example based on the specified operator.
    /// Ensures all generated examples are valid and result in an integer value.
    /// </summary>
    public void Generate()
    {
      Random r = new();
      int amountOfNumbers = r.Next(1, 10);

      switch (Operator)
      {
        case '+':
          GenerateAdditionExample(amountOfNumbers, r);
          break;
        case '-':
          GenerateSubtractionExample(amountOfNumbers, r);
          break;
        case '*':
          GenerateMultiplicationExample(amountOfNumbers, r);
          break;
        case '/':
          GenerateDivisionExample(r);
          break;
        default:
          Example = "Invalid operator";
          Result = 0;
          break;
      }
    }

    /// <summary>
    /// Generates a random addition example.
    /// </summary>
    private void GenerateAdditionExample(int amountOfNumbers, Random r)
    {
      int[] numbers = new int[amountOfNumbers];
      string example = "";
      for (int i = 0; i < amountOfNumbers; i++)
      {
        numbers[i] = r.Next(0, 100);
        example += numbers[i];
        if (i < amountOfNumbers - 1) example += " + ";
      }
      Example = example;
      Result = numbers.Sum();
    }

    /// <summary>
    /// Generates a random subtraction example.
    /// </summary>
    private void GenerateSubtractionExample(int amountOfNumbers, Random r)
    {
      int[] numbers = new int[amountOfNumbers];
      numbers[0] = r.Next(0, 100);
      string example = numbers[0].ToString();
      int result = numbers[0];
      for (int i = 1; i < amountOfNumbers; i++)
      {
        numbers[i] = r.Next(0, numbers[0]);
        example += " - " + numbers[i];
        result -= numbers[i];
      }
      Example = example;
      Result = result;
    }

    /// <summary>
    /// Generates a random multiplication example.
    /// </summary>
    private void GenerateMultiplicationExample(int amountOfNumbers, Random r)
    {
      int[] numbers = new int[amountOfNumbers];
      string example = "";
      for (int i = 0; i < amountOfNumbers; i++)
      {
        numbers[i] = r.Next(1, 13);
        example += numbers[i];
        if (i < amountOfNumbers - 1) example += " * ";
      }
      Example = example;
      Result = numbers.Aggregate((a, b) => a * b);
    }

    /// <summary>
    /// Generates a random division example with an integer result.
    /// </summary>
    private void GenerateDivisionExample(Random r)
    {
      Result = r.Next(1, 13);
      int divisor = r.Next(1, 13);
      int dividend = Result * divisor;
      Example = $"{dividend} / {divisor}";
    }

    /// <summary>
    /// Displays the generated math example to the console.
    /// </summary>
    public void Show()
    {
      Console.WriteLine(Example);
    }

    /// <summary>
    /// Checks if the provided answer is correct and displays feedback.
    /// </summary>
    /// <param name="answer">The user's answer.</param>
    /// <returns>True if correct, otherwise false.</returns>
    public bool CheckAnswer(int answer)
    {
      if (answer == Result)
      {
        Console.WriteLine("Correct!");
        return true;
      }
      else
      {
        Console.WriteLine($"Incorrect! The correct answer is {Result}.");
        return false;
      }
    }

    #endregion
  }
}