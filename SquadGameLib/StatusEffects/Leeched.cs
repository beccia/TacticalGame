using SquadGameLib.units;
using SquadGameLib.Units;
using SquadGameLib.Units.Aliens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class Leeched : IStatusEffect
    {
        public Unit Affected { get; set; }

        public Shaman Afflictor {get; set;}
        public int RemainingTime { get; set; }

        private bool Applied;


        public Leeched(Unit affected, Shaman afflictor, int remainingTime)
        {
            this.Affected = affected;
            this.Afflictor = afflictor;
            this.RemainingTime = remainingTime;
            Applied = false;
            Effect();
        }

        public void Effect()
        {
            if (!Applied)
            {
                Applied = true;
                Console.WriteLine($"\n{Afflictor.Name}'s malicient spores attach to {Affected.Name}'s body and start sucking blood.");
            }
            int suckedHp = (int)((Afflictor.MedSkills * 0.75) * Afflictor.GetDamageModifyer(90, 110));
            Console.WriteLine($"{Afflictor.Name} sucks {suckedHp} HP out of {Affected.Name}.");
            this.Afflictor.Hp -= suckedHp;
            this.Afflictor.Hp += suckedHp;
        }

        public void Undo()
        {
            Console.Write(Affected.Hp > 0 ? $"\n{Affected.Name}'s body was able to get rid of the leeching spores." : "");
            this.Affected = null;
            this.Afflictor = null;
        }

        
    }
}
