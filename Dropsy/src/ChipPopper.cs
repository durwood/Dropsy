using System.Collections.Generic;

namespace Dropsy
{
    public class ChipPopper
    {
        public void Pop(List<List<IChip>> rows)
        {
            if (rows.Count == 1 && rows[0][0].print() == "1")
                rows[0][0] = new Chip(0);
        }
    }
}