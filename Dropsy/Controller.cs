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
            var key = GetSelectedColumn();
            //Console.Write("Select a colun for the chip");
            //model.PutChipInColumn(key);

        }

        private int GetSelectedColumn()
        {
            return _console.Read();
        }
    }
}