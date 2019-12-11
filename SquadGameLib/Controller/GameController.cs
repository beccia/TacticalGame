using SquadGameLib.Controller;
using SquadGameLib.Enums;
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
        public Player Player { get; set; }
        public FactoryDirector FactoryDirector = FactoryDirector.GetInstanceOf();

        public GameController(int squadSize, Player player)
        {
            this.Player = player;
            this.PlayerSquadSize = squadSize;
            this.EnemySquadSize = squadSize;
        }

        public void PlayerChooseYourSquad()
        {
            bool confirmed = false;
            ISoldierFactory<Unit> factory = FactoryDirector.CreateFactory(Player.Faction);
            List<Unit> availableTypes = new List<Unit>();
            availableTypes.Add(factory.CreateBasicSoldier());
            availableTypes.Add(factory.CreateHeavySoldier());
            availableTypes.Add(factory.CreateTechSoldier());
            availableTypes.Add(factory.CreateMedicSoldier());
            availableTypes.Add(factory.CreateScout());

            do
            {
                for (int i = 0; Player.PlayerSquad.Count() < PlayerSquadSize; i++)
                {
                    Console.WriteLine($"\nChoose unit number {Player.PlayerSquad.Count() + 1}.\n");

                    int n = GetUnitSelectionInput(availableTypes);

                    var @switch = new Dictionary<int, Action>
                    {
                        {0, () => availableTypes.ForEach(u => Console.WriteLine(u.ToString()))},
                        {1, () => factory.CreateBasicSoldier().AssignToSquad(Player.PlayerSquad)},
                        {2, () => factory.CreateHeavySoldier().AssignToSquad(Player.PlayerSquad)},
                        {3, () => factory.CreateTechSoldier().AssignToSquad(Player.PlayerSquad)},
                        {4, () => factory.CreateMedicSoldier().AssignToSquad(Player.PlayerSquad)},
                        {5, () => factory.CreateScout().AssignToSquad(Player.PlayerSquad)},
                    };
                    if (@switch.ContainsKey(n))
                    {
                        @switch[n]();
                    }
                }

                Console.WriteLine($"------------------------\nYour selected Squad: ");
                Console.WriteLine(Player.PlayerSquad.ToString());
                Console.Write($"Is this okay (y/n) ?");

                string input = Console.ReadLine();
                confirmed = input == "y" || input == "Y" ? true: false;
            } while (!confirmed);
        }

        public int GetUnitSelectionInput(List<Unit> availableTypes)
        {
            Console.WriteLine($"\nUse numbered key to choose a unit to join your squad: ");
            Console.WriteLine($" 1 = {availableTypes[0].ClassName}, \n 2 = {availableTypes[1].ClassName}, \n 3 = {availableTypes[2].ClassName}, \n 4 =  {availableTypes[3].ClassName}, \n 5 = {availableTypes[4].ClassName}");
            Console.WriteLine($"\nOr Press 0 to see unit info.");
            return Convert.ToInt32(Console.ReadLine());
        }

        public Squad CreateSquad(Faction faction, int level = 1)
        {
            Squad squad = new Squad($"{faction} Squad lv.{level}:");
            ISoldierFactory<Unit> factory = FactoryDirector.CreateFactory(faction);
            switch (level)
            {
                case 1:
                    for (int i = 0; i < PlayerSquadSize; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = $"{u.ClassName} nr {i + 1}";
                        u.AssignToSquad(squad);

                    }
                    return squad;
                case 2:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = $"{u.ClassName} nr {i + 1}";
                        u.AssignToSquad(squad);

                    }
                    Unit m = factory.CreateMedicSoldier();
                    m.Name = $"The {m.ClassName}";
                    m.AssignToSquad(squad);
                    return squad;
                case 3:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = $"{u.ClassName} nr {i + 1}";
                        u.AssignToSquad(squad);

                    }
                    Unit h = factory.CreateHeavySoldier();
                    h.Name = $"The {h.ClassName}";
                    h.AssignToSquad(squad);
                    return squad;
                case 4:
                    for (int i = 0; i < PlayerSquadSize - 2; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = $"{u.ClassName} nr {i + 1}";
                        u.AssignToSquad(squad);

                    }
                    h = factory.CreateHeavySoldier();
                    h.Name = $"The {h.ClassName}";
                    h.AssignToSquad(squad);

                    m = factory.CreateMedicSoldier();
                    m.Name = $"The {h.ClassName}";
                    m.AssignToSquad(squad);
                    return squad;
                case 5:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = $"{u.ClassName} nr {i + 1}";
                        u.AssignToSquad(squad);

                    }
                    Unit s = factory.CreateScout();
                    s.Name = $"The {s.ClassName}";
                    s.AssignToSquad(squad);
                    return squad;

                case 6:
                    for (int i = 0; i < PlayerSquadSize - 1; i++)

                    {
                        Unit u = factory.Create();
                        u.Name = $"{u.ClassName} nr {i + 1}";
                        u.AssignToSquad(squad);
                    }
                    Unit t= factory.CreateTechSoldier();
                    t.Name = $"The {t.ClassName}";
                    t.AssignToSquad(squad);
                    return squad;
                default:
                    return squad;
            }
        }


    }
}
