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
            this.HealBuff = 24;
            this.DefenceBuff = 19;
            Applied = false;
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.Defence += DefenceBuff;
                ((Medic)this.Affected).MedSkills += HealBuff;
                Applied = true;
                Console.WriteLine($"Medical station built: healng improved, and {Affected.Name} can heal himself and revive a fallen unit between rounds.\n");
                ((Medic)this.Affected).HasMedStation = true;
            }
            else
            {
                Console.WriteLine($"{Affected.Name}'s medical station is standing and helping the squad's survival.");
            }
        }

        public void Undo()
        {
            Console.WriteLine($"{Affected.Name}'s repair station broke down in the battle.");
            Affected.Defence -= DefenceBuff;
            ((Medic)this.Affected).MedSkills -= HealBuff;
            ((Medic)this.Affected).HasMedStation = false;
            this.Affected = null;
        }
    }
}
