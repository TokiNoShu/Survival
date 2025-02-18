using AnimalsClass;
using CraftClass;
using InventoryClass;
using MainCharacterClass;
using System;
using System.Collections.Generic;
using System.Linq;
using TreesClass;

namespace Survival.Utils
{
    class Game
    {
        private Dictionary<string, string> locations;
        private string currentLocation;
        private Inventory inventory = new();
        private Craft craft = new();
        private MainCharacter player = new();
        private List<Trees> trees;
        private List<Animal> animals;
        private bool inventoryOpen = false;


        private string[,] locationMap = new string[3, 2]
        {
            { "пещера", "пусто" },
            { "пляж", "место крушения" },
            { "лес", "пусто" }
        };

        private int mapX = 1; 
        private int mapY = 0;

        public Game()
        {
            locations = new Dictionary<string, string>
            {
                { "пещера", "Вы в тёмной пещере. Здесь холодно и сыро. На полу виднеются камни." },
                { "пляж", "Вы находитесь на пляже. Здесь много песка и несколько кокосов." },
                { "лес", "Вы в густом лесу. Здесь много деревьев и диких животных." },
                { "место крушения", "Вокруг разбросано то, что осталось от воздушного шара. Горелка ещё цела, нужно попробовать его восстановить." }
            };

            currentLocation = locationMap[mapX, mapY]; 
            trees = new List<Trees>();
            animals = new List<Animal>();
            InitialiseTrees();
            InitialiseAnimals();
        }

        public void Start()
        {
            Console.SetWindowSize(90, 60); 
            Console.SetBufferSize(90, 60);

            Console.WriteLine("Добро пожаловать в 'Выживание на острове'!");
            Console.WriteLine("После 80-дневного путешествия вокруг света на воздушном шаре");
            Console.WriteLine("вы попали в ураган. Вы очнулись на пляже, вокруг скачут макаки,");
            Console.WriteLine("а в носу стойкий запах морского бриза. Нужно выжить.");
            Console.WriteLine("Перед вами пляж, лес, пещера и место крушения.");
            Console.WriteLine("Введите 'выход' для завершения игры.");

            while (true)
            {
                Console.Clear();

                if (!inventoryOpen)
                {
                    HandleInput();
                    DrawGameField();
                    player.UpdateHunger();
                }
                else
                {
                    inventory.ShowInventory();
                    Console.WriteLine();
                    Console.WriteLine("КРАФТЫ:\n1. Сделать лезвие ножа\n2. Сделать нож\n3. Сделать топор\n4. Сделать ткань\n5. Сделать баллон\n6. Сделать гондолу");
                    string sw = Console.ReadLine();
                    switch (sw)
                    {
                        case "1":
                            craft.MakeStoneKnife();
                            break;
                        case "2":
                            craft.MakeKnife();
                            break;
                        case "3":
                            craft.MakeAxe();
                            break;
                        case "4":
                            craft.MakeCloth();
                            break;
                        case "5":
                            craft.MakeTank();
                            break;
                        case "6":
                            craft.MakeGondola();
                            break;
                        case "i":
                            inventoryOpen = false;
                            break;
                    }
                }

                CheckWinCondition();
                Thread.Sleep(100);
            }
        }

        private void DrawGameField()
        {
            DrawHungerBar();
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
                    else if (animals.Any(a => a.PositionX == x && a.PositionY == y))
                    {
                        Console.Write("A");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Локация: {currentLocation} \n {locations[currentLocation]}");
            DrawControls();
            DrawMap(); 
        }

        private void DrawMap()
        {
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Карта локаций:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.SetCursorPosition(25 + j * 10, 2 + i * 2);
                    if (i == mapX && j == mapY)
                    {
                        Console.Write($"[{locationMap[i, j]}]"); 
                    }
                    else
                    {
                        Console.Write(locationMap[i, j]);
                    }
                }
            }
        }

        private void DrawHungerBar()
        {
            Console.Write("Голод: [");
            int hungerSegments = player.Hunger / 10; 
            for (int i = 0; i < 10; i++)
            {
                if (i < hungerSegments)
                {
                    Console.Write("▓");
                }
                else
                {
                    Console.Write("░");
                }
            }
            Console.WriteLine("]");
        }

