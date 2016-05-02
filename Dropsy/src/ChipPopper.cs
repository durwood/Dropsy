using System.Collections.Generic;

namespace Dropsy
{
    public class ChipPopper
    {
        public void Pop(List<List<IChip>> board)
        {
            if (board.Count == 1 && board[0][0].print() == "1")
                board[0][0] = new Chip(0);
        }
    }
}