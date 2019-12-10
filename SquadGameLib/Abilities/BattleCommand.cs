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
    class BattleCommand : Ability
    {
        private const string description = "Grants temporary cooldown bonus to all Grunt Rush attacks, Annihilator Annihilator Beams and Striker Orbital Strike Abilities.";
        private const int defaultCooldownTime = 3;
        private const int statusEffectsDuration = 3;

        public BattleCommand() : this(false)
        {
            this.IsPreferred = false;
            this.Type = Enums.AbilityType.Offensive;
        }

        //2nd argument is default cooldown Time
        public BattleCommand(bool isPreferred) : base("Battle Command", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
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
                Console.WriteLine($"\n{actor.Name} uses {this.Name} and boosts the offensive efforts of all Grunts, Annihilators and Strikers!");
                foreach (Unit u in availableUnits)
                {
                    var @switch = new Dictionary<Type, Action>
                    {
                        {typeof(Grunt), () => u.AddStatusEffect(new CooldownBonus(u, statusEffectsDuration, new Rush()))},
                        {typeof(Annihilator), () => u.AddStatusEffect(new CooldownBonus(u, statusEffectsDuration, new AnnihilationBeam()))},
                        {typeof(Striker), () => u.AddStatusEffect(new CooldownBonus(u, statusEffectsDuration, new OrbitalStrike()))},
                    };
                    if (@switch.ContainsKey(u.GetType()))
                    {
                        @switch[u.GetType()]();
                    }
                }
                this.CooldownCount = this.CooldownTime;
            }
        }
    }
}
