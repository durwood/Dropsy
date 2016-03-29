namespace Dropsy.test
{
    public class BoxPrinter
    {
        private const int SpacesPerUnit = 3;
        private readonly IChip _chip;

        public BoxPrinter(IChip chip)
        {
            _chip = chip;
        }

        public string Print(BoxModel model)
        {
            var output = CreateChip(model);
            output += CreateBoxEnd(model, '┌', '┐');
            for (var i = 0; i < model.EdgeLength; i++)
                output += CreateMiddleOfBox(model);
            output += CreateBoxEnd(model, '└', '┘');
            output += CreateLabels(model);

            return output;
        }

        private string CreateChip(BoxModel model)
        {
            var spaces = model.EdgeLength*SpacesPerUnit + 2;
            var output = new char[spaces + 1];
            for (var i = 0; i < spaces; i++)
                output[i] = ' ';
            output[spaces] = '\n';
            output[spaces/2] = char.Parse(_chip.Random().ToString());
            return new string(output);
        }

        private string CreateLabels(BoxModel model)
        {
            var output = " ";
            for (var i = 0; i < model.EdgeLength; ++i)
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