using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects.Buffs
{
    public class DefenceUp : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int DefenceBuff { get; private set; }

        private bool Applied;


        public DefenceUp(int remainingTime, int defenceBuff)
        {
            this.RemainingTime = remainingTime;
            this.DefenceBuff = defenceBuff;
            Applied = false;
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.Defence += DefenceBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}'s defence went up.");
            }
        }

        public void Undo()
        {
            Console.Write(Affected.Hp > 0 ? $"\n{Affected.Name}'s defence boost wore off." : "");
            Affected.Defence -= DefenceBuff;
            this.Affected = null;
        }
    }
}
