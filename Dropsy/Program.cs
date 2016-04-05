using System;
using Dropsy.test;
using NUnit.Framework.Api;

namespace Dropsy
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int edgeLength = 7;
            var model = new BoxModel(edgeLength);
            model.AddChip(new Chip(edgeLength));

            var controller = new Controller(new ConsoleWrapper(), model);
            controller.Run();
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