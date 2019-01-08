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
using System.Windows.Controls;
using EileMitWeile.Maps;

namespace EileMitWeile.Maps
{
    public class FourPlayerMap : MapCreater, IMap
    {
        //Singleton
        private FourPlayerMap()
        {

        }

        private static readonly FourPlayerMap fourPlayerMap_ = new FourPlayerMap();
        public static FourPlayerMap GetFourPlayerMap()
        {
            return fourPlayerMap_;
        }


        //Anzahl normale Felder mit Bänken
        const int maxFieldNumber = 68;

        Base redBase = null;
        Base blueBase = null;
        Base greenBase = null;
        Base yellowBase = null;

        List<Field> fields = new List<Field>();
        public UIElement CreateMap()
        {
            //Felder erstellen
            CreateFields();
            var yellowUniGrid = CreateUniformGrid(new List<int>() { 60, 75, 8, 61, 74, 7, 62, 73, 6, 63, 72, 5, 64, 71, 4, 65, 70, 3, 66, 69, 2, 67, 68, 1 }, 0);
            var blueUniGrid = CreateUniformGrid(new List<int>() { 9, 82, 25, 10, 81, 24, 11, 80, 23, 12, 79, 22, 13, 78, 21, 14, 77, 20, 15, 76, 19, 16, 17, 18, }, 270);
            var redUniGrid = CreateUniformGrid(new List<int>() { 26, 89, 42, 27, 88, 41, 28, 87, 40, 29, 86, 39, 30, 85, 38, 31, 84, 37, 32, 83, 36, 33, 34, 35, }, 180);
            var greenUniGrid = CreateUniformGrid(new List<int>() { 43, 96, 59, 44, 95, 58, 45, 94, 57, 46, 93, 56, 47, 92, 55, 48, 91, 54, 49, 90, 53, 50, 51, 52, }, 90);

            //Grid erstellen
            Grid mapGrid = new Grid();
            mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(7, GridUnitType.Star) });
            mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(7, GridUnitType.Star) });
            mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            mapGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(7, GridUnitType.Star) });
            mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });
            mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });
            mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            mapGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(7, GridUnitType.Star) });

            //Felder zuweisen
            Grid.SetColumn(redUniGrid, 1);
            Grid.SetRow(redUniGrid, 0);
            Grid.SetColumnSpan(redUniGrid, 3);
            Grid.SetRowSpan(redUniGrid, 2);

            Grid.SetColumn(blueUniGrid, 3);
            Grid.SetRow(blueUniGrid, 1);
            Grid.SetColumnSpan(blueUniGrid, 2);
            Grid.SetRowSpan(blueUniGrid, 3);

            Grid.SetColumn(greenUniGrid, 0);
            Grid.SetRow(greenUniGrid, 1);
            Grid.SetColumnSpan(greenUniGrid, 2);
            Grid.SetRowSpan(greenUniGrid, 3);

            Grid.SetColumn(yellowUniGrid, 1);
            Grid.SetRow(yellowUniGrid, 3);
            Grid.SetColumnSpan(yellowUniGrid, 3);
            Grid.SetRowSpan(yellowUniGrid, 2);

            //Alle Base erstellen
            redBase = CreateBase(Brushes.Red.Color, fields[38], 180, fields[33], fields[82]);
            blueBase = CreateBase(Brushes.Blue.Color, fields[21], 270, fields[16], fields[75]);
            greenBase = CreateBase(Brushes.Green.Color, fields[55], 90, fields[50], fields[89]);
            yellowBase = CreateBase(Brushes.Yellow.Color, fields[62], 0, fields[67], fields[68]); 

            //Base zuweisen
            Grid.SetColumn(redBase, 0);
            Grid.SetRow(redBase, 0);
            Grid.SetColumn(blueBase, 4);
            Grid.SetRow(blueBase, 0);
            Grid.SetColumn(greenBase, 0);
            Grid.SetRow(greenBase, 4);
            Grid.SetColumn(yellowBase, 4);
            Grid.SetRow(yellowBase, 4);

            //Erstellte Elemente dem Grid hinzufügen
            mapGrid.Children.Add(greenUniGrid);
            mapGrid.Children.Add(yellowUniGrid);
            mapGrid.Children.Add(blueUniGrid);
            mapGrid.Children.Add(redUniGrid);
            mapGrid.Children.Add(redBase);
            mapGrid.Children.Add(blueBase);
            mapGrid.Children.Add(greenBase);
            mapGrid.Children.Add(yellowBase);
           
            return mapGrid;
        }

        public void SendPlayerToBase(Player player)
        {
            AddPlayerToBase(player, redBase);
            AddPlayerToBase(player, yellowBase);
            AddPlayerToBase(player, blueBase);
            AddPlayerToBase(player, greenBase);
        }

        private void AddPlayerToBase(Player player, Base startBase)
        {
            if (player.PlayerColor.ToString() == ((GradientBrush)startBase.FieldColor).GradientStops[1].Color.ToString())
            {
                (startBase.Child as StackPanel).Children.Add(player);
                player.CurrentField = startBase;
                player.LastFieldBeforeColoredField = startBase.LastFieldBeforeColoredField;
            }

        }

        private UniformGrid CreateUniformGrid(List<int> fieldNumbers, double rotation)
        {
            var uniGrid = new UniformGrid() { Columns = 3, Rows = 8, LayoutTransform = new RotateTransform(rotation), Background = Brushes.Black };
            foreach (var fieldNumber in fieldNumbers)
            {
                uniGrid.Children.Add(fields[fieldNumber - 1]);
            }

            return uniGrid;
        }

        private void CreateFields()
        {
            //Erstellt alle normalen Felder
            for (int i = 1; i <= maxFieldNumber; i++)
            {
                fields.Add(CreateField(i, Brushes.White, FieldType.Normal, null, null));
            }
            for (int i = 1; i < maxFieldNumber - 1; i++)
            {
                SetPrevAndNextFieldByCurrentFieldIndex(i);
            }
            fields[0].NextField = fields[1];
            fields[maxFieldNumber - 1].NextField = fields[0];
            fields[0].PrevField = fields[maxFieldNumber - 1];

            //Erstellt alle Safe-Zones (Bänke)
            foreach (int index in new List<int>() { 11, 16, 21, 28, 33, 38, 45, 50, 55, 62, 67 })
            {
                SetFieldColorAndFieldType(fields[index], Brushes.Brown, FieldType.SafeZone);
            }

            SetFieldColorAndFieldType(fields[4], Brushes.Yellow, FieldType.SafeZone);
            SetFieldColorAndFieldType(fields[21], Brushes.Blue, FieldType.SafeZone);
            SetFieldColorAndFieldType(fields[38], Brushes.Red, FieldType.SafeZone);
            SetFieldColorAndFieldType(fields[55], Brushes.Green, FieldType.SafeZone);


            //Erstellt alle Felder mit die ins Ziel führen und die Ziel-Felder
            foreach (var fieldColor in new List<Brush>() { Brushes.Yellow, Brushes.Blue, Brushes.Red, Brushes.Green })
            {
                int startIndex = fields.Count();
                for (int i = 1; i < 7; i++)
                {
                    fields.Add(CreateField(-1, fieldColor, FieldType.Normal, null, null));
                }
                //Ziel-Feld hinzufügen
                fields.Add(CreateField(-1, fieldColor, FieldType.Finish, fields[startIndex + 5], null));
                for (int i = startIndex + 1; i < startIndex + 5; i++)
                {
                    SetPrevAndNextFieldByCurrentFieldIndex(i);
                }
            }
            foreach (int index in new List<int>() { 16, 33, 50 })
            {
                SetPrevAndNextFieldByCurrentFieldIndex(index);
            }
            fields[maxFieldNumber - 1].PrevField = fields[maxFieldNumber - 2];
            fields[maxFieldNumber - 1].NextField = fields[0];
        }

        private void SetPrevAndNextFieldByCurrentFieldIndex(int index)
        {
            fields[index].PrevField = fields[index - 1];
            fields[index].NextField = fields[index + 1];
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
