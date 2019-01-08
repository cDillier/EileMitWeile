using EileMitWeile.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace EileMitWeile.MapObjects
{
    public class Base : Border, IMapObject
    {
        public Base(Color teamColor, Field nextField, double rotation, Field lastFieldBeforeColoredField)
        {
            NextField = nextField;
            CornerRadius = new CornerRadius(1000);
            BorderThickness = new Thickness(2, 2, 8, 7);
            BorderBrush = new LinearGradientBrush(new GradientStopCollection() { new GradientStop(Brushes.Black.Color, 0), new GradientStop(teamColor, 0.5) }, new Point(0.5, 1), new Point(0.5, 0));
            LayoutTransform = new RotateTransform(rotation);
            LastFieldBeforeColoredField = lastFieldBeforeColoredField;
        }

        public FieldType FieldType { get; } = FieldType.Base;
        public Brush FieldColor { get { return BorderBrush; } }

        public Field NextField { get; set; }

        public int FieldNumber => -2;

        public Field PrevField => null;
        public UIElement CurrentField => this;

        public Field LastFieldBeforeColoredField { get; }
    }
}
