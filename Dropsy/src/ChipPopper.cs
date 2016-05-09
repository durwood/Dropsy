using System.Collections.Generic;

namespace Dropsy
{
    public class ChipPopper
    {
        public void PopChips(Board board)
        {
            var chipsToPop = new List<IChip>();
            for (var i = 0; i < board.EdgeLength; i++)
            {
                PopChipSet(board.GetRow(i), chipsToPop);
                PopChipSet(board.GetColumn(i), chipsToPop);
            }

            foreach (var chip in chipsToPop)
                chip.Pop();
        }

        private static void PopChipSet(IReadOnlyCollection<IChip> chipSet, IList<IChip> chipsToPop)
        {
            foreach (var chip in chipSet)
            {
                if (chip.Value == FindRealChipCount(chipSet))
                    chipsToPop.Add(chip);
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