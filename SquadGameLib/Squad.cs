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

        public Strategy Strategy { get; set; }



        public bool isDefeated()
        {
            bool result;
            int combatants = 0;
            foreach (Unit u in this)
            {
                if (!u.IsIncapacitated())
                {
                    combatants++;
                }
            }
            result = (combatants > 0)?  false : true;
            return result;
        }

        public List<Unit> GetViableTargets()
        {
            List<Unit> list = this.ToList<Unit>();
            var result = list.Where(unit => !unit.IsIncapacitated());
            return result.ToList<Unit>();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Squadname : {Name} \n Units: {this.Count} \n Strategy: {Strategy}");
            return sb.ToString();

        }
    }
}
