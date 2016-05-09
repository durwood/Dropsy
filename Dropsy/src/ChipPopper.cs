using System.Collections.Generic;

namespace Dropsy
{
    public class ChipPopper
    {
        public void Pop(Board board)
        {
            if (board.GetChip(0,0).print() == "1")
                board.PlaceChip(0, 0, new Chip(0));
        }
    }
}