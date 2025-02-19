using MiNET;
using System;
using System.Collections.Generic;
using System.Windows.Markup;

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

        public bool CheckItem(string itemName, int quantity)
        {
            return items.ContainsKey(itemName) && items[itemName] >= quantity;
        }
        public void MakeStoneKnife()
        {
            if (CheckItem("камень", 2))
            {
                RemoveItem("камень", 2);
                AddItem("лезвие ножа", 1);
                Console.WriteLine("Вы сделали лезвие ножа!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания лезвия ножа.");
            }
        }
        public void MakeKnife()
        {
            if (CheckItem("палка", 1) && CheckItem("лезвие ножа", 1))
            {
                RemoveItem("палка", 1);
                RemoveItem("лезвие ножа", 1);
                AddItem("нож", 1);
                Console.WriteLine("Вы сделали нож!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания ножа.");
            }
        }
        public void MakeAxe()
        {
            if (CheckItem("камень", 1) && CheckItem("палка", 1) && CheckItem("ткань", 1))
            {
                RemoveItem("камень", 1);
                RemoveItem("палка", 1);
                RemoveItem("ткань", 1);
                AddItem("топор", 1);
                Console.WriteLine("Вы сделали топор!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания топора.");
            }
        }

        public void MakeCloth()
        {
            if (CheckItem("кокос", 1))
            {
                RemoveItem("кокос", 1);
                AddItem("ткань", 1);
                Console.WriteLine("Вы сделали ткань!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания ткани.");
            }
        }

        public void MakeTank()
        {
            if (CheckItem("ткань", 7))
            {
                RemoveItem("ткань", 7);
                AddItem("баллон", 1);
                Console.WriteLine("Вы сделали баллон!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания баллона.");
            }
        }

        public void MakeGondola()
        {
            if (CheckItem("древесина", 5))
            {
                RemoveItem("древесина", 5);
                AddItem("гондола", 1);
                Console.WriteLine("Вы сделали гондолу!");
            }
            else
            {
                Console.WriteLine("Недостаточно материалов для создания гондолы.");
            }
        }
    }
}