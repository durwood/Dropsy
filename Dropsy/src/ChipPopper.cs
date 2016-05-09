using System.Collections.Generic;

namespace Dropsy
{
    public class ChipPopper
    {
        public void PopChips(Board board)
        {
            for (int i = 0; i < board.EdgeLength; i++)
            {
                PopChipSet(board.GetRow(i));
                PopChipSet(board.GetColumn(i));
            }
        }

        private static void PopChipSet(IReadOnlyCollection<IChip> chipSet)
        {
            foreach (var chip in chipSet)
            {
                if (chip.Value == FindRealChipCount(chipSet))
                    chip.Pop();
            }
        }

        private static int FindRealChipCount(IReadOnlyCollection<IChip> chipSet)
        {
            var findRealChipCount = 0;
            foreach (var chip in chipSet)
            {
                if (chip.HasValue())
                    findRealChipCount++;
            }
            return findRealChipCount;
        }
    }
}