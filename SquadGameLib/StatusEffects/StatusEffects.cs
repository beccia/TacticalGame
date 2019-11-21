using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class Status : List<IStatusEffect>
    {

        public Status() {
        }



        public void IncreaseTurnCount()
        {
            foreach(IStatusEffect s in this) {
                s.TurnsCount++;
            }
        }
    }
}
