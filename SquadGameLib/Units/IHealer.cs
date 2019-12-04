using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Units
{
    public interface IHealer
    {
        int MedSkills { get; set; }
    
        void Heal(Unit target);

        int RollHealAmount();

        void Support();
    }
}
