namespace Dropsy
{
    public class BoxPrinter
    {
        private BoxModel _model;
        private const int SpacesPerUnit = 3;

        public BoxPrinter(BoxModel model)
        {
            _model = model;

        }

        public string Print()
        {
            var output = CreateChip();
            output += CreateBoxEnd(_model, '┌', '┐');
            for (var i = 0; i < _model.EdgeLength; i++)
                output += CreateMiddleOfBox(_model);
            output += CreateBoxEnd(_model, '└', '┘');
            output += CreateLabels();

            return output;
        }

        private string CreateChip()
        {
            var spaces = _model.EdgeLength*SpacesPerUnit + 2;
            var output = new char[spaces + 1];
            for (var i = 0; i < spaces; i++)
                output[i] = ' ';
            output[spaces] = '\n';
            output[spaces/2] = char.Parse(_model.GetChip().Random().ToString());
            return new string(output);
        }

        private string CreateLabels()
        {
            var output = " ";
            for (var i = 0; i < _model.EdgeLength; ++i)
                output += " " + (i + 1) + " ";
            output += " \n";
            return output;
        }

        private static string CreateBoxEnd(BoxModel model, char leftCorner, char rightCorner)
        {
            var output = leftCorner.ToString();
            for (var i = 0; i < model.EdgeLength*SpacesPerUnit; i++)
                output += '─';
            output += rightCorner + "\n";
            return output;
        }

        private static string CreateMiddleOfBox(BoxModel model)
        {
            var output = '│'.ToString();
            for (var i = 0; i < model.EdgeLength*SpacesPerUnit; i++)
                output += " ";
            output += '│' + "\n";
            return output;
        }
    }
}