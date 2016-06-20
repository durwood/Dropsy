using System.Collections.Generic;
using System.Linq;

namespace Dropsy
{
    public class Board
    {
        public readonly int EdgeLength;
        private readonly List<List<IChip>> _rows;

        public Board(int edgeLength)
        {
            _rows = new List<List<IChip>>();
            EdgeLength = edgeLength;
            for (var i = 0; i < edgeLength; i++)
            {
                AddChipsToBottom(new Chip(0));
            }
        }

        public void AddChipsToBottom(IChip chip)
        {
            var chips = new List<IChip>();
            _rows.Add(chips);
            for (var j = 0; j < EdgeLength; j++)
            {
                chips.Add(chip);
            }
        }

        public List<IChip> GetRow(int i)
        {
            return _rows[i];
        }

        public override string ToString()
        {
            string result = "";
            foreach (var row in _rows)
                result += row.Select(chip => chip.Print() + ", ") + "\n";
            return result;
        }

        public void RemoveTopRow()
        {
            _rows.RemoveAt(0);
        }

        public IChip GetChip(int row, int column)
        {
            return _rows[row][column];
        }

        public List<IChip> GetColumn(int columnIndex)
        {
            return _rows.Select(row => row[columnIndex]).ToList();
        }

        public void PlaceChip(int rowIndex, int columnIndex, IChip chip)
        {
            _rows[rowIndex][columnIndex] = chip;
        }

        public List<IChip> All()
        {
            return _rows.SelectMany(r => r).ToList();
        }

        public void SetColumn(int columnIndex, List<IChip> column)
        {
            var rowIndex = _rows.Count - 1;
            foreach (var row in _rows)
            {
                if (rowIndex >= column.Count)
                    row[columnIndex] = new Chip(0);
                else
                    row[columnIndex] = column[rowIndex];
                rowIndex--;
            }
        }
    }
}