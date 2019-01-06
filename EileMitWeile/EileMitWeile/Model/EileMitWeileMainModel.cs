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
            return r.Next(0, 6).ToString();
        }
    }
}
