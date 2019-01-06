using EileMitWeile.Enum;
using EileMitWeile.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EileMitWeile.Model
{
    public class EileMitWeileMainModel
    {
        public string Dice()
        {
            Random r = new Random();
            int numb = r.Next(0, 7);

            if (numb == 7)
                numb = 6;

            return numb.ToString();
        }
        public System.Windows.UIElement GetMap(MapName map)
        {
            switch (map)
            {
                case MapName.FourPlayerMap: return new FourPlayerMap().CreateMap();
                default:
                    return new FourPlayerMap().CreateMap();
            }
        }
    }
}
