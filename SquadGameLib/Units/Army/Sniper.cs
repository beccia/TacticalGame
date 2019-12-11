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
    public class Sniper : Unit
    {
        private const string className = "Sniper";
        public Unit Target{ get; set; }

        public Sniper() : this("")
        {
        }

        public Sniper(string name)
        {
            this.ClassName = className;
            this.Name = name;
            this.MaxHp = (int)(BaseStats * 0.85);
            this.Hp = MaxHp;
            this.AttackPower = this.Defence = (int)(BaseStats * 1.27);
            this.Defence = (int)(BaseStats * 0.59);
            this.Aim = (int)(BaseStats * 1.08);
            this.Evasion = (int)(BaseStats / 1.76);
            this.Speed = (int)(BaseStats * 0.72);
            this.CritChance = (int)(BaseStats / 3.2);
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.Target = null;

            this.AddAbility(new Camouflage(true));
            this.AddAbility(new Assassination(true));
        }

        public override void Attack(Unit target)
        {
            if (Target == null)
            {
                this.Target = target;
                Console.WriteLine($"\n{this.Name} takes aim and has lined up for a shot at {target.Name}.");
            } 
            else if (Target.Hp <= 0)
            {
                this.Target = target;
                Console.WriteLine($"\n{this.Name}'s intended target has been taken out by his squad. He sets his aim for {target.Name}.");
            }
            else
            {
                base.Attack(Target);
                this.Target = null;
            }
        }
    }
}
