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

        public BattleController CreateBattle(Squad playerSquad, Squad enemySquad)
        {
            return new BattleController(playerSquad, enemySquad);
        }

        public void CreatePlayerSquad(Player player)
        {
            for (int i = 0; i < PlayerSquadSize; i++)
            {
                Unit u = (Unit)FactoryDirector.CreateFactory(new EarthArmySoldierFactory()).Create();
                u.Name = "Trooper nr " + (i);
                u.AssignToSquad(player.PlayerSquad);
            }
        }


        public Squad CreateEnemySquad(int level = 1)
        {
            Squad enemySquad = new Squad($"Enemy Squad lv.{level}:");
            ISoldierFactory<Unit> factory = FactoryDirector.CreateFactory(new AlienSoldierFactory());
            switch (level)
            {
                case 1:
                    for (int i = 0; i < PlayerSquadSize; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = "Grunt nr " + (i + 1);
                        u.AssignToSquad(enemySquad);

                    }
                    return enemySquad;
                case 2:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = "Grunt nr " + (i + 1);
                        u.AssignToSquad(enemySquad);

                    }
                    Unit shaman = factory.CreateMedicSoldier();
                    shaman.Name = "Alien Shaman";
                    shaman.AssignToSquad(enemySquad);
                    return enemySquad;
                case 3:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = "Grunt nr " + (i + 1);
                        u.AssignToSquad(enemySquad);

                    }
                    Unit annihiliator = factory.CreateHeavySoldier();
                    annihiliator.Name = "Alien Annihilator";
                    annihiliator.AssignToSquad(enemySquad);
                    return enemySquad;
                case 4:
                    for (int i = 0; i < PlayerSquadSize - 2; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = "Grunt nr " + (i + 1);
                        u.AssignToSquad(enemySquad);

                    }
                    annihiliator = factory.CreateHeavySoldier();
                    annihiliator.Name = "Alien Annihilator";
                    annihiliator.AssignToSquad(enemySquad);

                    shaman = factory.CreateMedicSoldier();
                    shaman.Name = "Alien Shaman";
                    shaman.AssignToSquad(enemySquad);
                    return enemySquad;
                case 5:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = "Grunt nr " + (i + 1);
                        u.AssignToSquad(enemySquad);

                    }
                    Unit striker = factory.CreateScout();
                    striker.Name = "Alien Striker";
                    striker.AssignToSquad(enemySquad);
                    return enemySquad;

                case 6:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = "Grunt nr " + (i + 1);
                        u.AssignToSquad(enemySquad);
                    }
                    Unit battlelord = factory.CreateTechSoldier();
                    battlelord.Name = "Alien Battlelord";
                    battlelord.AssignToSquad(enemySquad);
                    return enemySquad;
                default:
                    return enemySquad;
            }
        }


    }
}
