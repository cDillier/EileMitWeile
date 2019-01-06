using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EileMitWeile.Maps
{
    static class MapFactory
    {
        public static UIElement GetMap(Enum.MapName map)
        {
            switch (map)
            {
                case Enum.MapName.FourPlayerMap: return new FourPlayerMap().CreateMap();
                default:
                    return new FourPlayerMap().CreateMap();
            }
        }
    }
}
