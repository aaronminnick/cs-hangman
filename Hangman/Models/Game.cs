using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Game
  {
    private static List<string> _words = new List<string> {"banana", "dinosaur", "exclamation", "chocolate", "complication", "larynx", "banishment", "welcoming", "theocracy", "station", "speedboat", "lavender"};
    public string Word { get; }
    public Dictionary<char, bool> CorrectLetters { get; set; } = new Dictionary<char, bool> {};
    public List<char> IncorrectGuesses { get; set; } = new List<char> {};
    public Game()
    {
      Random rand = new Random();
      Word = _words[rand.Next(0, _words.Count + 1)];
      MakeCorrectLetters();
    }

    public Game(string word)
    {
      Word = word;
      MakeCorrectLetters();
    }

    private void MakeCorrectLetters()
    {
      for (int i = 0; i < Word.Length; i++)
      {
        if (!CorrectLetters.ContainsKey(Word[i]))
        {
          CorrectLetters.Add(Word[i], false);
        }
      }
    }

    public void Guess(string letter)
    {
      char guessed = letter[0];
      if (CorrectLetters.ContainsKey(guessed))
      {
        CorrectLetters[guessed] = true;
      }
      else
      {
        IncorrectGuesses.Add(guessed);
      }
    }

    public bool CheckForWin()
    {
      foreach (KeyValuePair<char, bool> letter in CorrectLetters)
      {
        if (letter.Value == false)
        {
          return false;
        }
      }
      return true;
    }
  }
}