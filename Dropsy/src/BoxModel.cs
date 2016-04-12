using System;
using System.Collections;
using System.Collections.Generic;

namespace Dropsy
{
    public class BoxModel
    {
        public readonly int EdgeLength;
        private IChip _chip = null;
        private int _columnForChip = -1;
        private List<List<IChip>> _rows;

        public BoxModel(int edgeLength)
        {
            EdgeLength = edgeLength;

            _rows = new List<List<IChip>>();
            for (int i = 0; i < EdgeLength; i++)
            {
                var chips = new List<IChip>();
                _rows.Add(chips);
                for (int j = 0; j < EdgeLength; j++)
                {
                    chips.Add(new Chip(0));
                }
            }
        }

        public void AddChip(IChip chip)
        {
            _chip = chip;
        }

        public IChip GetChip()
        {
            return _chip;
        }

        public void PutChipInColumn(int column)
        {
            _columnForChip = column;
        }

        public bool HasNoChip()
        {
            return _chip == null;
        }

        public bool HasChipIn(int column)
        {
            return _columnForChip == column;
        }

        public List<IChip> GetRow(int row)
        {
            return _rows[row];
        }
    }
}