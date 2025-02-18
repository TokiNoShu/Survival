using CraftClass;

namespace InventoryClass
{
    public class Inventory
    {
        private Dictionary<string, int> items = new Dictionary<string, int>();
        Craft craft = new();

        public void AddItem(string itemName, int quantity)
        {
            if (items.ContainsKey(itemName))
            {
                items[itemName] += quantity;
            }
            else
            {
                items[itemName] = quantity;
            }
            Console.WriteLine($"{quantity} {itemName} добавлено(а) в инвентарь.");
        }
        
        public void RemoveItem(string itemName, int quantity)
        {
            if (items.ContainsKey(itemName))
            {
                if (CheckItem(itemName, quantity))
                {
                    items[itemName] -= quantity;
                    if (items[itemName] == 0)
                    {
                        items.Remove(itemName);
                    }
                }
                else
                {
                    Console.WriteLine($"Недостаточно {itemName} в инвентаре.");
                }
            }
            else
            {
                Console.WriteLine($"{itemName} отсутствует в инвентаре.");
            }
        }

        public void ShowInventory()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Инвентарь пуст.");
                return;
            }
            else
            {
                Console.WriteLine("Инвентарь:");
                foreach (KeyValuePair<string, int> item in items)
                {
                    Console.WriteLine($"- {item.Key}: {item.Value}");
                }
                Console.WriteLine();
                Console.WriteLine("КРАФТЫ:\n1.Сделать лезвие ножа\n2.Сделать нож\n3.Сделать топор\n4.Сделать ткань\n5.Сделать баллон\n6.Сделать гондолу");
                int sw = Convert.ToInt16(Console.ReadLine());
                switch (sw) 
                {
                    case 1:
                        craft.MakeStoneKnife();
                        break;
                    case 2:
                        craft.MakeKnife();
                        break;
                    case 3:
                        craft.MakeAxe();
                        break;
                    case 4:
                        craft.MakeCloth();
                        break;
                    case 5:
                        craft.MakeTank();
                        break;
                    case 6:
                        craft.MakeGondola();
                        break;
                }
            }

        }
        public bool CheckItem(string itemName, int quanity)
        {
            return items[itemName] >= quanity;
        }
    }
}