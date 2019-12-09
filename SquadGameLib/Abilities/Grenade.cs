﻿using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    class Grenade : Ability
    {
        private int Chain { get; set; }
        private int BaseDamage { get; set; }

        //2nd argument is default cooldown Time
        public Grenade() : this(false)
        {
        }

        public Grenade(bool isPreferred) : base("Grenade", 3)
        {
            this.IsPreferred = isPreferred;
            this.Chain = 0;
            this.BaseDamage = 43;
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
                int damage = (BaseDamage - (target.Defence / 9)) - (Chain * 9);
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
            int hitChance = 95 - (Chain * 20);
            return hitChance > rgn ? true : false;
        }

    }
}
