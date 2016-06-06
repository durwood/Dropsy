using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    public class ChipDropper
    {
        public void DropChips(Board board)
        {
            for (var columnIndex =0; columnIndex<board.EdgeLength; columnIndex++)
            {
                board.SetColumn(columnIndex, board.GetColumn(columnIndex).Where(chip => chip.HasValue()).Reverse().ToList());
            }

        }
    }
}