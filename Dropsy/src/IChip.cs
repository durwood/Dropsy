namespace Dropsy
{
    public interface IChip
    {
        string Print();
        bool HasVolume();
        bool HasValue { get; }

        void Pop();
        int Value { get; }
        bool IsAnimating();
        void StopAnimating();
    }
}