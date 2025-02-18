using InventoryClass;

namespace CraftClass
{
    class Craft
    {
        private Inventory inventory = new();

        public void MakeStoneKnife()
        {
            if (inventory.CheckItem("камень", 2))
            {
                inventory.RemoveItem("камень", 2);
                inventory.AddItem("лезвие ножа", 1);
                Console.WriteLine("Вы сделали лезвие ножа!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания лезвия ножа.");
            }
        }

        public void MakeKnife()
        {
            if (inventory.CheckItem("палка", 1) && inventory.CheckItem("лезвие ножа", 1))
            {
                inventory.RemoveItem("палка", 1);
                inventory.RemoveItem("лезвие ножа", 1);
                inventory.AddItem("нож", 1);
                Console.WriteLine("Вы сделали нож!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания ножа.");
            }
        }

        public void MakeAxe()
        {
            if (inventory.CheckItem("камень", 1) && inventory.CheckItem("палка", 1) && inventory.CheckItem("ткань", 1))
            {
                inventory.RemoveItem("камень", 1);
                inventory.RemoveItem("палка", 1);
                inventory.RemoveItem("ткань", 1);
                inventory.AddItem("топор", 1);
                Console.WriteLine("Вы сделали топор!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания топора.");
            }
        }

        public void MakeCloth()
        {
            if (inventory.CheckItem("кокос", 1) && inventory.CheckItem("волокно", 1))
            {
                inventory.RemoveItem("кокос", 1);
                inventory.RemoveItem("волокно", 1);
                inventory.AddItem("ткань", 1);
                Console.WriteLine("Вы сделали ткань!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания ткани.");
            }
        }

        public void MakeTank()
        {
            if (inventory.CheckItem("ткань", 7))
            {
                inventory.RemoveItem("ткань", 7);
                inventory.AddItem("баллон", 1);
                Console.WriteLine("Вы сделали баллон!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания баллона.");
            }
        }

        public void MakeGondola()
        {
            if (inventory.CheckItem("древесина", 5))
            {
                inventory.RemoveItem("древесина", 5);
                inventory.AddItem("гондола", 1);
                Console.WriteLine("Вы сделали гондолу!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания гондолы.");
            }
        }
    }
}