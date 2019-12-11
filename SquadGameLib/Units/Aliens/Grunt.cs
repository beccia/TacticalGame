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
        private const string className = "Grunt";
        public Grunt() : this("")
        {
        }

        public Grunt(string name)
        {
            this.ClassName = className;
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 1.09);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats * 1.04);
            this.Defence = (int)(BaseStats * 0.73);
            this.Aim = (int)(BaseStats * 0.91);
            this.Evasion = (int)(BaseStats / 2.11);
            this.Speed = (int)(BaseStats * 0.98);
            this.CritChance = BaseStats / 14;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.AddAbility(new Rush(true));
        }
     
    }
}
