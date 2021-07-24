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
        //for get requests
        /// <summary>
        /// returns the index page with a tic tac toe board and reloads with new data on each click of the board.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult Index()
        {
            //new instance of the tictactoeboard
            TicTacToeBoard board = new TicTacToeBoard();
            //we make a list of cells from the tictactoeboard method GetCells()
            List<Cell> cells = board.GetCells();
            //loop through each cell in cells and determine what their mark is.
            foreach (Cell cell in cells)
            {
                cell.Mark = TempData[cell.Id]?.ToString();
            }
            //Check for winner
            board.CheckForWinner();
            //new instance of tictactoviewmodel
            TicTacToeViewModel model = new TicTacToeViewModel
            {
                //assign cells to Cells
                Cells = cells,
                //on first move, X is default, then it is whatever tempdata["nextTurn"] is
                Selected = new Cell { Mark = TempData["nextTurn"]?.ToString() ?? "X" },
                //Is Game Over
                //over if someone won or its a tie
                IsGameOver = board.HasWinner || board.HasAllCellsSelected
            };
            //if the game is over, set next turn to X and show the appropriate message
            if (model.IsGameOver)
            {
                TempData["nextTurn"] = "X";
                //find out if there's a winner else show tie.
                TempData["message"] = (board.HasWinner) ? $"{board.WinningMark} wins!" : "It's a tie!";

            }
            else
            {
                //keeps the tempdata between clicks until New Game is clicked.
                TempData.Keep();
            }
            //returns the view with the model data passed in.
            return View(model);
        }
        /// <summary>
        /// expects a post request with a tictactoeviewmodel passed in. Determines selected cell and  next turn mark
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RedirectToActionResult Index(TicTacToeViewModel model)
        {
            //assigns the selected cell the current mark
            TempData[model.Selected.Id] = model.Selected.Mark;
            //changes to the other mark (x on first round)
            TempData["nextTurn"] = model.Selected.Mark == "X" ? "O" : "X";
            //redirects to action until game is complete
            return RedirectToAction("Index");
        }
    }
}
