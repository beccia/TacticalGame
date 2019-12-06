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
    public class Trooper : Unit, IHealer
    {
        public int MedSkills { get; set; }
        public int MinHealRoll { get; private set; }
        public int MaxHealRoll { get; private set; }

        public Trooper() : this("Nameless Trooper")
        { 
        }

        public Trooper(string name)
        {
            this.Name = name;
            this.MaxHp = BaseStats;
            this.Hp = MaxHp;
            this.AttackPower = BaseStats;
            this.Defence = (int)(BaseStats * 0.7);
            this.Aim = BaseStats;
            this.Evasion = (int)(BaseStats / 1.94);
            this.Speed = (int)(BaseStats * 1.12);
            this.CritChance = BaseStats / 12;
            this.Assigned = null;
            this.StatusEffects = new Status();
            this.Abilities = new AbilityList();

            this.MedSkills = 18;
            this.MinHealRoll = 85;
            this.MaxHealRoll = 115;
        }

        public void Heal(Unit target)
        { 
            int healAmount = RollHealAmount();
            this.Hp += healAmount;
                 Console.WriteLine(this.Name + " uses a medkit and is able to restore " + healAmount + "HP to himself.");
        }

        public int RollHealAmount() { 
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double modifyer = rd.Next(this.MinHealRoll, this.MaxHealRoll) / 100.00;
            int healAmount = (int)(modifyer * this.MedSkills);
            return healAmount;
        }

        public void Support()
        {
            List<Unit> availableTargets = Assigned.GetViableTargets();
            if (availableTargets.Count > 1) {
                int index = availableTargets.IndexOf(this);
                Unit healTarget = (index - 1 >= 0) ? availableTargets[index - 1] : availableTargets[index + 1];
                int healAmount = RollHealAmount();
                healTarget.Hp += healAmount;
                Console.WriteLine(this.Name + " uses a medkit on a nearby unit and is able to restore " + healAmount + "HP to " + healTarget.Name + ".");
            }
        }
    }
}
