using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquadGameLib;

namespace UnitTests
{
    [TestClass]
    public class CreateSquadTest
    {
        [TestMethod]
        public void DefaultSquadCreationTest()
        {
            GameController gameController = new GameController(4);
            Player player = new Player();

            gameController.CreatePlayerSquad(player);

            Squad enemySquad = gameController.CreateEnemySquad();

            Assert.AreEqual(gameController.PlayerSquadSize, player.PlayerSquad.Count);
            Assert.AreEqual(gameController.PlayerSquadSize, player.PlayerSquad.Count);

        }
    }

}
