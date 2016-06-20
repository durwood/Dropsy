using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    public class BoxModel
    {
        private const int TurnsBettweenBlocks = 5;
        private readonly Board _board;
        private readonly IChipFactory _chipFactory;
        public readonly int EdgeLength;
        private bool _gameOver;
        private int _turnCount;
        private IChip _unplacedChip;

        public BoxModel(int edgeLength, IChipFactory chipFactory, Board board)
        {
            EdgeLength = edgeLength;
            _chipFactory = chipFactory;
            _board = board;
        }

        public void Advance()
        {
            if (_unplacedChip == null)
                _unplacedChip = _chipFactory.Create(EdgeLength);
        }

        private void AddBlocks()
        {
            _turnCount++;
            if (IsTurnToAddBlocks())
                AddBlocksToBottomRow();
        }

        private bool IsTurnToAddBlocks()
        {
            return _turnCount%TurnsBettweenBlocks == 0;
        }

        private void AddBlocksToBottomRow()
        {
            RemoveTopRow();
            _board.AddChipsToBottom(new BlockChip());
        }

        private void RemoveTopRow()
        {
            _gameOver = _board.GetRow(0).Count(n => n.HasValue()) > 0;
            _board.RemoveTopRow();
        }

        public IChip GetUnplacedChip()
        {
            return _unplacedChip;
        }

        public void PutChipInColumn(int column)
        {
            var chip = _board.GetChip(0, column);
            if (chip.HasValue())
                return;

            AddBlocks();
            PutChipAtTopOfColumn(_unplacedChip, column);

            new ChipPopper().PopChips(_board);
            new ChipDropper().DropChips(_board);

            _unplacedChip = null;
        }

        private void PutChipAtTopOfColumn(IChip unplacedChip, int columnIndex)
        {
            var column = _board.GetColumn(columnIndex);
            column.Reverse();
            var rowIndex = EdgeLength;
            foreach (var chip in column)
            {
                rowIndex--;
                if (!chip.HasValue())
                {
                    _board.PlaceChip(rowIndex, columnIndex, unplacedChip);
                    break;
                }
            }
        }

        public bool HasNoUnplacedChip()
        {
            return _unplacedChip == null;
        }

        public List<IChip> GetRow(int row)
        {
            return _board.GetRow(row);
        }

        public bool GameOver()
        {
            var allChips = _board.All();
            return allChips.All(chip => chip.HasValue()) || _gameOver;
        }

        public void Halt()
        {
            _gameOver = true;
        }

        public bool CanReceiveInput()
        {
            return true;
        }
    }
}