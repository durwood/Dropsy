namespace Dropsy.test
{
    public static class BoxModelExtensionsForTest
    {
        internal static void PutChipOnBoard(this BoxModel model, int column)
        {
            model.AddUnplacedChip();
            model.PutChipInColumn(column);
        }
    }
}