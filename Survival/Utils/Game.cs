using CraftClass;
using InventoryClass;
using MainCharacterClass;
using System;
using TreesClass;

namespace Survival.Utils
{
    class Game
    {
        private Dictionary<string, string> locations;
        private string currentLocation;
        Inventory inventory = new();
        Craft craft = new();
        public int screenWidth = 30;
        public int screenHeight = 30;
        MainCharacter player = new();
        private List<Trees> trees;
        private bool[,] gameField;
        private bool inventoryOpen = false;

        public Game()
        {
            locations = new Dictionary<string, string>
            {
                { "пляж", "Вы находитесь на пляже. Здесь много песка и несколько кокосов." },
                { "лес", "Вы в густом лесу. Здесь много деревьев и диких животных." },
                { "пещера", "Вы в тёмной пещере. Здесь холодно и сыро." },
                { "место крушения", "Вокруг разбросано то, что осталось от воздушного шара. Горелка ещё цела, нужно попробовать его восстановить." }
            };

            currentLocation = "пляж";
            gameField = new bool[20, 20];
            trees = new List<Trees>();
        }

        public void Start()
        {
            Console.SetWindowSize(30, 30);
            Console.SetBufferSize(30, 30);
            InitialiseTrees();
            while (true)
            {
                
                Console.Clear();

                if (!inventoryOpen)
                {
                    player.HandleInput();
                    DrawGameField();
                }
                else
                {
                    inventory.ShowInventory();
                }
            }
        }
        private void DrawGameField()
        {
            for (int y = 0; y < 20; y++)
            {
                for (int x = 0; x < 20; x++)
                {
                    if (x == player.PositionX && y == player.PositionY)
                    {
                        Console.Write("■");
                    }
                    else if (trees.Any(e => e.PositionX == x && e.PositionY == y))
                    {
                        Console.Write("T");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Локация: {currentLocation} \n {locations[currentLocation]}");
        }
        private void InitialiseTrees()
        {
            trees.Add(new Trees(18, 18));
            trees.Add(new Trees(8, 1));
            trees.Add(new Trees(20, 18));
            trees.Add(new Trees(14, 9));
            trees.Add(new Trees(16, 13));
            trees.Add(new Trees(3, 10));
            trees.Add(new Trees(18, 6));
            trees.Add(new Trees(1, 15));
            trees.Add(new Trees(19, 11));
            trees.Add(new Trees(6, 8));
            trees.Add(new Trees(10, 1));
            trees.Add(new Trees(5, 9));
            trees.Add(new Trees(11, 18));
            trees.Add(new Trees(1, 6));
            trees.Add(new Trees(12, 18));
        }
    }
}