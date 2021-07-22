using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class TicTacToeViewModel
    {
        public List<Cell> Cells { get; set; }
        public Cell Selected { get; set; }
        public bool IsGameOver { get; set; }

    }
}
