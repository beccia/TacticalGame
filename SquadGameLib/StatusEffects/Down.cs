using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class Down : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }

        public Down() : this(null, 4)
        { 
            //default time  is set to  4, for 3 full turns
        }

        public Down(Unit affected) : this(affected, 4) { }


        public Down(Unit affected, int remainingTime)
        {
            this.Affected = affected;
            this.RemainingTime = remainingTime;
        }

        public void Effect()
        { 
            Console.WriteLine(Affected.Name + " is lying wounded on the battlefield and needs medical attention fast.");
        }

        public void Undo()
        {
            if (this.Affected.Hp > 0) {
                Console.WriteLine(Affected.Name + " is back on his feet with " + Affected.Hp + " HP.");
            } else
            {
                this.Affected.AddStatusEffect(new Dead(this.Affected));
                Console.WriteLine($"{this.Affected.Name} passed away due to his wounds.");
            }
            Affected = null;
        }
    }
}
