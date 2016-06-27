using System.Threading;

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
                _model.Advance();
                Print();
                if (_model.CanReceiveInput())
                    GetInput();
                else
                    Thread.Sleep(500);
            } while (!_model.GameOver());
        }

        private void GetInput()
        {
            var input = _console.Read();
            if (input == 'q')
                _model.Halt();
            else
                _model.PutChipInColumn(GetSelectedColumn(input));
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