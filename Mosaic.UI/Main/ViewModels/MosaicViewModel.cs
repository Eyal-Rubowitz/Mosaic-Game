using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Mosaic.UI.Utils;
using Mosaic.UI.Main.Models;

namespace Mosaic.UI.Main.ViewModels
{
    public class MosaicViewModel : ViewModelBase
    {

        private Range _rowsRange;
        private int _rows;
        private TilesModel _tilesModel;
        private int _moves;

        public int Rows
        {
            get { return _rows; }
            set
            {
                _rows = value;
                RaisePropertyChanged();
            }
        }
        public int Columns
        {
            get { return _rows; }
        }
        public string Message
        {
            get
            {
                return $"Enter number of rows ({_rowsRange._min} - {_rowsRange._max})";
            }
        }
        public IList<TileViewModel> Tiles
        {
            get {
                if (TilesModel == null)
                {
                    return new List<TileViewModel>();
                } else
                {
                    return TilesModel.Tiles.
                        Select(t => new TileViewModel(t)).
                        OrderBy(t => t.Index).
                        ToList();
                }
            }
            set
            {
                RaisePropertyChanged();
            }
        }
        private TilesModel TilesModel
        {
            get { return _tilesModel; }
        }
        public int Moves
        {
            get { return _moves; }
            set
            {
                _moves = value;
                RaisePropertyChanged();
            }
        }
        public ICommand Start { get; set; }
        public ICommand MoveTile { get; set; }

        public MosaicViewModel()
        {
            _rowsRange = new Range() { _min = 3, _max = 10 };

            Start = new RelayCommand(StartNewGame, 
                () => _rowsRange.Contains(Rows)
                );
            MoveTile = new RelayCommand<int>(MoveTileToEmptyZone);
        }

        private void StartNewGame()
        {
            _tilesModel = new TilesModel(Rows);
            Moves = 0;
            RefreshView();
        }

        private void RefreshView()
        {
            Tiles = new List<TileViewModel>(); // triggers RaisePropertyChanged
        }

        private void MoveTileToEmptyZone(int index)
        {
            TilesModel.MoveTileToEmptyness(index);
            RefreshView();
            Moves++;
            CheckWinsCondition();
        }

        private void CheckWinsCondition()
        {
            if (TilesModel.IsInOrder())
            {

                MessageBox.Show($"Total moves: {Moves}", "Game completed!", MessageBoxButton.OK);
                Rows = 0;
                Moves = 0;
            }
        }
    }
}
