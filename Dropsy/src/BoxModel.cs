namespace Dropsy
{
    public class BoxModel
    {
        public readonly int EdgeLength;
        private IChip _chip;

        public BoxModel(int edgeLength)
        {
            EdgeLength = edgeLength;
        }

        public void AddChip(IChip chip)
        {
            _chip = chip;
        }

        public IChip GetChip()
        {
            return _chip;
        }
    }
}