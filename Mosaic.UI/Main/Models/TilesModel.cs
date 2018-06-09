using System.Collections.Generic;
using System.Linq;
using Mosaic.UI.Extensions;

namespace Mosaic.UI.Main.Models
{
    public class TilesModel
    {
        public IList<Tile> Tiles { get; set; }
        public Tile EmptyTile { get; set; }
        public int Rows { get; }
        public int Columns { get { return Rows; } }

        public TilesModel(int rows)
        {
            Rows = rows;
            StartNewGame();
        }

        private void StartNewGame()
        {
            int tilesAmount = Rows * Columns;
            Tiles = new List<Tile>();
            for (int i = 1; i < tilesAmount; i++)
            {
                Tiles.Add(new Tile()
                {
                    Value = i,
                    Status = TileStatus.Static,
                });
            }
            Tiles.Add(new Tile()
            {
                Value = tilesAmount,
                Status = TileStatus.Empty
            });
            EmptyTile = Tiles.Last();

            Tiles.Shuffle();
            for (int i = 0; i < tilesAmount; i++)
            {
                Tiles[i].Index = i;
            }
            FindMoveableTiles();
        }

        public void FindMoveableTiles()
        {
            foreach (var tile in Tiles)
            {
                if (tile.Status == TileStatus.Movable)
                    tile.Status = TileStatus.Static;
            }

            // locate "EmptyTile" 
            int row = EmptyTile.Index / Columns;
            int col = EmptyTile.Index % Columns;

            // Tells which "MovaleTiles" are avaleable relative to the deltas of "EmptyTile" 
            int[,] deltas = new int[,] { { -1, 0 }, { 1, 0 }, { 0, 1 }, { 0, -1} };
            for (int i = 0; i < deltas.GetLength(0); i++)
            {
                SetMoveableTile(row + deltas[i, 0], col + deltas[i, 1]);
            }
            //SetMoveableTile(row - 1, col); //up
            //SetMoveableTile(row + 1, col); //down
            //SetMoveableTile(row, col + 1); //right
            //SetMoveableTile(row, col - 1); //left
        }

        private void SetMoveableTile(int row, int col)
        {
            // if tile present out of the table range... do nothing
            if (row <= -1 || col <= -1 || row >= Rows || col >= Columns)
                return; 
            Tile tile = TileAtIndex(row * Columns + col);
            tile.Status = TileStatus.Movable;
        }

        public void MoveTileToEmptyness(int index)
        {
            Tile tile = TileAtIndex(index);
            tile.SwapWith(EmptyTile);
            FindMoveableTiles();
        }

        private Tile TileAtIndex(int index)
        {
            return Tiles.First(t => t.Index == index);
        }

        public bool IsInOrder()
        {
            return Tiles.All(t => t.Value == t.Index + 1);
        }

    }
}
