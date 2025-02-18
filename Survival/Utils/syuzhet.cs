using InventoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Survival.Utils
{
    class syuzhet
    {
        Inventory inventory = new();
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
        /*private void GiveHint()
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
        }*/
        /*            Console.WriteLine("Добро пожаловать в 'Выживание на острове'!");
            Console.WriteLine("После 80-ти дневного путишествия вокруг света на воздушном шаре");
            Console.WriteLine("вы попадаете в ураган. Вы очнулись на пляже, вокруг скачут макаки,");
            Console.WriteLine("а в носу стойкий запах морского бриза. Нужно выжить. ");
            Console.WriteLine("Перед вами пляж, лес, пещера и место крушения.");
            Console.WriteLine("Введите 'выход' для завершения игры.");
            Console.WriteLine("Введите 'подсказка' для получения советов по прохождению.");*/
    }
}
