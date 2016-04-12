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
                _model.AddChip();
                Print();
                GetInput();

                _model.AddChip();
                Print();
                GetInput();
        }

        private void GetInput()
        {
            _model.PutChipInColumn(GetSelectedColumn());
        }

        private void Print()
        {
            _console.Clear();
            _console.Write(new BoxPrinter(_model).Print());
        }

        private int GetSelectedColumn()
        {
            var column = _console.Read();
            return int.Parse(column.ToString()) - 1;
        }
    }
}