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
        public int HealCountDown { get; set; }
        public Trooper() : base()
        {
            this.MedSkills = 15;
        }



        public void Heal(Unit target)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double modifyer = rd.Next(85, 120) / 100.00;
            int healAmount = (int)(modifyer * this.MedSkills);
            if (this.Hp + healAmount > this.MaxHp)
            {
                this.Hp = this.MaxHp;
            }
             else
             {
                 this.Hp += healAmount;
             }
                 Console.WriteLine(this.Name + " uses a medkit and is able to restore " + healAmount + "HP.");
        }


        public void Support()
        {
            if (Assigned.GetViableTargets().Count > 1) {
                int index = Assigned.GetViableTargets().IndexOf(this);
                Unit healTarget = (index - 1 >= 0) ? Assigned[index - 1] : Assigned[index + 1];
                Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                double modifyer = rd.Next(85, 120) / 100.00;
                int healAmount = (int)(modifyer * this.MedSkills);
                if (healTarget.Hp + healAmount > this.MaxHp)
                {
                    healTarget.Hp = this.MaxHp;
                }
                else
                {
                    healTarget.Hp += healAmount;
                }
                Console.WriteLine(this.Name + " uses a medkit on a nearby unit and is able to restore " + healAmount + "HP to " + healTarget.Name + ".");
            }
        }
    }
}
