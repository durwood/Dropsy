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

        public IChip GetUnplacedChip()
        {
            return _unplacedChip;
        }

        internal void AddChip(IChip chip)
        {
            _unplacedChip = chip;
        }

        public void PutChipInColumn(int column)
        {
            for (var row = EdgeLength - 1; row >= 0; row--)
            {
                if (_rows[row][column].HasValue()) continue;
                _rows[row][column] = _unplacedChip;
                break;
            }

            _unplacedChip = null;
        }

        public bool HasNoUnplacedChip()
        {
            return _unplacedChip == null;
        }

        public List<IChip> GetRow(int row)
        {
            return _rows[row];
        }
    }
}