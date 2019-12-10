using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using SquadGameLib.Units.Aliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class Leech : Ability
    {
        private const string description = "If succesfull, passively steals HP from target for a few turns.";
        private const int successChance = 72;
        private const int statusEffectsDuration = 3;
        private const int defaultCooldownTime = 4;


        public Leech() : this(false)
        {
            this.IsPreferred = false;
            this.Type = Enums.AbilityType.Offensive;
        }

        public Leech(bool isPreferred) : base("Leech attack", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Unit leechTarget = getLeechTarget(target);
            Console.WriteLine($"\n{actor.Name} uses {this.Name} and plants life-sucking alien spores on {leechTarget.Name}.");
            if (!LeechSucceeded())
            {
                Console.WriteLine($"\nBut the spores fail to take a hold of their target and the attack fails.");
            }
            else
            {
                leechTarget.AddStatusEffect(new Leeched(leechTarget, (Shaman)actor, statusEffectsDuration));
            }
            this.CooldownCount = this.CooldownTime;
        }

        private Unit getLeechTarget(Unit target)
        {
            List<Unit> viableTargets = target.Assigned.GetViableTargets();
            Unit mostHP = viableTargets[0];
            for (int i = 1; i < viableTargets.Count - 1; i++)
            {
                if (viableTargets[i].Hp > mostHP.Hp)
                {
                    mostHP = viableTargets[i];
                }
            }
            return mostHP;
        }

        private bool LeechSucceeded()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            return successChance > rgn ? true : false;
        }
    }
}
