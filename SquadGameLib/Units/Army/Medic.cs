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

        public Medic() : base()
        {
            this.MedSkills = 40;
        }


        public Medic(int medSkills) : base()
        {
            this.MedSkills = medSkills;
        }



        public void Heal(Unit target)
        {
            List<Unit> downed = this.Assigned.GetDownedUnits();
            if (downed.Any())
            {
                Unit healTarget = downed[0];
                Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                double modifyer = rd.Next(85, 120) / 100.00;
                int healAmount = (int)(modifyer * this.MedSkills) - 10;
                if (healTarget.Hp + healAmount > healTarget.MaxHp)
                {
                    healTarget.Hp = healTarget.MaxHp;
                }
                else
                {
                    healTarget.Hp += healAmount;
                }
                healTarget.StatusEffects.Clear(new Down());
                Console.WriteLine(this.Name + " runs over to the rescue and is able to raise" + healTarget.Name + "back on the battlefield with " + healAmount + "HP.");
            }
            else
            {
                Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                double modifyer = rd.Next(85, 115) / 100.00;
                int healAmount = (int)(modifyer * this.MedSkills);
                if (target.Hp + healAmount > target.MaxHp)
                {
                    target.Hp = target.MaxHp;
                }
                else
                {
                    target.Hp += healAmount;
                }
                Console.WriteLine(this.Name + " runs over to treat " + target.Name + " and is able to restore " + healAmount + "HP");
            }
        }
        public void Support()
        {
            foreach (Unit u in this.Assigned.GetViableTargets())
            {
                Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
                double modifyer = rd.Next(85, 115) / 100.00;
                int healAmount = (int)(modifyer * (this.MedSkills * 0.48));
                if (u.Hp + healAmount > u.MaxHp)
                {
                    u.Hp = u.MaxHp;
                }
                else
                {
                   u.Hp += healAmount;
                }
                Console.WriteLine(this.Name + "quickly gives mediacl aid to his squad during the short ceasefire.");
                Console.WriteLine(this.Name + " is able to restore " + healAmount + "HP to " + u.Name);
            }
        }
    }
}