        private void InitialiseTrees()
        {
            Random random = new Random();
            for (int i = 0; i < 15; i++)
            {
                trees.Add(new Trees(random.Next(0, 20), random.Next(0, 20)));
            }
        }

        private void InitialiseAnimals()
        {
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                animals.Add(new Animal(random.Next(0, 20), random.Next(0, 20)));
            }
        }

        private void HandleInput() //(гига ультра хуево работает)
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        player.MoveLeft(trees);
                        if (player.PositionX < 0)
                        {
                            if (mapY > 0 && locationMap[mapX, mapY - 1] != "пусто")
                            {
                                player.PositionX = 19; 
                                ChangeLocation(mapX, mapY - 1); 
                            }
                            else
                            {
                                player.PositionX = 19; 
                                Console.WriteLine("Вы не можете туда пойти.");
                            }
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        player.MoveRight(trees); 
                        if (player.PositionX >= 20)
                        {
                            if (mapY < 1 && locationMap[mapX, mapY + 1] != "пусто")
                            {
                                player.PositionX = 0; 
                                ChangeLocation(mapX, mapY + 1); 
                            }
                            else
                            {
                                player.PositionX = 0;
                                Console.WriteLine("Вы не можете туда пойти.");
                            }
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        player.MoveUp(trees); 
                        if (player.PositionY < 0)
                        {
                            if (mapX > 0 && locationMap[mapX - 1, mapY] != "пусто")
                            {
                                player.PositionY = 19; 
                                ChangeLocation(mapX - 1, mapY); 
                            }
                            else
                            {
                                player.PositionY = 19; 
                                Console.WriteLine("Вы не можете туда пойти.");
                            }
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        player.MoveDown(trees); 
                        if (player.PositionY >= 20)
                        {
                            if (mapX < 2 && locationMap[mapX + 1, mapY] != "пусто")
                            {
                                player.PositionY = 0; 
                                ChangeLocation(mapX + 1, mapY); 
                            }
                            else
                            {
                                player.PositionY = 0; 
                                Console.WriteLine("Вы не можете туда пойти.");
                            }
                        }
                        break;
                    case ConsoleKey.C:
                        player.ChopTree(trees, inventory);
                        break;
                    case ConsoleKey.F:
                        player.Fight(animals, inventory);
                        break;
                    case ConsoleKey.E:
                        player.Eat(inventory);
                        break;
                    case ConsoleKey.I:
                        inventoryOpen = true;
                        break;
                    case ConsoleKey.Spacebar:
                        player.CollectResources(currentLocation, inventory);
                        break;
                }
            }
        }

        private void ChangeLocation(int newX, int newY)
        {
            if (newX >= 0 && newX < 3 && newY >= 0 && newY < 2 && locationMap[newX, newY] != "пусто")
            {
                mapX = newX;
                mapY = newY;
                currentLocation = locationMap[mapX, mapY];
                Console.WriteLine($"Вы переместились в {currentLocation}.");
            }
            else
            {
                Console.WriteLine("Вы не можете туда пойти.");

                if (player.PositionX < 0) player.PositionX = 0;
                if (player.PositionX >= 20) player.PositionX = 19;
                if (player.PositionY < 0) player.PositionY = 0;
                if (player.PositionY >= 20) player.PositionY = 19;
            }
        }

        private void CheckWinCondition()
        {
            if (currentLocation == "место крушения" && inventory.CheckItem("баллон", 1) && inventory.CheckItem("гондола", 1))
            {
                Console.WriteLine("Вы починили воздушный шар и улетели с острова!");
                Console.WriteLine("Но ваше путешествие ещё не закончилось, кто знает, куда вас занесёт в следующий раз?");
                Console.WriteLine("Поздравляем, вы выиграли!");
                Environment.Exit(0);
            }
        }

        private void DrawControls()
        {
            Console.WriteLine("Управление:");
            Console.WriteLine("← → ↑ ↓ - Движение");
            Console.WriteLine("C - Рубить дерево (нужен топор)");
            Console.WriteLine("F - Сражаться с животным (нужен нож)");
            Console.WriteLine("E - Есть (кокос или мясо)");
            Console.WriteLine("Пробел - Собирать ресурсы");
            Console.WriteLine("I - Открыть инвентарь и крафт");
            Console.WriteLine("Выход - Закрыть игру");
        }
    }
}