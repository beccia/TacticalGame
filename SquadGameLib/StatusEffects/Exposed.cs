using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquadGameLib.units;

namespace SquadGameLib.StatusEffects
{
    /** 
     *  Status ailment: unit is out of cover and vulnerable to attack. Debuffs evasion and defence.
     * 
     */

    public class Exposed : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int EvasionDebuff { get; private set; }
        public int DefenceDebuff { get; private set; }

        private bool Applied;


        public Exposed(int remainingTime, int evasionDebuff, int defenceDebuff)
        {
            this.RemainingTime = remainingTime;
            this.EvasionDebuff = evasionDebuff;
            this.DefenceDebuff = defenceDebuff;
            Applied = false;
        }

        public void Effect()
        {
            if (!Applied) {
                Console.WriteLine($"{Affected.Name} is exposed, out of cover and more vulnerable to enemy attacks.");
                Affected.Evasion -= EvasionDebuff;
                Affected.Defence -= DefenceDebuff;
                Applied = true;
            } else
            {
                Console.WriteLine($"{Affected.Name} is still exposed to enemmy attacks.");
            }
        }

        public void Undo()
        {
            Console.WriteLine(Affected.Hp > 0 ? $"\n{Affected.Name} is back in cover and better able to defend himself." : "");
            Affected.Evasion += EvasionDebuff;
            Affected.Defence += DefenceDebuff;
        }
    }
}
