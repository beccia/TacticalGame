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


        public void ExecuteEffects()
        {
            foreach (IStatusEffect s in this.ToList())
            {
                s.Effect();
            }
        }

        public void DecreaseTurnCount()
        {
            foreach(IStatusEffect s in this.ToList()) {
                s.RemainingTime--;
                if (s.RemainingTime <= 0)
                {
                    Clear(s);
                }
            }
        }

        public void ClearAll()
        {
            foreach (IStatusEffect s in this.ToList())
            {
                Clear(s);
            }
        }

        public void Clear(IStatusEffect se)
        {
            foreach (IStatusEffect s in this.ToList())
            {
               if (s.GetType() == se.GetType()) { 
                    this.Remove(s);
                    s.Undo();
                    break;
                }
            }
        }
    }
}
