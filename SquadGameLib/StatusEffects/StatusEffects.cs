using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class StatusEffects : List<IStatusEffect>
    {

        public StatusEffects() {
        }

        public bool UnitIncapacitated()
        {
            if (this.OfType<Dead>().Any() || this.OfType<Down>().Any())
            {
                return true;
            }
            else return false;
        }



        public void IncreaseTurnCount()
        {
            foreach(IStatusEffect s in this) {
                s.TurnsCount++;
            }
        }
    }
}
