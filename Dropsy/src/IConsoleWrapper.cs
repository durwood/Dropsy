namespace Dropsy
{
    public interface IConsoleWrapper
    {
        void Write(string output);
        char Read();
        void Clear();
    }
}