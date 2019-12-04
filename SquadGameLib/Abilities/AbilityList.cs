using SquadGameLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class AbilityList : List<Ability>
    {

        public void ReduceCooldownCounters()
        {
            foreach (Ability a in this)
            { 
                a.ReduceCooldownTimer();
            }
        }


        public List<Ability> GetAvailableAbilities(AbilityType type)
        {
            List<Ability> result = new List<Ability>();
            foreach (Ability a in this)
            {
                if (a.Type == type && a.CooldownCount == 0)
                {
                    result.Add(a);
                }
            }
            return result;
        }
    }

 
}

