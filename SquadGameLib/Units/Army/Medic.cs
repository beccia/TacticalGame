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
            this.MedSkills = 35;
        }


        public Medic(int medSkills) : base()
        {
            this.MedSkills = medSkills;
        }

        

        public void Heal(Unit target)
        {
            Random rd = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            double modifyer = rd.Next(85, 115)/100.00;
            int healAmount = (int)(modifyer * this.MedSkills);
            if (target.Hp + healAmount > target.MaxHp)
            {
                target.Hp = target.MaxHp;
            }
            else
            {
                target.Hp += healAmount;
            }
            Console.WriteLine(this.Name + " runs over to treat "+ target.Name + " and is able to restore " + healAmount + "HP" );
        }

        public void Support()
        {
            throw new NotImplementedException();
        }
    }
}
