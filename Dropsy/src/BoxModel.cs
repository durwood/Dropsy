using System;

namespace Dropsy
{
    public class BoxModel
    {
        public readonly int EdgeLength;
        private IChip _chip = null;

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

        public void PutChipInColumn(ConsoleKeyInfo key)
        {
            throw new NotImplementedException();
        }

        public bool HasNoChip()
        {
            return _chip == null;
        }
    }
}