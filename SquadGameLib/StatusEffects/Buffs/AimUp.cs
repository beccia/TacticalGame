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


        public AimUp(int remainingTime, int aimBuff)
        {
            this.RemainingTime = remainingTime;
            this.AimBuff = aimBuff;
            Applied = false;
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
            Console.Write(Affected.Hp > 0?  $"\n{Affected.Name}'s boost to to accuracy wore off." : "");
            Affected.Aim -= AimBuff;
            this.Affected = null;
        }
    }

}

