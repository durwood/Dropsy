using System;
using Dropsy.test;

namespace Dropsy
{
    public class Controller
    {
        private readonly ConsoleWrapper _console;
        private readonly BoxModel _model;

        public Controller(ConsoleWrapper console, BoxModel model)
        {
            _console = console;
            _model = model;
        }

        public void Run()
        {
            _console.Write(new BoxPrinter(_model).Print());
            _console.Write("Select a colun for the chip");
            _model.PutChipInColumn(GetSelectedColumn());
        }

        private int GetSelectedColumn()
        {
            var column = _console.Read();
            return int.Parse(column.ToString()) - 1;
        }
    }
}