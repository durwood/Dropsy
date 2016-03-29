namespace Dropsy.test
{
    public class BoxPrinter
    {
        private const int SpacesPerUnit = 3;

        public string Print(BoxModel model)
        {
            var output = CreateBoxEnd(model, '┌', '┐');
            for (var i = 0; i < model.EdgeLength; i++)
                output += CreateMiddleOfBox(model);
            output += CreateBoxEnd(model, '└', '┘');

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