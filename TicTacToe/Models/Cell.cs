using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class Cell
    {
        //cell id
        public string Id { get; set; }
        //cell mark - X or O
        public string Mark { get; set; }
        //Isblank checks if mark is null or empty to see if the cell has already been assigned a mark. returns boolean
        public bool IsBlank => string.IsNullOrEmpty(Mark);
        //checks to see if the cell is on the end and a break is needed in index.cshtml
        public bool IsEndCell => Id.EndsWith("Right");

    }
}
