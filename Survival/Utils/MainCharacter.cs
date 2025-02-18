using AnimalsClass;
using InventoryClass;
using System;
using System.Collections.Generic;
using System.Linq;
using TreesClass;

namespace MainCharacterClass
{
    class MainCharacter
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Hunger { get; set; } = 100; 
        private int hungerCounter = 0;

        public MainCharacter()
        {
            PositionX = 5;
            PositionY = 5;
        }

        public void MoveLeft(List<Trees> trees)
        {
            int newX = PositionX - 1;
            if (newX >= 0 && !IsCollision(newX, PositionY, trees))
            {
                PositionX = newX;
            }
            else if (newX < 0)
            {
                PositionX = 19; // Переход на противоположную сторону (хуево работает)
            }
        }

        public void MoveRight(List<Trees> trees)
        {
            int newX = PositionX + 1;
            if (newX < 20 && !IsCollision(newX, PositionY, trees))
            {
                PositionX = newX;
            }
            else if (newX >= 20)
            {
                PositionX = 0; // Переход на противоположную сторону (хуево работает)
            }
        }

        public void MoveUp(List<Trees> trees)
        {
            int newY = PositionY - 1;
            if (newY >= 0 && !IsCollision(PositionX, newY, trees))
            {
                PositionY = newY;
            }
            else if (newY < 0)
            {
                PositionY = 19; // Переход на противоположную сторону (хуево работает)
            }
        }

        public void MoveDown(List<Trees> trees)
        {
            int newY = PositionY + 1;
            if (newY < 20 && !IsCollision(PositionX, newY, trees))
            {
                PositionY = newY;
            }
            else if (newY >= 20)
            {
                PositionY = 0; // Переход на противоположную сторону (хуево работает)
            }
        }

        private bool IsCollision(int x, int y, List<Trees> trees)
        {
            return trees.Any(tree => tree.PositionX == x && tree.PositionY == y);
        }

        public void UpdateHunger()
        {
            hungerCounter++;
            if (hungerCounter >= 20) 
            {
                Hunger -= 1;
                hungerCounter = 0;
            }

            if (Hunger <= 0)
            {
                Console.WriteLine("Вы умерли от голода.");
                Environment.Exit(0);
            }
        }

        public void Eat(Inventory inventory)
        {
            if (inventory.CheckItem("кокос", 1))
            {
                inventory.RemoveItem("кокос", 1);
                Hunger = Math.Min(Hunger + 20, 100); 
                Console.WriteLine("Вы съели кокос. Голод уменьшился.");
            }
            else if (inventory.CheckItem("мясо", 1))
            {
                inventory.RemoveItem("мясо", 1);
                Hunger = Math.Min(Hunger + 30, 100); 
                Console.WriteLine("Вы съели мясо. Голод уменьшился.");
            }
            else
            {
                Console.WriteLine("У вас нет еды.");
            }
        }

        public void ChopTree(List<Trees> trees, Inventory inventory)
        {
            if (inventory.CheckItem("топор", 1))
            {
                Trees treeToRemove = trees.FirstOrDefault(tree => tree.PositionX == PositionX && tree.PositionY == PositionY);
                if (treeToRemove != null)
                {
                    trees.Remove(treeToRemove);
                    inventory.AddItem("древесина", 1);
                    Console.WriteLine("Вы срубили дерево и получили древесину!");
                }
                else
                {
                    Console.WriteLine("Здесь нет дерева.");
                }
            }
            else
            {
                Console.WriteLine("У вас нет топора для рубки дерева.");
            }
        }

        public void Fight(List<Animal> animals, Inventory inventory)
        {
            Animal animalToFight = animals.FirstOrDefault(a => a.PositionX == PositionX && a.PositionY == PositionY);
            if (animalToFight != null)
            {
                if (inventory.CheckItem("нож", 1))
                {
                    animalToFight.Health -= 5;
                    if (animalToFight.Health <= 0)
                    {
                        animals.Remove(animalToFight);
                        inventory.AddItem("мясо", 1);
                        Console.WriteLine("Вы победили животное и получили мясо!");
                    }
                    else
                    {
                        Console.WriteLine($"Вы атаковали животное. У него осталось здоровья: {animalToFight.Health}");
                    }
                }
                else
                {
                    Console.WriteLine("У вас нет оружия для сражения.");
                }
            }
            else
            {
                Console.WriteLine("Здесь нет животных.");
            }
        }

        public void CollectResources(string location, Inventory inventory)
        {
            if (location == "пещера")
            {
                inventory.AddItem("камень", 1);
                Console.WriteLine("Вы собрали камень!");
            }
            else if (location == "лес")
            {
                inventory.AddItem("палка", 1);
                Console.WriteLine("Вы собрали палку!");
            }
            else if (location == "пляж")
            {
                inventory.AddItem("кокос", 1);
                Console.WriteLine("Вы собрали кокос!");
            }
            else
            {
                Console.WriteLine("Здесь нечего собирать.");
            }
        }
    }
}