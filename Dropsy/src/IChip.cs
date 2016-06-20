namespace Dropsy
{
    public interface IChip
    {
        string Print();
        bool HasValue { get; }

        void Pop();
        int Value { get; }
        bool IsAnimating();
    }
}