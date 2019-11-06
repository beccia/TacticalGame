using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.units
{
    public interface ICombattable
    {
         void Attack(Unit unit);
         void SpecialAttack(Unit unit);
         void TacticalAbility(Unit unit);
         void Down();
         void Die();



    }
}
