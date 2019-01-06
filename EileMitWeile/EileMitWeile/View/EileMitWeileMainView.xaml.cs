using EileMitWeile.MapObjects;
using EileMitWeile.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EileMitWeile.View
{
	/// <summary>
	/// Interaktionslogik für EileMitWeileMainView.xaml
	/// </summary>
	public partial class EileMitWeileMainView : Window
	{
        public EileMitWeileMainView()
        {
            InitializeComponent();

            this.DataContext = new ViewModel.EileMitWeileMainViewModel();
            mapGrid.Children.Add(MapFactory.GetMap(Enum.MapName.FourPlayerMap));
            //mapGrid.Children.Add(new Player(null, null, Brushes.Red.Color));

        }
    }
}
