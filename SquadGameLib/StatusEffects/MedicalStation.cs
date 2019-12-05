using SquadGameLib.units;
using SquadGameLib.Units.Army;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class MedicalStation : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int HealBuff { get; private set; }
        public int DefenceBuff { get; private set; }

        private bool Applied;


        public MedicalStation(Unit affected, int remainingTime)
        {
            this.Affected = affected;
            this.RemainingTime = remainingTime;
            this.HealBuff = 25;
            this.DefenceBuff = 18;
            Applied = false;
            Effect();
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.Defence += DefenceBuff;
                ((Medic)this.Affected).MedSkills += HealBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}' is controling a support drone. Evasion and attack power reduced.");
                ((Medic)this.Affected).HasMedStation = true;
            }
            Console.WriteLine($"{Affected.Name}'s support drone is hovering the battlefield, spotting targets for the squad.");
        }

        public void Undo()
        {
            Console.WriteLine($"{Affected.Name}'s support drone lands for resupplies & repairs.");
            Affected.Defence -= DefenceBuff;
            ((Medic)this.Affected).MedSkills -= HealBuff;
            ((Medic)this.Affected).HasMedStation = false;
            this.Affected = null;
        }
    }
}
