using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.units
{
    public interface ICombattable
    {
         void Attack();
         void SpecialAttack();
         void TacticalAbility();
         void Down();
         void Die();



    }
}
