using System;
using Dropsy.test;

namespace Dropsy
{
    public class Controller
    {
        private readonly IConsoleWrapper _console;
        private readonly BoxModel _model;

        public Controller(IConsoleWrapper console, BoxModel model)
        {
            _console = console;
            _model = model;
        }

        public void Run()
        {
            do
            {
                _model.AddUnplacedChip();
                Print();
                if (_model.GameOver())
                    break;
            } while (GetInput());
        }

        private bool GetInput()
        {
            var input = _console.Read();
            if (input == 'q')
                return false;
            _model.PutChipInColumn(GetSelectedColumn(input));
            return true;
        }

        private void Print()
        {
            _console.Clear();
            _console.Write(new BoxPrinter(_model).Print());
        }

        private int GetSelectedColumn(char column)
        {
            return int.Parse(column.ToString()) - 1;
        }
    }
}