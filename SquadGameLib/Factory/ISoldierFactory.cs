using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public interface ISoldierFactory<ICombattable>
    {


        ICombattable Create();
        ICombattable CreateBasicSoldier();
        ICombattable CreateHeavySoldier();
        ICombattable CreateTechSoldier();
        ICombattable CreateScout();
        ICombattable CreateMedicSoldier();

    }
}
