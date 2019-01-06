using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EileMitWeile.Enum;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EileMitWeile.MapObjects
{
    public class Field : StackPanel, IMapObject
    {
        public Field(int fieldNumber, Brush fieldColor, FieldType fieldType, Field prevField, Field nextField)
        {
            FieldNumber = fieldNumber;
            FieldType = fieldType;
            PrevField = prevField;
            NextField = nextField;
            Background = fieldColor;
           
        }

        public int FieldNumber { get; }
        public FieldType FieldType { get; set; }
        public Brush FieldColor { get { return Background; } }

        public Field PrevField { get; set; }

        public Field NextField { get; set; }

        public UIElement CurrentField => this;
    }
}
