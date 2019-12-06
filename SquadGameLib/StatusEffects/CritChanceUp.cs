using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class CritChanceUp : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int CritChanceBuff { get; private set; }

        private bool Applied;


        public CritChanceUp(Unit affected, int remainingTime, int critChanceBuff)
        {
            this.Affected = affected;
            this.RemainingTime = remainingTime;
            this.CritChanceBuff = critChanceBuff;
            Applied = false;
            Effect();
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.CritChance += CritChanceBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}'s ability to land critical hits has increased.");
            }
        }

        public void Undo()
        {
            Console.Write(Affected.Hp > 0 ? $"\n{Affected.Name}'s critical hit chance went back to normal." : "");
            Affected.CritChance -= CritChanceBuff;
            this.Affected = null;
        }
    }
}
