using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class TicTacToeViewModel
    {
        //property to hold the current list of cells
        public List<Cell> Cells { get; set; }
        //holds which cell got selected
        public Cell Selected { get; set; }
        //determines if game is over 
        public bool IsGameOver { get; set; }

    }
}
