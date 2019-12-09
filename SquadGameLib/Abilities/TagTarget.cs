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
        private int AimBuff{ get; set; }
        private int StatusEffectsDuration { get; set; }

        public TagTarget() : this(false)
        {
            this.IsPreferred = false;
            this.Type = Enums.AbilityType.Tactical;
        }

        //2nd argument is default cooldown Time
        public TagTarget(bool isPreferred) : this(isPreferred, 20, 2)
        {
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Tactical;
        }

        public TagTarget(bool isPreferred, int aimBuff, int statusEffectsDuration) : base("Tag Target", 2)
        {
            this.IsPreferred = isPreferred;
            this.AimBuff = aimBuff;
            this.StatusEffectsDuration = statusEffectsDuration;
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
                Console.WriteLine($"\n{actor.Name} uses {this.Name} and assists his suqad's strongest unit in landing shots.");
                Unit buffTarget = availableUnits[0];
                foreach (Unit u in availableUnits)
                {
                    if (u.AttackPower > buffTarget.AttackPower)
                    {
                        buffTarget = u;
                    }
                }
                buffTarget.AddStatusEffect(new AimUp(buffTarget, StatusEffectsDuration, AimBuff)); ;
                this.CooldownCount = this.CooldownTime;
            }
        }
    }
}
