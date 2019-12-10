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
        private const string description = "A risky offensive rush attack. Increases aim & attack power, adds chance of free attack in turn but lowers evasion & defence.";
        private const int defaultCooldownTime = 3;
        private const int chanceForExtraAttack = 38;
        private const int statusEffectsDuration = 2;
        private const int aimBuff = 18;
        private const int attackBuff = 26;
        private const int evasionDebuff = 17;
        private const int defenceDebuff = 19;

        public Rush() : this(false)
        {
            this.Type = Enums.AbilityType.Offensive;
        }

        public Rush(bool isPreferred) : base("Rush attack", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} uses {this.Name} and  charges straight at the enemy with an all-out offensive rush.");
            // numbers inserted are buff/debuff modifyers, still need to be balanced
            actor.AddStatusEffect(new AttackUp(actor, statusEffectsDuration, attackBuff));
            actor.AddStatusEffect(new AimUp(actor, statusEffectsDuration, aimBuff));
            actor.AddStatusEffect(new Exposed(actor, statusEffectsDuration, evasionDebuff, defenceDebuff));

            actor.Attack(target);
            if (RollForExtraAttack(chanceForExtraAttack))
            {
                if (target.Assigned.GetViableTargets().Count > 1)
                {
                    List<Unit> availableTargets = target.Assigned.GetViableTargets();
                    Console.WriteLine($"\n{actor.Name} attacks again in his wild charge!");
                    int index = availableTargets.IndexOf(target);
                    Unit secondTarget = (index - 1 >= 0) ? availableTargets[index - 1] : availableTargets[index + 1];
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
