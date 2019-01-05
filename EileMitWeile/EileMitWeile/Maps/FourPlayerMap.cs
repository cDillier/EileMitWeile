using EileMitWeile.MapObjects;
using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using EileMitWeile.Enum;

namespace EileMitWeile.Maps
{
    public class FourPlayerMap:MapCreater
    {
        Field field = null;
        public UIElement CreateMap()
        {
            CreateFields();

            var uniGrid = new UniformGrid();
            AddChild(uniGrid, this.field);
            return uniGrid;
        }

        private void CreateFields()
        {
            field =CreateField(1, Brushes.White, FieldType.Normal, null,
                CreateField(Brushes.White, FieldType.Normal, null,
                CreateField(Brushes.White, FieldType.Normal, null,
                CreateField(Brushes.White, FieldType.Normal, null,
                CreateField(Brushes.White,FieldType.Normal, null, null)))));
        }
         
        private void AddChild(UniformGrid uniGrid, Field field)
        {
            if(field != null)
            {
                AddChild(uniGrid, field.NextField);
            }
            uniGrid.Children.Add(field);
        }

    }
}
