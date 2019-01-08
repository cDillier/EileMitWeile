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
            int numb = r.Next(1, 7);

            if (numb == 7)
                numb = 6;

            if (numb == 6)
                numb += r.Next(1, 7);

            if (numb == 12)
                numb += r.Next(1, 7);

            return numb.ToString();
        }
    }
}
