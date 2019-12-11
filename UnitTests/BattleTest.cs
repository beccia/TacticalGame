using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquadGameLib;
using SquadGameLib.Controller;

namespace UnitTests
{
    [TestClass]
    public class BattleTest
    {
        [TestMethod]
        public void RunSimpleBattle()
        {
            Player player = new Player();
            GameController gameController = new GameController(4, player);


            gameController.CreateSquad(SquadGameLib.Enums.Faction.EarthForces);
            Squad enemySquad = gameController.CreateSquad(SquadGameLib.Enums.Faction.Aliens);

            BattleController battleController = new BattleController(player.PlayerSquad, enemySquad );


            



            Assert.IsNotNull(battleController.RunBattle());


        }
    }
}
