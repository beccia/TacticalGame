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
            
            GameController gameController = new GameController(4);
            Player player = new Player();

            gameController.CreatePlayerSquad(player);
            Squad enemySquad = gameController.CreateEnemySquad();

            BattleController battleController = new BattleController(player.PlayerSquad, enemySquad );


            



            Assert.IsNotNull(battleController.RunBattle());


        }
    }
}
