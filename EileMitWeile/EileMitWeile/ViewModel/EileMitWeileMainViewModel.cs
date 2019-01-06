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

            //Removable | Onl< for test
            ActSpieler = "LALALALa";
            registerVisibility = Visibility.Hidden;
            DicedNumb = "5";
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
            set { SetProperty(ref _dicedNumb, "Gewürfelte Zahl: " + value); }
        }        

        private Color _actColor;
        public Color ActColour
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
            throw new NotImplementedException();
        }

        private void Dice()
        {
            //toDo
            ActSpieler = "DaNeZdrava";
        }
    }
}
