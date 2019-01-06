using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EileMitWeile.MapObjects;
using EileMitWeile.Enum;
using System.Windows.Controls.Primitives;

public class MapCreater
{
     protected Field CreateField(int fieldNumber, Brush fieldColor, FieldType fieldType, Field prevField, Field nextField)
    {
        var field = new Field(fieldNumber, fieldColor, fieldType, prevField, nextField);
        var label = new Label() {Content = fieldNumber!= -1 ? fieldNumber.ToString(): string.Empty };
        var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
        stackPanel.Children.Add(label);
        //field.Children.Add(label);
        field.Children.Add(stackPanel);
        return field;
    }

    protected void SetFieldColorAndFieldType(Field field, Brush fieldColor,FieldType fieldType )
    {
        field.Background = fieldColor;
        field.FieldType = fieldType;
    }
}
