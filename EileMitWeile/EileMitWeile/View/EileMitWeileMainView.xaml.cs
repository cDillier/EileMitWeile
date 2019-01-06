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

            //this.DataContext = new ViewModel.EileMitWeileMainViewModel();
            var fourPlayerMap = new FourPlayerMap();
            var map = fourPlayerMap.CreateMap();

            UniformGrid yellowUniGrid = map[3] as UniformGrid;
            UniformGrid redUniGrid = map[0] as UniformGrid;
            UniformGrid blueUniGrid = map[1] as UniformGrid;
            UniformGrid greenUniGrid = map[2] as UniformGrid;

            
            Grid.SetColumn(redUniGrid, 1);
            Grid.SetRow(redUniGrid, 0);
            Grid.SetColumnSpan(redUniGrid, 3);
            Grid.SetRowSpan(redUniGrid, 2);

            Grid.SetColumn(blueUniGrid, 3);
            Grid.SetRow(blueUniGrid, 1);
            Grid.SetColumnSpan(blueUniGrid, 2);
            Grid.SetRowSpan(blueUniGrid, 3);

            Grid.SetColumn(greenUniGrid, 0);
            Grid.SetRow(greenUniGrid, 1);
            Grid.SetColumnSpan(greenUniGrid, 2);
            Grid.SetRowSpan(greenUniGrid, 3);

            Grid.SetColumn(yellowUniGrid, 1);
            Grid.SetRow(yellowUniGrid, 3);
            Grid.SetColumnSpan(yellowUniGrid, 3);
            Grid.SetRowSpan(yellowUniGrid, 2);

            mapGrid.Children.Add(greenUniGrid);
            mapGrid.Children.Add(yellowUniGrid);
            mapGrid.Children.Add(blueUniGrid);
            mapGrid.Children.Add(redUniGrid);

            var bases = fourPlayerMap.CreateBorders();
            var redBase = bases[0];
            var blueBase = bases[1];
            var greenBase = bases[2];
            var yellowBase = bases[3];

            Grid.SetColumn(redBase, 0);
            Grid.SetRow(redBase, 0);
            Grid.SetColumn(blueBase, 4);
            Grid.SetRow(blueBase, 0);
            Grid.SetColumn(greenBase, 0);
            Grid.SetRow(greenBase, 4);
            Grid.SetColumn(yellowBase, 4);
            Grid.SetRow(yellowBase, 4);

            mapGrid.Children.Add(redBase);
            mapGrid.Children.Add(blueBase);
            mapGrid.Children.Add(greenBase);
            mapGrid.Children.Add(yellowBase);
        }
    }
}
