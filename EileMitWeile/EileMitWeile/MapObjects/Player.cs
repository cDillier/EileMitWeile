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


        public Player(Brush playerColor):this(null,null,playerColor)
        {
        }

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
            var actualInfo = GetActualPlayerColorAndDiceNumber();
            if (actualInfo.Item1 == this.PlayerColor)
            {
                MovePlayer(actualInfo.Item2);
            }

            FinishStep(actualInfo.Item2);
        }

        private void MovePlayer(int steps)
        {
            if ((this.CurrentField.FieldType == Enum.FieldType.Base && steps == 5) || (this.CurrentField.FieldType != Enum.FieldType.Base))
            {
                for (int i = 0; i < steps; i++)
                {
                    RemoveFromCurrentField(true);
                    AddToNextField();
                }
            }
        }


        private void RemoveFromCurrentField(bool checkNextField)
        {
            if (!(checkNextField && this.CurrentField.NextField == null))
            {
                (this.Parent as StackPanel).Children.Remove(this);
            }
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

        private (Brush, int) GetActualPlayerColorAndDiceNumber()
        {
            var grid = new Grid();
            var diceNo = new Label();
            var currentColor = new TextBox();
            int diceNumber = 0;
            FrameworkElement currentField = this;

            while (currentField.Parent != null && currentField.Name != "BaseGrid")
            {
                currentField = currentField.Parent as FrameworkElement;
            }
            if (currentField.Name == "BaseGrid")
            {
                grid = ((currentField as Grid).Children[0] as Grid);
                diceNo = grid.Children[5] as Label;
                currentColor = grid.Children[2] as TextBox;

            }
            if (diceNo != null && diceNo.Name == "DiceNumber")
            {
                diceNumber = Convert.ToInt32(diceNo.Content);
            }

            if (currentColor != null && currentColor.Name == "actColor")
            {
                return (currentColor.Background, diceNumber);
            }
            return (null, diceNumber);
        }

        private void FinishStep(int diceNumber)
        {
            if ((this.CurrentField.FieldType == Enum.FieldType.Base && diceNumber == 5 )||( this.CurrentField.FieldType != Enum.FieldType.Base))
            {
                var grid = new Grid();
                var checkBox = new CheckBox();
                FrameworkElement currentField = this;
                while (currentField.Parent != null && currentField.Name != "BaseGrid")
                {
                    currentField = currentField.Parent as FrameworkElement;
                }
                if (currentField.Name == "BaseGrid")
                {
                    grid = ((currentField as Grid).Children[0] as Grid);
                    checkBox = grid.Children[6] as CheckBox;
                    checkBox.IsChecked = true;
                } 
            }

        }
    }
}
