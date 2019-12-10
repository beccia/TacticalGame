using SquadGameLib.Abilities;
using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Army
{
    public class HeavyGunner : Unit
    {
        private const string className = "Heavy Gunner";
        public HeavyGunner() : this("Nameless Heavy")
        {
        }

        public HeavyGunner(string name)
        {
            this.ClassName = className;
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 1.12);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats * 1.16);
            this.Defence = (int)(BaseStats * 0.75);
            this.Aim = (int)(BaseStats * 0.86);
            this.Evasion = (int)(BaseStats / 2.24);
            this.Speed = (int)(BaseStats * 0.99);
            this.CritChance = BaseStats / 10;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.AddAbility(new CoveringFire(true));
            this.AddAbility(new Barrage(true));
        }


    }
}
