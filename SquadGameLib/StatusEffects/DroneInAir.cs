using SquadGameLib.units;
using SquadGameLib.Units.Army;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    /** Status effet for SecOps class to determine wether it has a drone in the air. Lowers avasion and attack power due to having to monitor the drone, but it allows for 
     * drone strike special attack to be used. Default stats are set in the constructor
     */
    public class DroneInAir : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int EvasionDeBuff { get; private set; }
        public int AttackDeBuff { get; private set; }

        private bool Applied;


        public DroneInAir(Unit affected, int remainingTime)
        {
            this.Affected = affected;
            this.RemainingTime = remainingTime;
            this.EvasionDeBuff = 30;
            this.AttackDeBuff = 15;
            Applied = false;
            Effect();
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.Evasion -= EvasionDeBuff;
                Affected.AttackPower -= AttackDeBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}' is controling a support drone. Evasion and attack power reduced.");
                ((SpecialOps)this.Affected).DroneDeployed = true;
            }
            Console.WriteLine($"{Affected.Name}'s support drone is hovering the battlefield, spotting targets for the squad.");
        }

        public void Undo()
        {
            Console.WriteLine($"{Affected.Name}'s support drone lands for resupply and repairs.");
            Affected.Evasion += EvasionDeBuff;
            Affected.AttackPower += AttackDeBuff;
            ((SpecialOps)this.Affected).DroneDeployed = false;
            this.Affected = null;
        }
    }
}

