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
            this.HealCountDown = 0;
        }



        public void Heal(Unit target)
        {
            Unit downed = target.Assigned.Find(u => u.StatusEffects.OfType<Down>().Any());
            if (downed != null)
            {
                Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                double modifyer = rd.Next(85, 120) / 100.00;
                int healAmount = (int)(modifyer * this.MedSkills);
                if (downed.Hp + healAmount > downed.MaxHp)
                {
                    downed.Hp = downed.MaxHp;
                }
                else
                {
                    downed.Hp += healAmount;
                }
                Console.WriteLine(this.Name + " uses an emergency kit and is able to get " + downed.Name + "back on the battlefield with " + healAmount + "HP.");
            }
            else
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
                Console.WriteLine(this.Name + " uses a medkit and is able to restore " + healAmount + "HP");
            }
        }

        public void Support()
        {
            throw new NotImplementedException();
        }
    }
}
