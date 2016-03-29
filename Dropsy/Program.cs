using System;
using Dropsy.test;

namespace Dropsy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int edgeLength = 7;
            Console.Write(new BoxPrinter(new Chip(edgeLength)).Print(new BoxModel(edgeLength)));
            Console.ReadKey();
        }
    }

    internal class Chip : IChip
    {
        private readonly int _edgeLength;

        public Chip(int edgeLength)
        {
            _edgeLength = edgeLength;
        }

        public int Random()
        {
            return new Random().Next(1, _edgeLength);
        }
    }
}