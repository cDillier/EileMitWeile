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

    //protected Field CreateField( Brush fieldColor, FieldType fieldType, Field prevField, Field nextField)
    //{

    //    int fieldNumber = 0;
    //    if (prevField != null ) 
    //    {
    //        fieldNumber = prevField.FieldNumber +1;
    //    }

    //    return CreateField(fieldNumber, fieldColor, fieldType, prevField, nextField);
    //}
     protected Field CreateField(int fieldNumber, Brush fieldColor, FieldType fieldType, Field prevField, Field nextField)
    {
        var field = new Field(fieldNumber, fieldColor, fieldType, prevField, nextField);
        var label = new Label() {Content = fieldNumber!= -1 ? fieldNumber.ToString(): string.Empty };
        
        field.Children.Add(label);
        return field;
    }

    protected void SetNextField(Field currentField, Field nextField)
    {
        currentField.NextField = nextField;
    }

    protected void SetPrevField(Field currentField, Field prevField)
    {
        currentField.PrevField = prevField;
    }

}
