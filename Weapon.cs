using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Weapon : Item
    {
        public int MinDmg { get; set; }
        public int MaxDmg { get; set; }

        public Weapon(int id, string name, string namePl, int minDmg, int maxDmg) : base(id, name, namePl)
        {
            Id = id;
            MinDmg = minDmg;
            MaxDmg = maxDmg;
        }
    }
}
