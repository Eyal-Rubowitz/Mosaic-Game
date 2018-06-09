namespace Mosaic.UI.Main.Models
{
    public class Tile
    {
        public TileStatus Status { get; set; }
        public int Index { get; set; }
        public int Value { get; set; }

        public void SwapWith(Tile tile)
        {
            int tmp = tile.Index;
            tile.Index = Index;
            Index = tmp;
        }
    }
}
