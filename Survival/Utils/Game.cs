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
                    HandleInput();
                    DrawGameField();
                }
                else
                {
                    inventory.ShowInventory();
                    Console.WriteLine();
                    Console.WriteLine("КРАФТЫ:\n1.Сделать лезвие ножа\n2.Сделать нож\n3.Сделать топор\n4.Сделать ткань\n5.Сделать баллон\n6.Сделать гондолу");
                    string sw = Console.ReadLine();
                    switch (sw)
                    {
                        case "1":
                            craft.MakeStoneKnife();
                            Console.ReadLine();
                            break;
                        case "2":
                            craft.MakeKnife();
                            Console.ReadLine();
                            break;
                        case "3":
                            craft.MakeAxe();
                            Console.ReadLine();
                            break;
                        case "4":
                            craft.MakeCloth();
                            Console.ReadLine();
                            break;
                        case "5":
                            craft.MakeTank();
                            Console.ReadLine();
                            break;
                        case "6":
                            craft.MakeGondola();
                            break;
                        case "i":
                            inventoryOpen = false;
                            break;
                    }
                }
                Thread.Sleep(100);
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
        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.LeftArrow)
                {
                    player.MoveLeft();
                }
                if (key == ConsoleKey.RightArrow)
                {
                    player.MoveRight();
                }
                if (key == ConsoleKey.UpArrow)
                {
                    player.MoveUp();
                }
                if (key == ConsoleKey.DownArrow)
                {
                    player.MoveDown();
                }
                if (key == ConsoleKey.I)
                {
                    inventory.ShowInventory();
                    inventoryOpen = true;
                }
            }
        }
    }
}