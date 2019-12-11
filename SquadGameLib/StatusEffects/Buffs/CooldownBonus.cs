using SquadGameLib.Abilities;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    class CooldownBonus : IStatusEffect
    {
        private const int cooldownBonus = 1;
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public Ability TargetAbility{ get; private set; }

        private bool Applied;


        public CooldownBonus(int remainingTime, Ability targetAbility)
        {
            this.RemainingTime = remainingTime;
            this.TargetAbility = targetAbility;
            Applied = false;
        }

        public void Effect()
        {
            if (!Applied)
            {
                Ability target = Affected.Abilities.Find(a => a.GetType() == TargetAbility.GetType());
                target.CooldownCount = target.CooldownCount <= 0? 0 : target.CooldownCount - 1;
                target.CooldownTime -= cooldownBonus;
                Applied = true;
                Console.WriteLine($"The rate at which {Affected.Name} can use his {TargetAbility.Name} ability has increased.");
            }
        }

        public void Undo()
        {
            Console.Write(Affected.Hp > 0 ? $"\n{Affected.Name}'s ability cooldown bonus wore off." : "");
            Affected.Abilities.Find(a => a.GetType() == TargetAbility.GetType()).CooldownTime += cooldownBonus;
            this.Affected = null;
        }
    }
}
