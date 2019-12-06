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
    public class Grunt : Unit
    {


        public Grunt() : this("Nameless grunt")
        {
        }

        public Grunt(string name)
        {
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 1.06);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats / 1.04);
            this.Defence = (int)(BaseStats * 0.7);
            this.Aim = (int)(BaseStats * 0.95);
            this.Evasion = (int)(BaseStats / 2.09);
            this.Speed = (int)(BaseStats * 1.08);
            this.CritChance = BaseStats / 14;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.AddAbility(new Rush(true));
        }
     
    }
}
