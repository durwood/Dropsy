namespace Dropsy
{
    public class BoxPrinter
    {
        private const int SpacesPerUnit = 3;
        private readonly BoxModel _model;

        public BoxPrinter(BoxModel model)
        {
            _model = model;
        }

        public string Print()
        {
            var output = PrintChipLine();

            output += PrintBoxEnd(_model, '┌', '┐');
            for (var i = 0; i < _model.EdgeLength; i++)
                output += PrintMiddleOfBox(_model);
            output += PrintBoxEnd(_model, '└', '┘');
            output += PrintLabels();

            return output;
        }

        private string PrintChipLine()
        {
            if (_model.HasNoChip())
                return "";

            var spaces = _model.EdgeLength*SpacesPerUnit + 2;
            var output = new char[spaces + 1];
            for (var i = 0; i < spaces; i++)
                output[i] = ' ';
            output[spaces] = '\n';
            output[spaces/2] = char.Parse(_model.GetChip().Random().ToString());
            return new string(output);
        }

        private string PrintLabels()
        {
            var output = " ";
            for (var i = 0; i < _model.EdgeLength; ++i)
                output += " " + (i + 1) + " ";
            output += " \n";
            return output;
        }

        private static string PrintBoxEnd(BoxModel model, char leftCorner, char rightCorner)
        {
            var output = leftCorner.ToString();
            for (var i = 0; i < model.EdgeLength*SpacesPerUnit; i++)
                output += '─';
            output += rightCorner + "\n";
            return output;
        }

        private static string PrintMiddleOfBox(BoxModel model)
        {
            var output = '│'.ToString();
            for (var i = 0; i < model.EdgeLength*SpacesPerUnit; i++)
                output += " ";
            output += '│' + "\n";
            return output;
        }
    }
}