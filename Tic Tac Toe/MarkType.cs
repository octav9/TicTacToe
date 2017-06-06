using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// The type of value a cell in the game is currently at
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The cell is empty
        /// </summary>
        Free,
        /// <summary>
        /// The cell contains a 0
        /// </summary>
        Nought,
        /// <summary>
        /// The cell contains an X
        /// </summary>
        Cross
    }
}
