using InventoryClass;

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
                { "лес", "Вы в густом лесу. Здесь много деревьев и диких животных" },
                { "пещера", "Вы в тёмной пещере. Здесь холодно и сыро." }
            };

            currentLocation = "пляж";

        }
        public void Start()
        {
            Console.WriteLine("Добро пожаловать в 'Выживание на острове'!");
            Console.WriteLine("Вы можете исследовать локации: пляж, лес, пещера.");
            Console.WriteLine("Введите 'выход' для завершения игры.");

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
                else if (command == "вернуться на пляж")
                {
                    currentLocation = "пляж";
                }
                else if (command == "собрать кокосы" && currentLocation == "пляж")
                {
                    inventory.AddItem("кокос", 1);
                }
                else if (command == "собрать древесину" && currentLocation == "лес")
                {
                    inventory.AddItem("древесина", 1);
                }
                else if (command == "осмотреться")
                {
                    Console.WriteLine("Вы осмотрелись и ничего не нашли.");
                }
                else Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                
                Console.WriteLine("Ваш инвентарь: " + string.Join(", ", inventory));
            }
        }
    }
}