using System;
using System.Collections.Generic;

namespace Hangman.Models
{
  public class Hangman
  {
    private static List<string> _words = new List<string> {"banana", "dinosaur", "exclamation", "chocolate", "complication", "larynx", "banishment", "welcoming", "theocracy", "station", "speedboat", "lavender"};
    private string _word;
    public Dictionary<char, bool> CorrectLetters { get; set; } = new Dictionary<char, bool> {};
    public Hangman()
    {
      Random rand = new Random();
      _word = _words[rand.Next(0, _words.Count + 1)];

      for (int i = 0; i < _word.Length; i++)
      {
        if (!CorrectLetters.ContainsKey(_word[i]))
        {
          CorrectLetters.Add(_word[i], false);
        }
      }
    }
  }
}