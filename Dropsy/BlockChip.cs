namespace Dropsy
{
    public class BlockChip : IChip
    {
        public string Print()
        {
            return "█";
        }

        public bool HasValue
        {
            get
            {
                return true;
            }
        }

        public void Pop()
        {
        }

        public int Value => -1;
        public bool IsAnimating()
        {
            return false;
        }
    }
}