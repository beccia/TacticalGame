using SquadGameLib.units;
using SquadGameLib.Units.Aliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public class MinionShield : Ability
    {
        private const string description = "All Grunts in the squad will shield the Battle Lord and share any damage dealt to him.";
        private const int defaultCooldownTime = 3;
        public MinionShield() : this(false)
        {
        }

        public MinionShield(bool isPreferred) : base("Minion shield", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Survival;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} uses {this.Name}. All enemy Grunts will protect him with their lives.\n");
            ((BattleLord)actor).MinionGuards.Clear();
            List<Unit> availableUnits = actor.Assigned.GetViableTargets();
            foreach (Unit u in availableUnits)
            {
                if (u.GetType() == typeof(Grunt))
                {
                    ((BattleLord)actor).MinionGuards.Add(u);
                }
            }
            this.CooldownCount = this.CooldownTime;
        }
    }
}
