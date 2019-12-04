﻿using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.StatusEffects
{
    public class AttackUp : IStatusEffect
    {
        public Unit Affected { get; set; }
        public int RemainingTime { get; set; }
        public int AttackBuff { get; private set; }

        private bool Applied;


        public AttackUp(Unit affected, int remainingTime, int attackBuff)
        {
            this.Affected = affected;
            this.RemainingTime = remainingTime;
            this.AttackBuff = attackBuff;
            Applied = false;
            Effect();
        }

        public void Effect()
        {
            if (!Applied)
            {
                Affected.AttackPower += AttackBuff;
                Applied = true;
                Console.WriteLine($"{Affected.Name}'s attack power went up.");
            }
        }

        public void Undo()
        {
            Console.WriteLine($"{Affected.Name}'s offensive power returned to normal.");
            Affected.AttackPower-= AttackBuff;
        }
    }
}