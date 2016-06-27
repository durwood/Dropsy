using System;

namespace Dropsy
{
    public class Chip : IChip
    {
        private bool _animating;

        public Chip(int value)
        {
            Value = value;
        }

        public string Print()
        {
            if (_animating)
                return "*";

            if (HasValue)
                return Value.ToString();
            return " ";
        }

        public bool HasVolume()
        {
            return _animating || HasValue;
        }

        public bool HasValue => Value != 0;

        public void Pop()
        {
            Value = 0;
            _animating = true;
        }

        public int Value { get; private set; }

        public bool IsAnimating()
        {
            return _animating;
        }

        public static IChip CreateRandom(int edgeLength)
        {
            return new Chip(new Random().Next(1, edgeLength));
        }

        public void StopAnimating()
        {
            _animating = false;
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