using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    class Grenade : Ability
    {
        private const string description = "Throws a grenade dealing damage to multiple enemies which decreases further from the impact.";
        private const int defaultCooldownTime = 3;
        private const int baseDamage = 43;
        private int Chain { get; set; }

        public Grenade() : this(false)
        {
        }

        public Grenade(bool isPreferred) : base("Grenade", defaultCooldownTime)
        {
            this.Description = description;
            this.IsPreferred = isPreferred;
            this.Chain = 0;
            this.Type = Enums.AbilityType.Offensive;
        }

        public override void Use(Unit actor, Unit target)
        {
            Console.WriteLine($"\n{actor.Name} throws a {this.Name} on {target.Name}'s position.");
            List<Unit> availableTargets = target.Assigned.GetViableTargets();
            foreach (Unit u in availableTargets)
            {
                DealBlastDamage(u);
            }
            this.CooldownCount = this.CooldownTime;
            Chain = 0;
        }

        public void  DealBlastDamage(Unit target)
        {
            if (!BlastHit())
            {
                Console.WriteLine($"{target.Name} was able to get to cover and avoid the blast!");
            }
            else
            {
                int damage = (baseDamage - (target.Defence / 9)) - (Chain * 9);
                double damageModifyer = target.GetDamageModifyer(85, 110);
                int finalDamage = (int) (damage * damageModifyer);
                Console.WriteLine($"{target.Name} takes {finalDamage} blast damage.");
                target.Hp -= finalDamage;
            }
            Chain++;
        }

        public bool BlastHit()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            int rgn = rd.Next(0, 100);
            int hitChance = 95 - (Chain * 19);
            return hitChance > rgn ? true : false;
        }

    }
}
