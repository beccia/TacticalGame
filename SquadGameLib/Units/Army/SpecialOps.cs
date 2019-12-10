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
    public class SpecialOps : Unit
    {
        private const string className = "Special Ops";
        public bool DroneDeployed { get; set; }

        public SpecialOps() : this("Nameless Spec Ops")
        {
        }

        public SpecialOps(string name)
        {
            this.ClassName = className;
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 0.92);
            this.Hp = MaxHp;
            this.AttackPower = this.Defence = (int)(BaseStats * 0.86);
            this.Defence = (int)(BaseStats * 0.62);
            this.Aim = (int)(BaseStats * 0.92);
            this.Evasion = (int)(BaseStats / 1.64);
            this.Speed = (int)(BaseStats * 1.02);
            this.CritChance = (int)(BaseStats / 8.07);
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.DroneDeployed = false;
            this.AddAbility(new SupportDrone(true));
            this.AddAbility(new DroneStrike(true));
        }
    }
}
