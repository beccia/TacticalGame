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
            this.MaxHp = (int)(BaseStats * 1.34);
            this.Hp = MaxHp;
            this.AttackPower = (int)(BaseStats * 1.27);
            this.Defence = (int)(BaseStats * 0.76);
            this.Aim = (int)(BaseStats * 0.81);
            this.Evasion = (int)(BaseStats / 3.2);
            this.Speed = (int)(BaseStats * 0.7);
            this.CritChance = BaseStats / 14;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.AddAbility(new AnnihilationBeam(true));
        }
    }
}
