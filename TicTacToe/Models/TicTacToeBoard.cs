using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class TicTacToeBoard
    {
        //list variable to hold all our cells
        List<Cell> cells { get; set; }
        //constructor method to put all the cell combinations in a list
        public TicTacToeBoard()
        {
            //string array for top middle and bottom
            string[] rows = new string[] { "Top", "Middle", "Bottom" };
            //string array for left middle right
            string[] cols = new string[] { "Left", "Middle", "Right" };
            //assign a new instance of the a list of cells.
            cells = new List<Cell>();
            //loop through each row
            foreach (string r in rows)
            {
                //loop through columns and concatenate each column to the current row string to make an Id for the cell.
                foreach (string c in cols)
                {
                    Cell cell = new Cell { Id = r + c };
                    //add the cell to the list.
                    cells.Add(cell);
                }
            }
        }
        //method to get all the cells for a new board.
        public List<Cell> GetCells() => cells;
        //boolean property for if there's a winner
        public bool HasWinner { get; set; }
        //string property for which mark won
        public string WinningMark { get; set; }
        //boolean property for if all the cells are selected (tie)
        public bool HasAllCellsSelected { get; set; }
        /// <summary>
        /// checks to see if theres a winner by going through all possible combinations
        /// </summary>
        public void CheckForWinner()
        {
            //starts off by defining HasWinner as false
            HasWinner = false;
            //no winning mark yet
            WinningMark = null;
            //horizonal top row
            if (IsWinner(cells[0].Mark, cells[1].Mark, cells[2].Mark))
            {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            //horizonal middle row
            else if (IsWinner(cells[3].Mark, cells[4].Mark, cells[5].Mark))
            {
                HasWinner = true;
                WinningMark = cells[3].Mark;
            }
            //horizontal last row
            else if (IsWinner(cells[6].Mark, cells[7].Mark, cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = cells[6].Mark;
            }
            //vertical left column
            else if (IsWinner(cells[0].Mark, cells[3].Mark, cells[6].Mark))
            {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            //vertical middle column
            else if (IsWinner(cells[1].Mark, cells[4].Mark, cells[7].Mark))
            {
                HasWinner = true;
                WinningMark = cells[1].Mark;
            }
            //vertical right column
            else if (IsWinner(cells[2].Mark, cells[5].Mark, cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }
            //diagontal top left to bottom right
            else if (IsWinner(cells[0].Mark, cells[4].Mark, cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            //diagonal top right to bottom left
            else if (IsWinner(cells[2].Mark, cells[4].Mark, cells[6].Mark))
            {
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }

            HasAllCellsSelected = true;
            foreach (Cell cell in cells)
            {
                if (cell.IsBlank)
                {
                    HasAllCellsSelected = false;
                    return;
                }
            }
        }
        /// <summary>
        ///method used in each if statement above to determine if they are all the same
        /// </summary>
        /// <param name="mark1">X or O</param>
        /// <param name="mark2">X or O</param>
        /// <param name="mark3">X or O</param>
        /// <returns></returns>
        private bool IsWinner(string mark1, string mark2, string mark3)
        {
            //returns true or false if they are all a match
            return mark1 == mark2 && mark2 == mark3 && !string.IsNullOrEmpty(mark1);
        }
    }
}
