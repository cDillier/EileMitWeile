using EileMitWeile.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EileMitWeile.Maps
{
    interface IMap
    {
        UIElement CreateMap();
        void SendPlayerToBase(Player player);
    }
}
