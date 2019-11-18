using SquadGameLib.StatusEffects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib.units
{
    public abstract class Unit
    {
        public const int BaseStats = 100;

        public string Name { get; set; }

        public int MaxHp { get; private set; }
        public int Hp { get; private set; }
        public int AttackPower { get; private set; }
        public int Defence { get; private set; }
        public int Aim { get; private set; }
        public int Evasion { get; private set; }
        public int Speed { get; private set; }

        public Squad Assigned { get; private set; }

        public StatusEffects a { get; private set; }

        //TODO: ABility, Status effect
        

        public Unit()
        {
            this.Name = "nameless";
            this.MaxHp = BaseStats;
            this.Hp = MaxHp;
            this.AttackPower = BaseStats;
            this.Defence = BaseStats;
            this.Aim = BaseStats;
            this.Evasion = BaseStats / 2;
            this.Speed = BaseStats;
            this.Assigned = null;
            this.StatusEffects = new List<IStatusEffect>();
        }





        public void Attack(Unit unit)
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

        public void SpecialAttack(Unit unit)
        {
            throw new NotImplementedException();
        }

        public void TacticalAbility(Unit unit)
        {
            throw new NotImplementedException();

        }

        public void AddStatusEffect(IStatusEffect se)
        {

        }

        public void AssignToSquad(Squad squad)
        {
            squad.Add(this);
            this.Assigned = squad;
        }
    }

}
