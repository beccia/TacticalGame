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
        //2nd argument is default cooldown Time
        public MinionShield() : this(false)
        {
        }

        public MinionShield(bool isPreferred) : base("Minion shield", 3)
        {
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Survival;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name} uses {this.Name}. All enemy Grunts will protect him withtheir lives.");
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
