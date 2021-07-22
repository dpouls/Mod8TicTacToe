using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe.Models
{
    public class TicTacToeBoard
    {
        List<Cell> cells { get; set; }
        public TicTacToeBoard()
        {
            string[] rows = new string[] { "Top", "Middle", "Bottom" };
            string[] cols = new string[] { "Left", "Middle", "Right" };

            cells = new List<Cell>();
            foreach (string r in rows)
            {
                foreach (string c in cols)
                {
                    Cell cell = new Cell { Id = r + c };
                    cells.Add(cell);
                }
            }
        }
        public List<Cell> GetCells() => cells;
    }
}
