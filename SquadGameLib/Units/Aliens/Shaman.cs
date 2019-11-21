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
        public Shaman() : base()
        {
            this.MedSkills = 35;
        }

        public void Heal(Unit target)
        {
            throw new NotImplementedException();
        }

        public void Support()
        {
            throw new NotImplementedException();
        }
    }
}
