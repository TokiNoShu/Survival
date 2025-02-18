namespace InventoryClass
{
    public class Inventory
    {
        private Dictionary<string, int> items = new Dictionary<string, int>();

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
            Console.WriteLine("Инвентарь:");
            foreach (KeyValuePair<string, int> item in items)
            {
                Console.WriteLine($"- {item.Key}: {item.Value}");
            }
        }
        public bool CheckItem(string itemName, int quanity)
        {
            return items[itemName] >= quanity;
        }
    }
}