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
  }
}