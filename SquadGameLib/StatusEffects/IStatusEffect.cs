using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public interface IStatusEffect
    {
        Unit Affected { get; set; }
        int RemainingTime { get; set; }
        void Effect();
        void Undo();
    }
}
