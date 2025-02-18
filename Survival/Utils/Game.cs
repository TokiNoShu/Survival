using CraftClass;
using InventoryClass;
using MainCharacterClass;
using System.Threading;

namespace Survival.Utils
{
    class Game
    {
        private Dictionary<string, string> locations;
        private string currentLocation;
        Inventory inventory = new();
        Craft craft = new();
        public int screenWidth = 15;
        public int screenHeight = 15;
        Random random = new Random();
        List<(int x, int y)> treePositions = new List<(int x, int y)>();
        MainCharacter player = new();

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

        }
        
        public void Start()
        {
/*            Console.WriteLine("Добро пожаловать в 'Выживание на острове'!");
            Console.WriteLine("После 80-ти дневного путишествия вокруг света на воздушном шаре");
            Console.WriteLine("вы попадаете в ураган. Вы очнулись на пляже, вокруг скачут макаки,");
            Console.WriteLine("а в носу стойкий запах морского бриза. Нужно выжить. ");
            Console.WriteLine("Перед вами пляж, лес, пещера и место крушения.");
            Console.WriteLine("Введите 'выход' для завершения игры.");
            Console.WriteLine("Введите 'подсказка' для получения советов по прохождению.");*/
            Console.SetWindowSize(20, 20);
            Console.SetBufferSize(20, 20);

            while (true)
            {
                Draw();
                Thread.Sleep(50000000);
                /*Console.WriteLine(locations[currentLocation]);
                Console.WriteLine("Что вы хотите сделать? ");
                string command = Console.ReadLine().ToLower();

                if (command == "выход")
                {
                    Console.WriteLine("Спасибо за игру!");
                    break;
                }
                else if (command == "идти в лес")
                {
                    currentLocation = "лес";
                }
                else if (command == "идти в пещеру")
                {
                    currentLocation = "пещера";
                }
                else if (command == "вернуться на пляж")
                {
                    currentLocation = "пляж";
                }
                else if (command == "идти к месту крушения")
                {
                    currentLocation = "место крушения";
                }
                else if (command == "собрать кокосы" && currentLocation == "пляж")
                {
                    inventory.AddItem("кокос", 1);
                }
                else if (command == "собрать волокно" && currentLocation == "лес")
                {
                    inventory.AddItem("волокно", 1);
                }
                else if (command == "собрать камни" && currentLocation == "пещера")
                {
                    inventory.AddItem("камень", 1);
                }
                else if (command == "собрать палки" && currentLocation == "лес")
                {
                    inventory.AddItem("палка", 1);
                }
                else if (command == "сделать топор")
                {
                    craft.MakeAxe();
                }
                else if (command == "добыть древесину" && currentLocation == "лес")
                {
                    if (inventory.CheckItem("топор", 1))
                    {
                        inventory.AddItem("древесина", 1);
                    }
                    else
                    {
                        Console.WriteLine("У вас нет топора для добычи древесины.");
                    }
                }
                else if (command == "сделать ткань")
                {
                    craft.MakeCloth();
                }
                else if (command == "сделать баллон")
                {
                    craft.MakeTank();
                }
                else if (command == "сделать гондолу")
                {
                    craft.MakeGondola();
                }
                else if (command == "починить воздушный шар" && currentLocation == "место крушения")
                {
                    if (inventory.CheckItem("баллон", 1) && inventory.CheckItem("гондола", 1))
                    {
                        Console.WriteLine("Вы починили воздушный шар и улетели с острова!");
                        Console.WriteLine("Но ваше путишествие ещё не закончилось, кто знает, куда вас занесёт в следующий раз?");
                        Console.WriteLine("Поздравляем, вы выиграли!");
                        break;
                    }
                }
                else if (command == "осмотреться")
                {
                    Console.WriteLine("Вы осмотрелись и ничего не нашли.");
                }
                else if (command == "подсказка")
                {
                    GiveHint();
                }
                else if (command == "инвентарь")
                {
                    inventory.ShowInventory();
                }
                else if (command == "получить")
                {
                    inventory.AddItem(Console.ReadLine(), 1);
                }
                else
                {
                    Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                }*/
            }
        }
        public void Draw()
        {
            Console.Clear();

            for (int x = 0; x < screenWidth + 2; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("-");
            }

            for (int y = 1; y <= screenHeight; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("|");
                Console.SetCursorPosition(screenWidth + 1, y);
                Console.Write("|");
            }

            for (int x = 0; x < screenWidth + 2; x++)
            {
                Console.SetCursorPosition(x, screenHeight + 1);
                Console.Write("-");
            }
            int numTrees = 20;
            for (int i = 0; i < numTrees; i++)
            {
                int x, y;
                do
                {
                    x = random.Next(1, screenWidth);
                    y = random.Next(1, screenHeight);
                } while (TreesOverlap(x, y));

                Console.SetCursorPosition(x, y);
                Console.Write("T");
            }
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    if (x == player.PositionX && y == player.PositionY)
                    {
                        Console.Write("■");
                    }
                }
            }
        }
        bool TreesOverlap(int x, int y)
        {
            // Проверяем, есть ли дерево в этой позиции или рядом
            foreach (var pos in treePositions)
            {
                if (pos.x == x && pos.y == y) return true;
            }
            return false;
        }
        private void GiveHint()
        {
            Console.WriteLine("=== Подсказка ===");

            if (!inventory.CheckItem("кокос", 1) && currentLocation == "пляж")
            {
                Console.WriteLine("- Соберите кокосы на пляже, чтобы использовать их для создания ткани.");
            }

            if (!inventory.CheckItem("волокно", 1) && currentLocation == "лес")
            {
                Console.WriteLine("- Соберите волокно в лесу, чтобы использовать его для создания ткани.");
            }

            if (!inventory.CheckItem("камень", 1) && currentLocation == "пещера")
            {
                Console.WriteLine("- Соберите камни в пещере, чтобы использовать их для создания топора.");
            }

            if (!inventory.CheckItem("палка", 1) && currentLocation == "лес")
            {
                Console.WriteLine("- Соберите палки в лесу, чтобы использовать их для создания топора.");
            }

            if (!inventory.CheckItem("топор", 1) && inventory.CheckItem("камень", 1) && inventory.CheckItem("палка", 1))
            {
                Console.WriteLine("- Используйте камень и палку, чтобы создать топор.");
            }

            if (!inventory.CheckItem("древесина", 1) && inventory.CheckItem("топор", 1) && currentLocation == "лес")
            {
                Console.WriteLine("- Используйте топор в лесу, чтобы добыть древесину.");
            }

            if (!inventory.CheckItem("ткань", 1) && inventory.CheckItem("кокос", 1) && inventory.CheckItem("волокно", 1))
            {
                Console.WriteLine("- Используйте кокос и волокно, чтобы создать ткань.");
            }

            if (!inventory.CheckItem("баллон", 1) && inventory.CheckItem("ткань", 7))
            {
                Console.WriteLine("- Используйте 7 тканей, чтобы создать баллон.");
            }

            if (!inventory.CheckItem("гондола", 1) && inventory.CheckItem("древесина", 5))
            {
                Console.WriteLine("- Используйте 5 древесины, чтобы создать гондолу.");
            }

            if (!inventory.CheckItem("баллон", 1) || !inventory.CheckItem("гондола", 1))
            {
                Console.WriteLine("- Соберите баллон и гондолу, чтобы починить воздушный шар на месте крушения.");
            }

            if (inventory.CheckItem("баллон", 1) && inventory.CheckItem("гондола", 1) && currentLocation != "место крушения")
            {
                Console.WriteLine("- Идите к месту крушения, чтобы починить воздушный шар и улететь.");
            }

            Console.WriteLine("================");
        }
    }
}