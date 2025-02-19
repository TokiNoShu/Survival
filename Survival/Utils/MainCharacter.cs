using AnimalsClass; // Предполагается, что это пространство имен существует
using InventoryClass; // Предполагается, что это пространство имен существует
using System;
using System.Collections.Generic;
using System.Linq;
using TreesClass; // Предполагается, что это пространство имен существует

namespace MainCharacterClass
{
    class MainCharacter
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Hunger { get; set; } = 100;
        private int hungerCounter = 0;
        private const int WORLD_SIZE = 20; // Размер мира - константа

        public MainCharacter()
        {
            PositionX = 5;
            PositionY = 5;
        }

        // Улучшенные методы передвижения с использованием оператора модуля для обхода границ
        public void MoveLeft(List<Trees> trees)
        {
            PositionX = (PositionX - 1 + WORLD_SIZE) % WORLD_SIZE; // Циклический переход
            if (IsCollision(PositionX, PositionY, trees))
            {
                PositionX = (PositionX + 1) % WORLD_SIZE; // Возвращение на прежнюю позицию при столкновении
            }
        }

        public void MoveRight(List<Trees> trees)
        {
            PositionX = (PositionX + 1) % WORLD_SIZE; // Циклический переход
            if (IsCollision(PositionX, PositionY, trees))
            {
                PositionX = (PositionX - 1 + WORLD_SIZE) % WORLD_SIZE; // Возвращение на прежнюю позицию при столкновении
            }
        }

        public void MoveUp(List<Trees> trees)
        {
            PositionY = (PositionY - 1 + WORLD_SIZE) % WORLD_SIZE; // Циклический переход
            if (IsCollision(PositionX, PositionY, trees))
            {
                PositionY = (PositionY + 1) % WORLD_SIZE; // Возвращение на прежнюю позицию при столкновении
            }
        }

        public void MoveDown(List<Trees> trees)
        {
            PositionY = (PositionY + 1) % WORLD_SIZE; // Циклический переход
            if (IsCollision(PositionX, PositionY, trees))
            {
                PositionY = (PositionY - 1 + WORLD_SIZE) % WORLD_SIZE; // Возвращение на прежнюю позицию при столкновении
            }
        }

        public bool IsCollision(int x, int y, List<Trees> trees)
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