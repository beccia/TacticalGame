using SquadGameLib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class Player
    {
        public string Name { get; private set; }
        public Faction Faction { get; private set; }
        public Squad PlayerSquad { get; private set; }

        public Player()
        {
            Name = "Player 1";
            Faction = Faction.EarthForces;
            PlayerSquad = new Squad("Player's squad");
        }

        public Player(string name, Faction faction, Squad playerSquad)
        {
            this.Name = name;
            this.Faction = faction;
            this.PlayerSquad = playerSquad;
        }
    }
}
