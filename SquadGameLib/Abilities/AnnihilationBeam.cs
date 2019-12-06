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

        //2nd argument is default cooldown Time
        public AnnihilationBeam() : this(false)
        {
        }

        public AnnihilationBeam(bool isPreferred) : base("Annihilator Beam", 4)
        {
            this.IsPreferred = isPreferred;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"{actor.Name} fires {this.Name} on {target.Name}'s squad.");
            List<Unit> availableTargets = target.Assigned.GetViableTargets();
            foreach (Unit u in availableTargets)
            {
                actor.Attack(u);
            }
            this.CooldownCount = this.CooldownTime;
        }
    }
}
