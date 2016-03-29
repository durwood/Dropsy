namespace Dropsy.test
{
    public class BoxPrinter
    {
        private const int SpacesPerUnit = 3;

        public string Print(BoxModel model)
        {
            var output = CreateBoxEnd(model, PrintConstants.UpperLeft, PrintConstants.UpperRight);
            output += CreateMiddleOfBox(model);
            output += CreateBoxEnd(model, PrintConstants.LowerLeft, PrintConstants.LowerRight);

            return output;
        }

        private static string CreateBoxEnd(BoxModel model, char leftCorner, char rightCorner)
        {
            var output = leftCorner.ToString();
            for (var i = 0; i < model.EdgeLength*SpacesPerUnit; i++)
                output += PrintConstants.HorizontalBar;
            output += rightCorner + "\n";
            return output;
        }

        private static string CreateMiddleOfBox(BoxModel model)
        {
            var output = PrintConstants.VerticalBar.ToString();
            for (var i = 0; i < model.EdgeLength*SpacesPerUnit; i++)
                output += " ";
            output += PrintConstants.VerticalBar + "\n";
            return output;
        }
    }
}