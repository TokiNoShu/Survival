using CraftClass;
using InventoryClass;
using Survival.Utils;
using TreesClass;

namespace MainCharacterClass
{
    class MainCharacter
    {
        Inventory inventory = new();
        Craft craft = new();
        public int PositionX { get; set; }
        public int PositionY { get; set; }

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
        }

        public void MoveRight(List<Trees> trees)
        {
            int newX = PositionX + 1;
            if (newX < 20 && !IsCollision(newX, PositionY, trees))
            {
                PositionX = newX;
            }
        }

        public void MoveUp(List<Trees> trees)
        {
            int newY = PositionY - 1;
            if (newY >= 0 && !IsCollision(PositionX, newY, trees))
            {
                PositionY = newY;
            }
        }

        public void MoveDown(List<Trees> trees)
        {
            int newY = PositionY + 1;
            if (newY < 20 && !IsCollision(PositionX, newY, trees))
            {
                PositionY = newY;
            }
        }
        private bool IsCollision(int x, int y, List<Trees> trees)
        {
            return trees.Any(tree => tree.PositionX == x && tree.PositionY == y);
        }
    }
}