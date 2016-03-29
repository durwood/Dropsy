using System;
using Dropsy.test;

namespace Dropsy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.Write(new BoxPrinter().Print(new BoxModel(7)));
            Console.ReadKey();
        }
    }
}