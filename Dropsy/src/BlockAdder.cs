using System.Linq;

namespace Dropsy
{
    public class BlockAdder : IChipHandler
    {
        private int _turnCount;
        private const int TurnsBettweenBlocks = 5;
        private int _turnToAddBlocks = TurnsBettweenBlocks;

        public bool Go(Board board)
        {
            _turnToAddBlocks = _turnCount + TurnsBettweenBlocks;
            var gameOver = board.GetRow(0).Count(n => n.HasValue) > 0;
            board.RemoveTopRow();
            board.AddChipsToBottom(new BlockChip());
            return gameOver;
        }

        public bool HasPendingChips(Board board)
        {
            return _turnToAddBlocks == _turnCount;
        }

        public void TakeTurn()
        {
            _turnCount++;
        }
    }
}