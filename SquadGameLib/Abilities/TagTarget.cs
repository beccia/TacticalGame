using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class TagTarget : Ability
    {
        private const string description = "Greatly increases the hit chance of the strongest fellow unit.";
        private const int defaultCooldownTime = 2;
        private int aimBuff = 31;
        private const int statusEffectsDuration = 2;

        public TagTarget() : this(false)
        {
            this.IsPreferred = false;
            this.Type = Enums.AbilityType.Tactical;
        }


        public TagTarget(bool isPreferred) : base("Tag Target", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Tactical;
        }


        public override void Use(Unit actor, Unit target)
        {
            List<Unit> availableUnits = actor.Assigned.GetViableTargets();
            if (availableUnits.Count <= 1)
            {
                actor.Attack(target);
            }
            else
            {
                Console.WriteLine($"\n{actor.Name} uses {this.Name} and assists his squad's strongest unit in landing shots.");
                Unit buffTarget = availableUnits[0];
                foreach (Unit u in availableUnits)
                {
                    if (u.AttackPower > buffTarget.AttackPower)
                    {
                        buffTarget = u;
                    }
                }
                buffTarget.AddStatusEffect(new AimUp(buffTarget, statusEffectsDuration, aimBuff)); ;
                this.CooldownCount = this.CooldownTime;
            }
        }
    }
}
