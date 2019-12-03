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

        public void Clear(IStatusEffect se)
        {
            foreach (IStatusEffect s in this)
            {
               if (s.GetType() == se.GetType()) { 
                    this.Remove(s);
                }
            }
        }
    }
}
