using System.Linq;
using System.Collections.Generic;

namespace Dropsy
{
    public class BoxModel
    {
        public readonly int EdgeLength;
        private readonly IChipFactory _chipFactory;
        private readonly List<List<IChip>> _rows;
        private IChip _unplacedChip;
        private int _turnCount;

        public BoxModel(int edgeLength, IChipFactory chipFactory)
        {
            EdgeLength = edgeLength;
            _chipFactory = chipFactory;

            _rows = new List<List<IChip>>();
            for (var i = 0; i < EdgeLength; i++)
            {
                AddChipsToBottom(new Chip(0));
            }
        }

        private void AddChipsToBottom(IChip chip)
        {
            var chips = new List<IChip>();
            _rows.Add(chips);
            for (var j = 0; j < EdgeLength; j++)
            {
                chips.Add(chip);
            }
        }

        public void AddUnplacedChip()
        {
            _turnCount++;
            _unplacedChip = _chipFactory.Create(EdgeLength);

            if (_turnCount == 5)
                AddBlocksToBottomRow();
        }

        private void AddBlocksToBottomRow()
        {
            RemoveTopRow();
            AddChipsToBottom(new BlockChip());
        }

        private void RemoveTopRow()
        {
            _rows.RemoveAt(0);
        }

        public IChip GetUnplacedChip()
        {
            return _unplacedChip;
        }

        internal void AddUnplacedChip(IChip chip)
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

        public bool GameOver()
        {
            return _rows.All(row => row.Count(chip => chip.HasValue()) == EdgeLength);
        }
    }
}