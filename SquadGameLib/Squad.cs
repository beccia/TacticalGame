﻿using SquadGameLib.Enums;
using SquadGameLib.StatusEffects;
using SquadGameLib.units;
using SquadGameLib.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class Squad : List<Unit>
    {
        public String Name { get; private set; }

        public Strategy Strategy { get; set; }



        public bool isDefeated()
        {
            bool result;
            int combatants = 0;
            foreach (Unit u in this)
            {
                if (!u.IsIncapacitated())
                {
                    combatants++;
                }
            }
            result = (combatants > 0)?  false : true;
            return result;
        }

        public List<Unit> GetViableTargets()
        {
            List<Unit> list = this.ToList<Unit>();
            var result = list.Where(unit => !unit.IsIncapacitated());
            return result.ToList<Unit>();
        }

        public List<Unit> GetDownedUnits()
        {
            List<Unit> list = this.ToList<Unit>();
            var result = list.Where(unit => unit.StatusEffects.OfType<Down>().Any());
            return result.ToList<Unit>();
        }

        public void ExecuteSupportActions()
        {
            List<IHealer> supportUnits = new List<IHealer>();
            foreach (Unit u in this)
            {
                if (u is IHealer)
                {

                    supportUnits.Add((IHealer)u);
                }
            }
            if (supportUnits.Count > 0)
            {
                Console.WriteLine("Sqadmembers of " + this.Name + "are commencing their support actions in between the fighting.");
                foreach (IHealer healer in supportUnits)
                {
                    healer.Support();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Squadname : {Name} \n Units: {this.Count} \n Strategy: {Strategy}");
            return sb.ToString();

        }
    }
}
