using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.Abilities
{
    public interface IAbility
    {
        string Name { get; set; }
        int CooldownCount { get; set; }
        int CooldownTime { get; set; }

        public void ReduceCooldownTimer();
    }
}
