using System.Linq;

namespace Dropsy
{
    public class BlockAdder
    {
        private readonly Board _board;
        private int _turnCount;
        private const int TurnsBettweenBlocks = 5;
        private int _turnToAddBlocks = TurnsBettweenBlocks;

        public BlockAdder(Board board)
        {
            _board = board;
        }

        public bool AddBlocks()
        {
            _turnToAddBlocks = _turnCount + TurnsBettweenBlocks;
            var gameOver = _board.GetRow(0).Count(n => n.HasValue) > 0;
            _board.RemoveTopRow();
            _board.AddChipsToBottom(new BlockChip());
            return gameOver;
        }

        public bool IsTurnToAddBlocks()
        {
            return _turnToAddBlocks == _turnCount;
        }

        public void TakeTurn()
        {
            _turnCount++;
        }
    }
}