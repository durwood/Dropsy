using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    public class ChipDropper
    {
        public void Go(Board board)
        {
            for (var columnIndex = 0; columnIndex < board.EdgeLength; columnIndex++)
            {
                board.SetColumn(columnIndex,
                    board.GetColumn(columnIndex).Where(chip => chip.HasVolume()).Reverse().ToList());
            }
        }

        public bool HasPendingChips(Board board)
        {
            for (var columnIndex = 0; columnIndex < board.EdgeLength; columnIndex++)
            {
                var hasVolume = false;
                foreach (var chip in board.GetColumn(columnIndex))
                {
                    if (chip.HasValue)
                        hasVolume = true;
                    if (hasVolume && chip.HasVolume() == false)
                        return true;
                }
            }
            return false;
        }
    }
}