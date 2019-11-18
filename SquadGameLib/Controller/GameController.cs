using SquadGameLib.Controller;
using SquadGameLib.Factory;
using SquadGameLib.units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquadGameLib
{
    public class GameController
    {
        
        public int PlayerSquadSize { get; private set; }
        public int EnemySquadSize { get; private set; }
        public FactoryDirector FactoryDirector = FactoryDirector.GetInstanceOf();

        public GameController()
        {
        }

        public GameController(int squadSize)
        {
            this.PlayerSquadSize = squadSize;
            this.EnemySquadSize = squadSize;
        }

        public void CreatePlayerSquad(Player player)
        {
            for (int i = 0; i < PlayerSquadSize; i++)
            {
                Unit u = (Unit)FactoryDirector.CreateFactory(new EarthArmySoldierFactory()).Create();
                u.Name = "Trooper nr " + i;
                u.AssignToSquad(player.PlayerSquad);
            }
        }


        public Squad CreateEnemySquad()
        {
            Squad enemySquad = new Squad();
            for (int i = 0; i < PlayerSquadSize; i++)
            {
                Unit u = (Unit)FactoryDirector.CreateFactory(new AlienSoldierFactory()).Create();
                u.Name = "Grunt nr " + i;
                u.AssignToSquad(enemySquad);
            }
            return enemySquad;
        }

        public BattleController CreateBattle(Squad playerSquad, Squad enemySquad)
        {
            return new BattleController(playerSquad, enemySquad);
        }
    }
}
