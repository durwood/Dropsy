namespace Dropsy
{
    public class BlockChip : IChip
    {
        public string Print()
        {
            return "█";
        }

        public bool HasVolume()
        {
            return true;
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

        public void StopAnimating()
        {
        }
    }
}