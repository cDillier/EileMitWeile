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
        public static IMap GetMap(Enum.MapName map)
        {
            switch (map)
            {
                case Enum.MapName.FourPlayerMap: return FourPlayerMap.GetFourPlayerMap();
                default:
                    return FourPlayerMap.GetFourPlayerMap();
            }
        }
    }
}
