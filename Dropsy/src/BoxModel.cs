using System.Collections.Generic;

namespace Dropsy
{
    public class BoxModel
    {
        public readonly int EdgeLength;
        private readonly List<List<IChip>> _rows;
        private IChip _unplacedChip;

        public BoxModel(int edgeLength)
        {
            EdgeLength = edgeLength;

            _rows = new List<List<IChip>>();
            for (var i = 0; i < EdgeLength; i++)
            {
                var chips = new List<IChip>();
                _rows.Add(chips);
                for (var j = 0; j < EdgeLength; j++)
                {
                    chips.Add(new Chip(0));
                }
            }
        }

        public void AddChip()
        {
            _unplacedChip = Chip.CreateRandom(EdgeLength);
        }

        public IChip GetChip()
        {
            return _unplacedChip;
        }

        internal void AddChip(IChip chip)
        {
            _unplacedChip = chip;
        }

        public void PutChipInColumn(int column)
        {
            _rows[EdgeLength - 1][column] = _unplacedChip;
            _unplacedChip = null;
        }

        public bool HasNoChip()
        {
            return _unplacedChip == null;
        }

        public bool HasChipIn(int column)
        {
            return _rows[EdgeLength - 1][column].HasValue();
        }

        public List<IChip> GetRow(int row)
        {
            return _rows[row];
        }
    }
}