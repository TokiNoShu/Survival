using System;
using System.Collections.Generic;

namespace Survival.Utils
{
    class Game
    {
        private Dictionary<string, string> locations;
        private string currentLocation;
        Inventory inventory = new();

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
            Console.WriteLine("Добро пожаловать в 'Выживание на острове'!");
            Console.WriteLine("После 80-ти дневного путешествия вокруг света на воздушном шаре");
            Console.WriteLine("вы попадаете в ураган. Вы очнулись на пляже, вокруг скачут макаки,");
            Console.WriteLine("а в носу стойкий запах морского бриза. Нужно выжить. ");
            Console.WriteLine("Перед вами пляж, лес, пещера и место крушения.");
            Console.WriteLine("Введите 'выход' для завершения игры.");
            Console.WriteLine("Введите 'подсказка' для получения советов по прохождению.");

            while (true)
            {
                Console.WriteLine(locations[currentLocation]);
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
                else if (command == "идти на пляж")
                {
                    currentLocation = "пляж";
                }
                else if (command == "идти к месту крушения")
                {
                    currentLocation = "место крушения";
                }
                else if (command == "собрать кокосы" && currentLocation == "пляж")
                {
                    inventory.Add("кокос");
                    Console.WriteLine("Вы собрали кокосы! Кажется, из кожуры выйдет отличная ткань!");
                }
                else if (command == "собрать волокно" && currentLocation == "лес")
                {
                    inventory.Add("волокно");
                    Console.WriteLine("Вы собрали волокно!");
                }
                else if (command == "собрать камни" && currentLocation == "пещера")
                {
                    inventory.Add("камень");
                    Console.WriteLine("Вы собрали камни!");
                }
                else if (command == "собрать палки" && currentLocation == "лес")
                {
                    inventory.Add("палка");
                    Console.WriteLine("Вы собрали палки!");
                }
                else if (command == "сделать топор")
                {
                    if (inventory.Contains("камень") && inventory.Contains("палка"))
                    {
                        inventory.Remove("камень");
                        inventory.Remove("палка");
                        inventory.Add("топор");
                        Console.WriteLine("Вы сделали топор!");
                    }
                    else
                    {
                        Console.WriteLine("У вас нет необходимых материалов для создания топора.");
                    }
                }
                else if (command == "добыть древесину" && currentLocation == "лес")
                {
                    if (inventory.Contains("топор"))
                    {
                        inventory.Add("древесина");
                        Console.WriteLine("Вы добыли древесину!");
                    }
                    else
                    {
                        Console.WriteLine("У вас нет топора для добычи древесины.");
                    }
                }
                else if (command == "сделать ткань")
                {
                    if (inventory.Contains("кокос") && inventory.Contains("волокно"))
                    {
                        inventory.Remove("кокос");
                        inventory.Remove("волокно");
                        inventory.Add("ткань");
                        Console.WriteLine("Вы сделали ткань!");
                    }
                    else
                    {
                        Console.WriteLine("У вас нет необходимых материалов для создания ткани.");
                    }
                }
                else if (command == "сделать баллон")
                {
                    if (inventory.FindAll(item => item == "ткань").Count >= 7)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            inventory.Remove("ткань");
                        }
                        inventory.Add("баллон");
                        Console.WriteLine("Вы сделали баллон!");
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно ткани для создания баллона.");
                    }
                }
                else if (command == "сделать гондолу")
                {
                    if (inventory.FindAll(item => item == "древесина").Count >= 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            inventory.Remove("древесина");
                        }
                        inventory.Add("гондола");
                        Console.WriteLine("Вы сделали гондолу!");
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно древесины для создания гондолы.");
                    }
                }
                else if (command == "починить воздушный шар" && currentLocation == "место крушения")
                {
                    if (inventory.Contains("баллон") && inventory.Contains("гондола"))
                    {
                        Console.WriteLine("Вы починили воздушный шар и улетели с острова!");
                        Console.WriteLine("Но ваше путешествие ещё не закончилось, кто знает, куда вас занесёт в следующий раз?");
                        Console.WriteLine("Поздравляем, вы выиграли!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("У вас нет необходимых материалов для починки воздушного шара.");
                    }
                }
                else if (command == "подсказка")
                {
                    GiveHint();
                }
                else
                {
                    Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                }

                Console.WriteLine("Ваш инвентарь: " + string.Join(", ", inventory));
            }
        }

        private void GiveHint()
        {
            Console.WriteLine("=== Подсказка ===");

            if (!inventory.Contains("кокос") && currentLocation == "пляж")
            {
                Console.WriteLine("- Соберите кокосы на пляже, чтобы использовать их для создания ткани.");
            }

            if (!inventory.Contains("волокно") && currentLocation == "лес")
            {
                Console.WriteLine("- Соберите волокно в лесу, чтобы использовать его для создания ткани.");
            }

            if (!inventory.Contains("камень") && currentLocation == "пещера")
            {
                Console.WriteLine("- Соберите камни в пещере, чтобы использовать их для создания топора.");
            }

            if (!inventory.Contains("палка") && currentLocation == "лес")
            {
                Console.WriteLine("- Соберите палки в лесу, чтобы использовать их для создания топора.");
            }

            if (!inventory.Contains("топор") && inventory.Contains("камень") && inventory.Contains("палка"))
            {
                Console.WriteLine("- Используйте камень и палку, чтобы создать топор.");
            }

            if (!inventory.Contains("древесина") && inventory.Contains("топор") && currentLocation == "лес")
            {
                Console.WriteLine("- Используйте топор в лесу, чтобы добыть древесину.");
            }

            if (!inventory.Contains("ткань") && inventory.Contains("кокос") && inventory.Contains("волокно"))
            {
                Console.WriteLine("- Используйте кокос и волокно, чтобы создать ткань.");
            }

            if (!inventory.Contains("баллон") && inventory.FindAll(item => item == "ткань").Count >= 7)
            {
                Console.WriteLine("- Используйте 7 тканей, чтобы создать баллон.");
            }

            if (!inventory.Contains("гондола") && inventory.FindAll(item => item == "древесина").Count >= 5)
            {
                Console.WriteLine("- Используйте 5 древесины, чтобы создать гондолу.");
            }

            if (!inventory.Contains("баллон") || !inventory.Contains("гондола"))
            {
                Console.WriteLine("- Соберите баллон и гондолу, чтобы починить воздушный шар на месте крушения.");
            }

            if (inventory.Contains("баллон") && inventory.Contains("гондола") && currentLocation != "место крушения")
            {
                Console.WriteLine("- Идите к месту крушения, чтобы починить воздушный шар и улететь.");
            }

            Console.WriteLine("================");
        }
    }
}