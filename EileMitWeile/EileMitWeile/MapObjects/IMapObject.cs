using EileMitWeile.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace EileMitWeile.MapObjects
{
    public interface IMapObject
    {
        int FieldNumber { get; }
        FieldType FieldType { get; }
        Brush FieldColor { get; }
        Field PrevField { get; }
        Field NextField { get; }
        UIElement CurrentField { get; }
    }
}
