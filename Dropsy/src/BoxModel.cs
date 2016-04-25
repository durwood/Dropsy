using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    public class BoxModel
    {
        private readonly IChipFactory _chipFactory;
        private readonly List<List<IChip>> _rows;
        public readonly int EdgeLength;
        private int _turnCount;
        private IChip _unplacedChip;

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
            if (_unplacedChip == null)
                _unplacedChip = _chipFactory.Create(EdgeLength);
        }

        private void AddBlocks()
        {
            _turnCount++;
            if (_turnCount%5 == 0)
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

        public void PutChipInColumn(int column)
        {
            if (_rows[0][column].HasValue())
                return;

            AddBlocks();

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