namespace Dropsy
{
    public class BlockChip : IChip
    {
        public string print()
        {
            return "█";
        }

        public bool HasValue()
        {
            return true;
        }
    }
}