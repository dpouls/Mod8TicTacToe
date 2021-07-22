using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Models;

namespace TicTacToe.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            TicTacToeBoard board = new TicTacToeBoard();
            List<Cell> cells = board.GetCells();
            foreach (Cell cell in cells)
            {
                cell.Mark = TempData[cell.Id]?.ToString();
            }
            //Check for winner
            TicTacToeViewModel model = new TicTacToeViewModel
            {
                Cells = cells,
                Selected = new Cell { Mark = TempData["nextTurn"]?.ToString() ?? "X" },
                //Is Game Over
            };
            if (model.IsGameOver)
            {
                TempData["nextTurn"] = "X";
                TempData["message"] = "Game is over"; //find out if there's a winner else show tie.
            }
            else
            {
                TempData.Keep();
            }
            return View(model);
        }
        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel model)
        {
            TempData[model.Selected.Id] = model.Selected.Mark;
            TempData["nextTurn"] = model.Selected.Mark == "X" ? "O" : "X";

            return RedirectToAction("Index");
        }
    }
}
