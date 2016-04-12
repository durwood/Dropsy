using System;

namespace Dropsy
{
    public class Chip : IChip
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
            return HasValue() ? _value.ToString(): " ";
        }

        public bool HasValue()
        {
            return _value != 0;
        }
    }
}