using System;

namespace Dropsy
{
    public class BoxModel
    {
        public readonly int EdgeLength;
        private IChip _chip = null;
        private int _columnForChip = -1;

        public BoxModel(int edgeLength)
        {
            EdgeLength = edgeLength;
        }

        public void AddChip(IChip chip)
        {
            _chip = chip;
        }

        public IChip GetChip()
        {
            return _chip;
        }

        public void PutChipInColumn(int column)
        {
            _columnForChip = column;
        }

        public bool HasNoChip()
        {
            return _chip == null;
        }

        public bool HasChipIn(int column)
        {
            return _columnForChip == column;
        }
    }
}