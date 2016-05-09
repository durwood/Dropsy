using System;

namespace Dropsy
{
    public class Chip : IChip
    {
        private int _value;

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

        public void Pop()
        {
            _value = 0;
        }
    }

    public class ChipFactory : IChipFactory
    {
        public IChip Create(int edgeLength)
        {
            return Chip.CreateRandom(edgeLength);
        }
    }

    public interface IChipFactory
    {
        IChip Create(int edgeLength);
    }
}