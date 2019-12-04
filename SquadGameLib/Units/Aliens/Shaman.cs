using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units.Aliens
{
    public class Shaman : Unit, IHealer
    {
        public int MedSkills { get; set; }
        public int MinHealRoll { get; private set; }
        public int MaxHealRoll { get; private set; }
        public Shaman() : base()
        {
            this.MedSkills = 35;
            this.MinHealRoll = 70;
            this.MaxHealRoll = 125;
        }

        public void Heal(Unit target)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
