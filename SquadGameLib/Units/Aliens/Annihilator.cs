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
    public class Annihilator : Unit
    {
        public Annihilator() : this("Nameless Annihilator")
        {
        }

        public Annihilator(string name)
        {
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 1.3);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats * 1.25);
            this.Defence = (int)(BaseStats * 0.74);
            this.Aim = (int)(BaseStats * 0.82);
            this.Evasion = (int)(BaseStats / 2.9);
            this.Speed = (int)(BaseStats * 0.7);
            this.CritChance = BaseStats / 14;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();
        }
    }
}
