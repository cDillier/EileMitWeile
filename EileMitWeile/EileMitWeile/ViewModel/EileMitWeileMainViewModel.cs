﻿using EileMitWeile.MapObjects;
using EileMitWeile.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace EileMitWeile.ViewModel
{
    public class EileMitWeileMainViewModel : ViewModelBase
    {
        Model.EileMitWeileMainModel model;

        public EileMitWeileMainViewModel()
        {
            this.model = new Model.EileMitWeileMainModel();
        }

        #region Properties
        private string _actPlayer;
        public string ActSpieler
        {
            get { return _actPlayer; }
            set { SetProperty(ref _actPlayer, value); }
        }

        private string _dicedNumb;
        public string DicedNumb
        {
            get { return _dicedNumb; }
            set { SetProperty(ref _dicedNumb, value); }
        }

        private Brush _actColor;
        public Brush ActColour
        {
            get { return _actColor; }
            set { SetProperty(ref _actColor, value); }
        }

        private Visibility _registerVisibility;
        public Visibility registerVisibility
        {
            get { return _registerVisibility; }
            set { SetProperty(ref _registerVisibility, value); }
        }

        private bool _rotChecked;
        public bool RotChecked
        {
            get { return _rotChecked; }
            set { SetProperty(ref _rotChecked, value); }
        }

        private bool _blauChecked;
        public bool BlauChecked
        {
            get { return _blauChecked; }
            set { SetProperty(ref _blauChecked, value); }
        }

        private bool _grünChecked;
        public bool GrünChecked
        {
            get { return _grünChecked; }
            set { SetProperty(ref _grünChecked, value); }
        }

        private bool _gelbChecked;
        public bool GelbChecked
        {
            get { return _gelbChecked; }
            set { SetProperty(ref _gelbChecked, value); }
        }

        private string _rotName;
        public string RotName
        {
            get { return _rotName; }
            set { SetProperty(ref _rotName, value); }
        }

        private string _blauName;
        public string BlauName
        {
            get { return _blauName; }
            set { SetProperty(ref _blauName, value); }
        }

        private string _grünName;
        public string GrünName
        {
            get { return _grünName; }
            set { SetProperty(ref _grünName, value); }
        }

        private string _gelbName;
        public string GelbName
        {
            get { return _gelbName; }
            set { SetProperty(ref _gelbName, value); }
        }

        private bool _nextPlayer;
        public bool NextPlayer
        {
            get { return _nextPlayer; }
            set
            {
                SetProperty(ref _nextPlayer, value);

                if (!string.IsNullOrEmpty(DicedNumb) && DicedNumb != "0")
                {
                    if (_nextPlayer == true)
                        SetNextPlayer();

                    DicedNumb = "0";
                }
            }
        }
        #endregion

        public Command DiceCmd
        {
            get
            {
                return new Command(() =>
                {
                    Dice();
                });
            }
        }

        public Command StartGameCmd
        {
            get
            {
                return new Command(() =>
                {
                    StartGame();
                });
            }
        }

        private void StartGame()
        {
            registerVisibility = Visibility.Hidden;

            var map = MapFactory.GetMap(Enum.MapName.FourPlayerMap);

            if (BlauChecked)
            {
                AddPlayers(map, 4, Brushes.Blue);
            }
            if (GelbChecked)
            {
                AddPlayers(map, 4, Brushes.Yellow);
            }
            if (GrünChecked)
            {
                AddPlayers(map, 4, Brushes.Green);
            }
            if (RotChecked)
            {
                AddPlayers(map, 4, Brushes.Red);
            }



            ActColour = Brushes.Red;
            ActSpieler = RotName;
        }

        private void AddPlayers(IMap map, int amount, Brush color)
        {
            for (int i = 0; i < amount; i++)
            {
                map.SendPlayerToBase(new Player(color));
            }
        }

        private void Dice()
        {
            DicedNumb = this.model.Dice();
        }

        private void SetNextPlayer()
        {
            if (Color.Equals(ActColour, Brushes.Red))
            {
                ActColour = Brushes.Blue;
                ActSpieler = BlauName;
                if (!BlauChecked) SetNextPlayer();
            }
            else if (Color.Equals(ActColour, Brushes.Blue))
            {
                ActColour = Brushes.Yellow;
                ActSpieler = GelbName;
                if (!GelbChecked) SetNextPlayer();
            }
            else if (Color.Equals(ActColour, Brushes.Yellow))
            {
                ActColour = Brushes.Green;
                ActSpieler = GrünName;
                if (!GrünChecked) SetNextPlayer();
            }
            else if (Color.Equals(ActColour, Brushes.Green))
            {
                ActColour = Brushes.Red;
                ActSpieler = RotName;
                if (!RotChecked) SetNextPlayer();
            }
        }
    }
}
