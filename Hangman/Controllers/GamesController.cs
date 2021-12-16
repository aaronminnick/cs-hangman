using Microsoft.AspNetCore.Mvc;
using Hangman.Models;

namespace Hangman.Controllers
{
  public class GamesController : Controller
  {
    [HttpGet("/games/new")]
    public ActionResult New()
    {
      return View();
    }

    [HttpPost("/games")]
    public ActionResult Create(string word)
    {
      Game newGame;
      if (word != null)
      {
        newGame = new Game(word.ToLower());
      }
      else 
      {
        newGame = new Game();
      }
      return RedirectToAction("Show", new { id = newGame.Id });
    }

    [HttpGet("/games/{id}")]
    public ActionResult Show(int id)
    {
      Game currentGame = Game.Find(id);
      return View(currentGame);
    }

    [HttpPost("/games/{id}")]
    public ActionResult Update(int id, string letter)
    {
      Game currentGame = Game.Find(id);
      currentGame.Guess(letter.ToLower());
      return RedirectToAction("Show", new { id = currentGame.Id });
    }
  }
}