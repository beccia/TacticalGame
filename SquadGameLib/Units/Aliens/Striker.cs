using SquadGameLib.Abilities;
using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Aliens
{
    public class Striker : Unit
    {
        public Striker() : this("unnamed Striker")
        {

        }

        public Striker(string name)
        {
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 0.8);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats * 0.82);
            this.Defence = (int)(BaseStats * 0.62);
            this.Aim = (int)(BaseStats * 0.94);
            this.Evasion = (int)(BaseStats / 1.6);
            this.Speed = (int)(BaseStats * 0.6);
            this.CritChance = BaseStats / 14;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            //second arguent inside new OrbitalStrike is the start value of the cooldown timer 
            this.AddAbility(new OrbitalStrike(true, 3));
            this.AddAbility(new TagTarget(true, 24, 2));
        }
    }
}
