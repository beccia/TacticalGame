using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    class OrbitalStrike : Ability
    {
        private const string description = "An orbital strike, dealing devastating damage to the entire squad. Can be used after 2 turns.";
        private const int defaultCooldownTime = 3;
        private const int initialCooldownTime = 3;
        private const int baseDamage = 79;
        private int Chain { get; set; }
     
        public OrbitalStrike() : this(false)
        {
        }

        public OrbitalStrike(bool isPreferred) : base("Orbital Strike", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Chain = 0;
            this.CooldownCount = initialCooldownTime;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} orders in an {this.Name} on {target.Name}'s position. A heavy bombardment rains down from the sky.");
            List<Unit> availableTargets = target.Assigned.GetViableTargets();
            foreach (Unit u in availableTargets)
            {
                DealBlastDamage(u);
            }
            this.CooldownCount = this.CooldownTime;
            Chain = 0;
        }

        public void DealBlastDamage(Unit target)
        {
            if (!BlastHit())
            {
                Console.WriteLine($"{target.Name} was able to get to cover and avoid the blast!");
            }
            else
            {
                int damage = (baseDamage - ((int)(target.Defence / 6.3))) - (Chain * 7);
                double damageModifyer = target.GetDamageModifyer(85, 112);
                int finalDamage = (int)(damage * damageModifyer);
                Console.WriteLine($"{target.Name} takes {finalDamage} blast damage.");
                target.Hp -= finalDamage;
            }
            Chain++;
        }

        public bool BlastHit()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            int hitChance = 95 - (Chain * 8);
            return hitChance > rgn ? true : false;
        }
    }
}
