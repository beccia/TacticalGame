using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public interface ISoldierFactory<Unit>
    {


        Unit Create();
        Unit CreateBasicSoldier();
        Unit CreateHeavySoldier();
        Unit CreateTechSoldier();
        Unit CreateScout();
        Unit CreateMedicSoldier();

    }
}
