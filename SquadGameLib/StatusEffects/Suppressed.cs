using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class Suppressed : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int AimDebuff { get; private set; }
        public int AttackDebuff { get; private set; }
        public int CritChanceDebuff { get; private set; }

        private bool Applied;


        public Suppressed(Unit affected, int remainingTime, int aimDebuff, int attackDebuff, int critChanceDebuff)
        {
            this.Affected = affected;
            this.RemainingTime = remainingTime;
            this.AimDebuff = aimDebuff;
            this.CritChanceDebuff = critChanceDebuff;
            Applied = false;
            Effect();
            Console.WriteLine($"{Affected.Name} is suppressed by heavy fire. Aiming, attack power & critical hit chance are lowered.");
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.Aim -= AimDebuff;
                Affected.AttackPower-= AttackDebuff;
                Affected.CritChance -= CritChanceDebuff;
                Applied = true;
            }
            else
            {
                Console.WriteLine($"{Affected.Name} is still suppressed by heavy fire.");
            }
        }

        public void Undo()
        {
            Console.WriteLine(Affected.Hp > 0 ? $"\n{Affected.Name} is out of the suppressive fire and able to attack unhampered again." : "");
            Affected.Aim += AimDebuff;
            Affected.AttackPower += AttackDebuff;
            Affected.CritChance += CritChanceDebuff;
        }
    }
}
