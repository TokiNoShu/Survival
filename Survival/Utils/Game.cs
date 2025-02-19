using AnimalsClass;
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
        private MainCharacter player = new();
        private List<Trees> trees;
        private List<Animal> animals;
        private bool inventoryOpen = false;


        private string[,] locationMap = {
            {"пляж", "лес"},
            {"пещера", "место крушения"}
        };

        private int mapX = 0; 
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
                            inventory.MakeStoneKnife();
                            break;
                        case "2":
                            inventory.MakeKnife();
                            break;
                        case "3":
                            inventory.MakeAxe();
                            break;
                        case "4":
                            inventory.MakeCloth();
                            break;
                        case "5":
                            inventory.MakeTank();
                            break;
                        case "6":
                            inventory.MakeGondola();
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
                        if (currentLocation == locationMap[0, 1])
                            Console.Write("T");
                        else if (currentLocation == locationMap[0, 0])
                            Console.Write("Y");
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
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.SetCursorPosition(25 + j * 10, 2 + i * 2);
                    if (i == mapX && j == mapY)
                    {
                        Console.Write($"[{currentLocation}]");
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
                    case ConsoleKey.LeftArrow: MovePlayer(-1, 0); break;
                    case ConsoleKey.RightArrow: MovePlayer(1, 0); break;
                    case ConsoleKey.UpArrow: MovePlayer(0, -1); break;
                    case ConsoleKey.DownArrow: MovePlayer(0, 1); break;
                    case ConsoleKey.C: player.ChopTree(trees, inventory); break;
                    case ConsoleKey.F: player.Fight(animals, inventory); break;
                    case ConsoleKey.E: player.Eat(inventory); break;
                    case ConsoleKey.I: inventoryOpen = true; break;
                    case ConsoleKey.Spacebar: player.CollectResources(currentLocation, inventory); break;
                }
            }
        }
        private void MovePlayer(int dx, int dy)
        {
            int newX = player.PositionX + dx;
            int newY = player.PositionY + dy;

            // Проверка на выход за границы текущей локации
            if (newX < 0 || newX >= 20 || newY < 0 || newY >= 20)
            {
                HandleLocationChange(dx, dy);
                return; // Выход из функции, если произошло изменение локации
            }


            if (!player.IsCollision(newX, newY, trees))
            {
                player.PositionX = newX;
                player.PositionY = newY;
            }
            else
            {
                Console.WriteLine("На пути препятствие!");
            }
        }
        private void HandleLocationChange(int dx, int dy)
        {
            int newMapX = mapX + dx;
            int newMapY = mapY + dy;

            if (IsValidLocation(newMapX, newMapY))
            {
                // Определение новой позиции игрока на новой карте (нужно уточнить логику)
                int newPlayerX = (dx > 0) ? 0 : 20 - 1;
                int newPlayerY = (dy > 0) ? 0 : 20 - 1;

                player.PositionX = newPlayerX;
                player.PositionY = newPlayerY;
                ChangeLocation(newMapX, newMapY);
            }
            else
            {
                Console.WriteLine("Вы не можете туда пойти.");

                //Откат позиции игрока  (Важно!)
                player.PositionX -= dx;
                player.PositionY -= dy;

            }
        }
        private void ChangeLocation(int newX, int newY)
        {
            if (IsValidLocation(newX, newY))
            {
                mapX = newX;
                mapY = newY;
                currentLocation = locationMap[mapX, mapY];
                Console.WriteLine($"Вы переместились в {currentLocation}.");
            }
            else
            {
                Console.WriteLine("Вы не можете туда пойти.");
            }
        }
        private bool IsValidLocation(int x, int y)
        {
            // Проверяем, находятся ли координаты в пределах карты
            return x >= 0 && x < locationMap.GetLength(0) && y >= 0 && y < locationMap.GetLength(1);
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