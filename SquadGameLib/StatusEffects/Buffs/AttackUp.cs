using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class AttackUp : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int AttackBuff { get; private set; }

        private bool Applied;


        public AttackUp(int remainingTime, int attackBuff)
        {
            this.RemainingTime = remainingTime;
            this.AttackBuff = attackBuff;
            Applied = false;
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.AttackPower += AttackBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}'s attack power went up.");
            }
        }

        public void Undo()
        {
            Console.Write(Affected.Hp > 0 ? $"\n{Affected.Name}'s offensive boost wore off." : "");
            Affected.AttackPower-= AttackBuff;
            this.Affected = null;
        }
    }
}