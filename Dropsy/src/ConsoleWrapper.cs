using System;

namespace Dropsy
{
    public class ConsoleWrapper
    {
        public virtual void Write(string output)
        {
            Console.Write(output);
        }

        public virtual char Read()
        {
            return Console.ReadKey(true).KeyChar;
        }
    }
}