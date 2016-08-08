using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    public class BoxModel
    {
        private readonly IChipFactory _chipFactory;
        public readonly int EdgeLength;
        private bool _canReceiveInput = true;
        private bool _gameOver;
        private IChip _unplacedChip;
        private readonly BlockAdder _blockAdder;

        public BoxModel(int edgeLength, IChipFactory chipFactory, Board board)
        {
            EdgeLength = edgeLength;
            _chipFactory = chipFactory;
            Board = board;
            _blockAdder = new BlockAdder(Board);
        }

        public Board Board { get; }

        public void Advance()
        {
            if (_unplacedChip == null)
                _unplacedChip = _chipFactory.Create(EdgeLength);

            var chipPopper = new ChipPopper();
            var chipSweeper = new ChipSweeper();
            var chipDropper = new ChipDropper();

            if (chipSweeper.HasPendingChips(Board))
            {
                chipSweeper.Go(Board);
                _canReceiveInput = false;
            }
            else if (chipDropper.HasPendingChips(Board))
            {
                chipDropper.Go(Board);
                _canReceiveInput = false;
            }
            else if (chipPopper.HasPendingChips(Board))
            {
                chipPopper.Go(Board);
                _canReceiveInput = false;
            }
            else if(_blockAdder.IsTurnToAddBlocks())
            {
                _gameOver = _blockAdder.AddBlocks();
                _canReceiveInput = false;
            }
            else
                _canReceiveInput = true;
        }

        public IChip GetUnplacedChip()
        {
            return _unplacedChip;
        }

        public void PutChipInColumn(int column)
        {
            var chip = Board.GetChip(0, column);
            if (chip.HasValue)
                return;

            _blockAdder.TakeTurn();
            PutChipAtTopOfColumn(_unplacedChip, column);

            _unplacedChip = null;
        }

        private void PutChipAtTopOfColumn(IChip unplacedChip, int columnIndex)
        {
            var column = Board.GetColumn(columnIndex);
            column.Reverse();
            var rowIndex = EdgeLength;
            foreach (var chip in column)
            {
                rowIndex--;
                if (!chip.HasValue)
                {
                    Board.PlaceChip(rowIndex, columnIndex, unplacedChip);
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
            return Board.GetRow(row);
        }

        public bool GameOver()
        {
            var allChips = Board.All();
            return allChips.All(chip => chip.HasValue) || _gameOver;
        }

        public void Halt()
        {
            _gameOver = true;
        }

        public bool CanReceiveInput()
        {
            return _canReceiveInput;
        }
    }
}