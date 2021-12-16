using Hangman.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Hangman.Tests
{
  [TestClass]
  public class GameTests
  {
    [TestMethod]
    public void GameConstructor_CreatesInstanceOfGame_Game()
    {
      Game newGame = new Game();
      Assert.AreEqual(typeof(Game), newGame.GetType());
    }

    [TestMethod]
    public void GameConstructor_StringArgumentIsStored_String()
    {
      Game newGame = new Game("test");
      Assert.AreEqual("test", newGame.Word);
    }

    [TestMethod]
    public void MakeCorrectLetters_CorrectlyCreatesDictionary_Dictionary()
    {
      Game newGame = new Game("test");
      Dictionary<char, bool> testDict = new Dictionary<char, bool> {{'t', false}, {'e', false}, {'s', false}};
      CollectionAssert.AreEqual(testDict, newGame.CorrectLetters);
    }

    [TestMethod]
    public void Guess_SetsCorrectLetterToTrue_Bool()
    {
      Game newGame = new Game("test");
      newGame.Guess("t");
      Assert.AreEqual(true, newGame.CorrectLetters['t']);
    }

    [TestMethod]
    public void Guess_AddsIncorrectGuessToList_List()
    {
      Game newGame = new Game("test");
      newGame.Guess("n");
      newGame.Guess("m");
      List<char> testList = new List<char> {'n', 'm'};
      CollectionAssert.AreEqual(testList, newGame.IncorrectGuesses);
    }

    [TestMethod]
    public void CheckForWin_ReturnsTrueForWin_Bool()
    {
      Game newGame = new Game("test");
      newGame.Guess("t");
      newGame.Guess("e");
      newGame.Guess("s");
      Assert.AreEqual(true, newGame.CheckForWin());
    }

    [TestMethod]
    public void CheckForWin_ReturnsFalseForNoWin_Bool()
    {
      Game newGame = new Game("test");
      newGame.Guess("t");
      newGame.Guess("e");
      Assert.AreEqual(false, newGame.CheckForWin());
    }

    [TestMethod]
    public void CheckForLose_ReturnsTrueForLose_Bool()
    {
      Game newGame = new Game("test");
      newGame.Guess("r");
      newGame.Guess("u");
      newGame.Guess("i");
      newGame.Guess("p");
      newGame.Guess("o");
      newGame.Guess("m");
      Assert.AreEqual(true, newGame.CheckForLose());
    }

    [TestMethod]
    public void CheckForLose_ReturnsFalseForNoLose_Bool()
    {
      Game newGame = new Game("test");
      Assert.AreEqual(false, newGame.CheckForLose());
    }
  }
}