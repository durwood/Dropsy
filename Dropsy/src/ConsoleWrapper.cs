using System;

namespace Dropsy
{
    public class ConsoleWrapper : IConsoleWrapper
    {
        public ConsoleWrapper()
        {
            Console.CursorVisible = false;
        }

        public virtual void Write(string output)
        {
            Console.Write(output);
        }

        public virtual char Read()
        {
            return Console.ReadKey(true).KeyChar;
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}