namespace Dropsy
{
    public interface IChip
    {
        string print();
        bool HasValue();
        void Pop();
        int Value { get; }
    }
}