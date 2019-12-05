using SquadGameLib.units;
using System;


namespace SquadGameLib.StatusEffects
{
    public class AimUp : IStatusEffect
    {
        
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int AimBuff { get; private set; }

        private bool Applied;


        public AimUp(Unit affected, int remainingTime, int aimBuff)
        {
            this.Affected = affected;
            this.RemainingTime = remainingTime;
            this.AimBuff = aimBuff;
            Applied = false;
            Effect();
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.Aim += AimBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}'s capability to hit targets increased.");
            }
        }

        public void Undo()
        { 
            Console.WriteLine($"{Affected.Name}'s capability to hit targets returned to normal.");
            Affected.Aim -= AimBuff;
            this.Affected = null;
        }
    }

}

