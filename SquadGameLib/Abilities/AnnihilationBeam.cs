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
        private int HitChain { get; set; }

        //2nd argument is default cooldown Time
        public AnnihilationBeam() : this(false)
        {
        }

        public AnnihilationBeam(bool isPreferred) : base("Annihilator Beam", 4)
        {
            this.IsPreferred = isPreferred;
            this.HitChain = 0;
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

        public bool RollForExtraAttack(int tresholdChance)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double rng = rd.Next(0, 100);
            return rng <= tresholdChance ? true : false;
        }
    }
}
