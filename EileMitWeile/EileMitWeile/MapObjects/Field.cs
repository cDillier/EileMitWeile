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
    public class Field : Panel
    {
        public Field(int fieldNumber, Brush fieldColor, FieldType fieldType, Field prevField, Field nextField)
        {
            FieldNumber = fieldNumber;
            FieldColor = fieldColor;
            FieldType = fieldType;
            PrevField = prevField;
            NextField = nextField;
        }

        public int FieldNumber { get; }
        public FieldType FieldType { get; }
        public Brush FieldColor { get; }

        public Field PrevField { get; }

        public Field NextField { get; }
    }
}
