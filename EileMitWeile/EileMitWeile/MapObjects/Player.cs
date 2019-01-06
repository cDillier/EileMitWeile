using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EileMitWeile.MapObjects
{
    public class Player : Border
    {
        public Player(IMapObject firstColorFiled, IMapObject currentField, Color playerColor)
        {
            BorderThickness = new Thickness(2);
            BorderBrush = Brushes.Black;
            Background = Brushes.Red;
            CornerRadius = new CornerRadius(1000);
        }

        
    }
}
