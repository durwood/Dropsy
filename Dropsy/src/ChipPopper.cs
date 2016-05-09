using System.Collections.Generic;

namespace Dropsy
{
    public class ChipPopper
    {
        public void PopChips(Board board)
        {
            foreach (var chip in board.All())
            {
                if (chip.print() == "1")
                    chip.Pop();
            }

        }
    }
}