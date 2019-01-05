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
    public class FourPlayerMap : MapCreater
    {
        Field field = null;
        public UIElement CreateMap()
        {
            CreateFields();

            var uniGrid = new UniformGrid() { Columns = 3, Rows = 7 , Background = Brushes.Black};

            AddChild(uniGrid, this.field);
            return uniGrid;
        }

        private void CreateFields()
        {
            field = CreateField(1, Brushes.White, FieldType.Normal, null,
                CreateField(2, Brushes.White, FieldType.Normal, null,
                CreateField(3, Brushes.White, FieldType.Normal, null,
                CreateField(4, Brushes.White, FieldType.Normal, null,
                CreateField(5, Brushes.White, FieldType.Normal, null,
                CreateField(6, Brushes.White, FieldType.Normal, null,
                CreateField(7, Brushes.White, FieldType.Normal, null,
                CreateField(8, Brushes.White, FieldType.Normal, null,
                CreateField(9, Brushes.White, FieldType.Normal, null,
                CreateField(10, Brushes.White, FieldType.Normal, null,
                CreateField(11, Brushes.White, FieldType.Normal, null,
                CreateField(12, Brushes.White, FieldType.Normal, null,
                CreateField(13, Brushes.White, FieldType.Normal, null,
                CreateField(14, Brushes.White, FieldType.Normal, null,
                CreateField(15, Brushes.White, FieldType.Normal, null,
                CreateField(16, Brushes.White, FieldType.Normal, null,
                CreateField(17, Brushes.White, FieldType.Normal, null,
                CreateField(18, Brushes.White, FieldType.Normal, null,
                CreateField(19, Brushes.White, FieldType.Normal, null,
                CreateField(20, Brushes.White, FieldType.Normal, null,
                CreateField(21, Brushes.White, FieldType.Normal, null, null)))))))))))))))))))));


        }

        private void AddChild(UniformGrid uniGrid, Field field)
        {
            if (field != null)
            {
                if (field.NextField != null)
                {
                    AddChild(uniGrid, field.NextField);
                }
                uniGrid.Children.Add(field);
            }
        }

    }
}
