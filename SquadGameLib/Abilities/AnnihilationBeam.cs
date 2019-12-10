using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    class AnnihilationBeam : Ability
    {
        private const string description = "Powerful laser gatling gun attack dealing high damage to all enemies";
        private const int defaultCooldownTime = 3;
        public AnnihilationBeam() : this(false)
        {
        }

        public AnnihilationBeam(bool isPreferred) : base("Annihilator Beam", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} fires {this.Name} on {target.Name}'s squad.");
            List<Unit> availableTargets = target.Assigned.GetViableTargets();
            foreach (Unit u in availableTargets)
            {
                actor.Attack(u);
            }
            this.CooldownCount = this.CooldownTime;
        }
    }
}
