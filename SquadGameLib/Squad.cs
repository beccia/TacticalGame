using SquadGameLib.Enums;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class Squad : List<Unit>
    {
        public String Name { get; private set; }

        public Strategy Strategy { get; private set; }

        public bool isDefeated()
        {
            foreach (Unit u in this)
            {
                if (u.StatusEffects.UnitIncapacitated())
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Squadname : {Name} \n Units: {this.Count} \n Strategy: {Strategy}");
            return sb.ToString();

        }
    }
}
