using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace EileMitWeile.MapObjects
{
    public class Player : Border
    {
        private IMapObject FirstColorFiled;
        private IMapObject CurrentField;

        public Player(IMapObject firstColorFiled, IMapObject currentField, Color playerColor)
        {
            this.FirstColorFiled = firstColorFiled;
            this.CurrentField = currentField;

            BorderThickness = new Thickness(2);
            BorderBrush = Brushes.Black;
            Background = Brushes.Red;
            CornerRadius = new CornerRadius(1000);
            MouseUp += border_MouseUp;
            
        }

        private void border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            CurrentField.NextField.Children.Add(this);
        }
    }
}
