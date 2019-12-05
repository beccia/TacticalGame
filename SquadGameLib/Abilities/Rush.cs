using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{

    /** Ability intended for Alien Grunt unit. Unit charges aggressively and gains an attack power & aim buff, and an Exposed ailment which debuffs defense & evasion. Unit also gets a 
     * chance to attack a second unit this turn (but not the same unit twice). 
     */

    public class Rush : Ability
    {
        public int ChanceForExtraAttack { get; private set; }
        public int StatusEffectsDuration { get; private set; }

        //2nd argument is default cooldown Time
        public Rush() : base("Rush attack", 3)
        {
            this.IsPreferred = false;
            this.ChanceForExtraAttack = 37;
            this.StatusEffectsDuration = 3;
            this.Type = Enums.AbilityType.Offensive;
        }

        public Rush(bool isPreferred) : base("Rush attack", 3)
        {
            this.IsPreferred = isPreferred;
            this.ChanceForExtraAttack = 37;
            this.StatusEffectsDuration = 3;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name} uses {this.Name} and  charges straight at the enemy with an all-out offensive rush.");
            // numbers inserted are buff/debuff modifyers, still need to be balanced
            actor.AddStatusEffect(new AttackUp(actor, StatusEffectsDuration, 26));
            actor.AddStatusEffect(new AimUp(actor, StatusEffectsDuration, 18));
            actor.AddStatusEffect(new Exposed(actor, StatusEffectsDuration, 20, 18));

            actor.Attack(target);
            if (RollForExtraAttack(ChanceForExtraAttack))
            {
                if (target.Assigned.GetViableTargets().Count > 1)
                {
                    int index = target.Assigned.GetViableTargets().IndexOf(target);
                    Unit secondTarget = (index - 1 >= 0) ? target.Assigned[index - 1] : target.Assigned[index + 1];
                    actor.Attack(secondTarget);
                }
            }
            this.CooldownCount = this.CooldownTime;
        }

        public bool RollForExtraAttack(int tresholdChance)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double rng = rd.Next(0, 100);
            return rng <= tresholdChance ? true : false;
        }
    }
}
