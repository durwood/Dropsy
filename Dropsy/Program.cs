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
            model.AddChip(Chip.CreateRandom(edgeLength));

            var controller = new Controller(new ConsoleWrapper(), model);
            controller.Run();
        }
    }

    internal class Chip : IChip
    {
        private readonly int _value;

        public Chip(int value)
        {
            _value = value;
        }

        public static IChip CreateRandom(int edgeLength)
        {
            return new Chip(new Random().Next(1, edgeLength));
        }

        public string print()
        {
            return _value == 0 ? " " : _value.ToString();
        }
    }
}