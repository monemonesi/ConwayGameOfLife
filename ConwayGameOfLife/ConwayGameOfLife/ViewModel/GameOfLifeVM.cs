using ConwayGameOfLife.Model;
using ConwayGameOfLife.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ConwayGameOfLife.ViewModel
{

    public class GameOfLifeVM
    {
        private readonly int _initialTotalRows = Constants.TOTAL_ROWS;
        private readonly int _initialTotalColumns = Constants.TOTAL_COLUMNS;
        

        public GameOfLifeWorld GameOfLifeWorld { get;}

        public RelayCommand ToggleCellStateCommand { get; set; }
        public RelayCommand StartGameCommand { get; set; }
        public RelayCommand StopGameCommand { get; set; }
        public RelayCommand ResetGameCommand { get; set; }

        #region constructor
        public GameOfLifeVM()
        {

            GameOfLifeWorld = new GameOfLifeWorld(_initialTotalRows, _initialTotalColumns);
            //GameOfLifeWorld.PropertyChanged += OnGameOfLifeWorldPropertyChanged;

            //initialize Commands
            ToggleCellStateCommand = new RelayCommand(OnToggleCellState, canExecute => OnCanExecute());
            StartGameCommand = new RelayCommand(param => OnStartGame(), canExecute => OnCanExecute());
            ResetGameCommand = new RelayCommand(param => OnResetGame(), canExecute => true);
            StopGameCommand = new RelayCommand(param => OnStopGame(), canExecute => OnCanExecute());
        }

        #endregion

        #region methods
        //private bool CanStartGame(object arg)
        //{
        //    return GameOfLifeWorld != null && !GameOfLifeWorld.IsGameRunning;
        //}

        //private void OnStartGame(object obj)
        //{
        //    GameOfLifeWorld.StartGame();
        //}

        private void OnStopGame()
        {
            if (GameOfLifeWorld != null)
            {
                GameOfLifeWorld.StopGame();
            }
        }

        private void OnResetGame()
        {
            if (GameOfLifeWorld != null)
            {
                GameOfLifeWorld.ResetGame();
            }
        }


        private bool OnCanExecute()
        {
            return GameOfLifeWorld != null && !GameOfLifeWorld.IsGameRunning;
        }

        private void OnStartGame()
        {
            GameOfLifeWorld.StartGame();
        }


        public bool CanToggleCellState(object arg)
        {
            return GameOfLifeWorld != null && !GameOfLifeWorld.IsGameRunning;
        }

        private void OnToggleCellState(object arg)
        {

            Point pointer = Mouse.GetPosition((IInputElement)arg);
            double gridWidthInPixel = ((ItemsControl)arg).ActualWidth;
            double gridHeightInPixel = ((ItemsControl)arg).ActualHeight;

            GameOfLifeWorld.ToggleCellState(pointer, gridWidthInPixel, gridHeightInPixel);
        }



        private void OnGameOfLifeWorldPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ToggleCellStateCommand.RaiseCanExecuteChanged();
        }



        #endregion



    }
}
