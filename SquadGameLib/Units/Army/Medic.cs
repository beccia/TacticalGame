using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Army
{
    public class Medic : Unit, IHealer
    {
        public int MedSkills { get; set; }
        public int MinHealRoll { get; private set; }
        public int MaxHealRoll { get; private set; }

        public bool HasMedStation { get; set; }

        public Medic() : this(30)
        { 
        }


        public Medic(int medSkills) : base()
        {
            this.MedSkills = medSkills;
            this.MinHealRoll = 90;
            this.MaxHealRoll = 120;
            this.HasMedStation = false;
        }



        public void Heal(Unit target)
        {
            List<Unit> downed = this.Assigned.GetDownedUnits();
            if (downed.Any())
            {
                Unit healTarget = downed[0];
                int healAmount = RollHealAmount();
                healTarget.Hp += healAmount;
                healTarget.StatusEffects.Clear(new Down());
                Console.WriteLine(this.Name + " runs over to the rescue and is able to raise " + healTarget.Name +".");
            }
            else
            {
                int healAmount = RollHealAmount();
                target.Hp += healAmount;
                Console.WriteLine(this.Name + " runs over to treat " + target.Name + " and is able to restore " + healAmount + "HP");
            }
        }

        public int RollHealAmount()
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double modifyer = rd.Next(this.MinHealRoll, this.MaxHealRoll) / 100.00;
            int healAmount = (int)(modifyer * this.MedSkills);
            return healAmount;
        }

        public void Support()
        {
            Console.WriteLine(this.Name + " quickly gives medical aid to his squad during the short ceasefire.");
            foreach (Unit u in this.Assigned.GetViableTargets())
            {
                if (u == this) {
                    continue;
                }
                else
                {
                    int healAmount = RollHealAmount();
                    u.Hp += healAmount;
                    Console.WriteLine(this.Name + " is able to restore " + healAmount + "HP to " + u.Name);
                }
            }
            if (HasMedStation && this.Hp < this.MaxHp)
            {
                List<Unit> downed = this.Assigned.GetDownedUnits();
                if (downed.Any())
                {
                    Unit healTarget = downed[0];
                    healTarget.Hp += (int)(healTarget.MaxHp /33.333);
                    healTarget.StatusEffects.Clear(new Down());
                    Console.WriteLine($"{this.Name} runs over to the rescue and is able to raise " + healTarget.Name + ".");
                }
                int healAmount = RollHealAmount();
                this.Hp += healAmount;
                Console.WriteLine(this.Name + " patches himself up  for " + healAmount + "HP.");
            }
        }
    }
}
