using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    public class ChipPopper
    {
        public void PopChips(Board board)
        {
            var chipsToPop = GetPoppableChips(board);

            foreach (var chip in chipsToPop)
                chip.Pop();
        }

        public List<IChip> GetPoppableChips(Board board)
        {
            var chipsToPop = new List<IChip>();
            for (var i = 0; i < board.EdgeLength; i++)
            {
                PopChipSet(board.GetRow(i), chipsToPop);
                PopChipSet(board.GetColumn(i), chipsToPop);
            }
            return chipsToPop;
        }

        private IList<List<IChip>> Split(IList<IChip> chips)
        {
            var chipSets = new List<List<IChip>>();
            var chipSet = new List<IChip>();

            foreach (var chip in chips)
            {
                if (chip.HasValue)
                    chipSet.Add(chip);
                else
                {
                    if (chipSet.Count <= 0) continue;
                    chipSets.Add(chipSet);
                    chipSet = new List<IChip>();
                }
            }

            chipSets.Add(chipSet);

            return chipSets;
        }

        private void PopChipSet(IList<IChip> chipSet, IList<IChip> chipsToPop)
        {
            foreach (var chips in Split(chipSet))
            {
                foreach (var chip in chips)
                {
                    if (chip.Value == chips.Count)
                        chipsToPop.Add(chip);
                }
            }
        }

        public bool ChipsAreAnimating(Board board)
        {
            return GetPoppableChips(board).Any() || GetAnimatingChips(board).Any();
        }

        private IList<IChip> GetAnimatingChips(Board board)
        {
            var chips = new List<IChip>();
            foreach (var chip in board.All())
            { 
                if (chip.IsAnimating())
                    chips.Add(chip);
            }
            return chips;
        }
    }
}