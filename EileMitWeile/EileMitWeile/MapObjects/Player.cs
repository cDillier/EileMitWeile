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
        public IMapObject LastFieldBeforeColoredField { get; set; }
        public IMapObject CurrentField { get; set; }
        public Brush PlayerColor => Background;

        public Player(IMapObject lastFieldBeforeColoredField, IMapObject currentField, Brush playerColor)
        {
            this.LastFieldBeforeColoredField = lastFieldBeforeColoredField;
            this.CurrentField = currentField;
            Width = 15;
            Height = 15;
            BorderThickness = new Thickness(2);
            BorderBrush = Brushes.Black;
            Background = playerColor;
            CornerRadius = new CornerRadius(1000);
            MouseLeftButtonUp += border_MouseUp;
        }
       
        private void border_MouseUp(object sender, MouseButtonEventArgs e)
        {
            RemoveFromCurrentField();
            AddToNextField();

        }

        private void RemoveFromCurrentField()
        {
            (this.Parent as StackPanel).Children.Remove(this);
        }

        private void AddToNextField()
        {
            if (CurrentField.NextField != null)
            {
                switch (CurrentField.NextField.FieldType)
                {
                    case Enum.FieldType.Normal:
                        (CurrentField.NextField.Children[0] as StackPanel).Children.Add(this);
                        break;
                    case Enum.FieldType.SafeZone:
                        (CurrentField.NextField.Children[0] as StackPanel).Children.Add(this);
                        break;
                    case Enum.FieldType.Finish:
                        (CurrentField.NextField.Children[0] as StackPanel).Children.Add(this);
                        break;
                    case Enum.FieldType.Base:
                        (CurrentField.NextField.Children[0] as StackPanel).Children.Add(this);
                        break;
                }
                CurrentField = CurrentField.NextField;
            }
        }
    }
}
