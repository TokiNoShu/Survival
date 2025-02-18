using CraftClass;
using InventoryClass;
using Survival.Utils;

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

        public void MoveLeft()
        {
            PositionX--;
            if (PositionX < 0)
            {
                PositionX = 0;
            }
        }

        public void MoveRight()
        {
            PositionX++;
            if (PositionX > 19)
            {
                PositionX = 19;
            }
        }

        public void MoveUp()
        {
            PositionY--;
            if (PositionY < 0)
            {
                PositionY = 0;
            }
        }

        public void MoveDown()
        {
            PositionY++;
            if (PositionY > 19)
            {
                PositionY = 19;
            }
        }
    }
}