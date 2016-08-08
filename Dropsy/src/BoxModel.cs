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

        private List<IChipHandler> _chipHandlers = new List<IChipHandler>();
        private BlockAdder _blockAdder = new BlockAdder();

        public BoxModel(int edgeLength, IChipFactory chipFactory, Board board)
        {
            EdgeLength = edgeLength;
            _chipFactory = chipFactory;
            Board = board;
            _chipHandlers.Add(new ChipPopper());
            _chipHandlers.Add(new ChipSweeper());
            _chipHandlers.Add(new ChipDropper());
            _chipHandlers.Add(_blockAdder);
        }

        public Board Board { get; }

        public void Advance()
        {
            if (_unplacedChip == null)
                _unplacedChip = _chipFactory.Create(EdgeLength);

            _canReceiveInput = true;
            foreach (var chipHandler in _chipHandlers)
            {
                if (chipHandler.HasPendingChips(Board))
                {
                    _gameOver = chipHandler.Go(Board);
                    _canReceiveInput = false;
                    break;
                }
            }
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