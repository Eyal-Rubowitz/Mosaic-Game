using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mosaic.UI.Main.Models;

namespace Mosaic.UI.Main.ViewModels
{
    public class TileViewModel
    {
        private Tile _tile;

        public TileStatus Status { get { return _tile.Status; } }
        public int Index { get { return _tile.Index; } }
        public int Value { get { return _tile.Value; } }
        
        public TileViewModel(Tile tile)
        {
            _tile = tile;
        }

        public string TemplateName
        {
            get {
                switch (Status)
                {
                    case TileStatus.Empty:
                        return "HiddenTileTemplate";
                    case TileStatus.Movable:
                        return "MoveableTileTemplate";
                    default:
                        return "VisibleTileTemplate";

                }
            }
        }


    }


}
