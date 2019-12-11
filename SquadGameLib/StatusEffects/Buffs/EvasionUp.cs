using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquadGameLib.units;

namespace SquadGameLib.StatusEffects
{
    public class EvasionUp : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int EvasionBuff { get; private set; }

        private bool Applied;


        public EvasionUp  (int remainingTime, int evasionBuff)
        {
            this.RemainingTime = remainingTime;
            this.EvasionBuff = evasionBuff;
            Applied = false;
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.Evasion += EvasionBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}'s ability to evade attacks increased.");
            }
        }

        public void Undo()
        {
            Console.Write(Affected.Hp > 0 ? $"\n{Affected.Name}'s evasive boost wore off." : "");
            Affected.Evasion -= EvasionBuff;
            this.Affected = null;
        }
    }
}
