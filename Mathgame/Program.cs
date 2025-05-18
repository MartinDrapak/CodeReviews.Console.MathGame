

namespace Mathgame
{


  class Program
  {
    #region main method
    static void Main()
    {
      
      PlayGame();
    }
    #endregion

    #region Constructors
    /// <summary>
    /// Program class constructor
    /// </summary>
    Program() { }
    #endregion

    #region public methods

    /// <summary>
    /// Main method to start the game.
    /// </summary>
    static void PlayGame()
    {
      UI uI = new(true);
      uI.PlayGame();
    }

    #endregion
  }

}