using SquadGameLib.units;
using SquadGameLib.Units.Aliens;
using SquadGameLib.Units.Army;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class Assassination : Ability 
    {
        private const string description = "Instantly fires a shot with increased crit & hit chance at the biggest threat.";
        private const int critModifyer = 21;
        private const int aimModifyer = 15;
        private const int cooldownCountStart = 2;
        private const int defaultCooldownTime = 5;

        public Assassination() : this(false)
        {
            this.IsPreferred = false;
            this.Type = Enums.AbilityType.Offensive;
        }

        public Assassination(bool isPreferred) : base("Assassination", defaultCooldownTime)
        {
            this.CooldownCount = cooldownCountStart;
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Unit assassinationTarget = GetAssassinationTarget(target);
            actor.CritChance += critModifyer;
            actor.Aim += aimModifyer;
            Console.WriteLine($"{actor.Name} aims to take out enemy HVT and has {assassinationTarget.Name}'s head in his scope.");
            ((Sniper)actor).Target = assassinationTarget;
            ((Sniper)actor).Attack(assassinationTarget);
            actor.CritChance -= critModifyer;
            actor.Aim -= aimModifyer;
            this.CooldownCount = this.CooldownTime;
        }

        public Unit GetAssassinationTarget(Unit target)
        {
            List<Unit> available = target.Assigned.GetViableTargets();
            IEnumerable<Unit> topThreats = available.OfType<Striker>();
            Unit selectedTarget = available.OfType<Striker>().Count() != 0 ? topThreats.First() : available.OfType<BattleLord>().Count() != 0 ? available.OfType<BattleLord>().First() :
                available.OfType<Shaman>().Count() != 0 ? available.OfType<Shaman>().First() : available.OfType<Annihilator>().Count() != 0 ? available.OfType<Annihilator>().First() : target;
            return selectedTarget;
        }
    }
}
