using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.units
{
    public abstract class Unit : ICombattable
    {
        public const int BaseStats = 100;

        public int MaxHp { get; private set; }
        public int Hp { get; private set; }
        public int AttackPower { get; private set; }
        public int Defence { get; private set; }
        public int Aim { get; private set; }
        public int Evasion { get; private set; }
        public int Speed { get; private set; }

        public Squad Assigned { get; private set; }

        //TODO: ABility, Status effect



        public Unit()
        {
            this.MaxHp = BaseStats;
            this.Hp = MaxHp;
            this.AttackPower = BaseStats;
            this.Defence = BaseStats;
            this.Aim = BaseStats;
            this.Evasion = BaseStats / 2;
            this.Speed = BaseStats;
        }





        public void Attack(ICombattable enemy)
        {
            throw new NotImplementedException();
        }

        public void Die()
        {
            throw new NotImplementedException();
        }

        public void Down()
        {
            throw new NotImplementedException();
        }

        public void SpecialAttack(ICombattable enemy)
        {
            throw new NotImplementedException();
        }

        public void TacticalAbility()
        {
            throw new NotImplementedException();
        }
    }
}
