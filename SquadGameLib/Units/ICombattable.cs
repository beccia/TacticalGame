using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.units
{
    public interface ICombattable
    {
         void Attack(ICombattable enemy);
         void SpecialAttack(ICombattable enemy);
         void TacticalAbility();
         void Down();
         void Die();



    }
}
