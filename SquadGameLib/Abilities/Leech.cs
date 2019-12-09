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
        private int SuccessChance{ get; set; }
        private int StatusEffectsDuration { get;  set; }

        //2nd argument is default cooldown Time
        public Leech() : this(false)
        {
            this.IsPreferred = false;
            this.StatusEffectsDuration = 3;
            this.Type = Enums.AbilityType.Offensive;
        }

        public Leech(bool isPreferred) : base("Leech attack", 3)
        {
            this.IsPreferred = isPreferred;
            this.SuccessChance = 72;
            this.StatusEffectsDuration = 3;
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
                leechTarget.AddStatusEffect(new Leeched(leechTarget, (Shaman)actor, 3));
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
            return this.SuccessChance > rgn ? true : false;
        }
    }
}
