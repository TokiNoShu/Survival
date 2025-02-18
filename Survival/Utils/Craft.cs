using InventoryClass;

namespace CraftClass
{

    class Craft
    {
        Inventory inventory = new();

        public void MakeStoneKnife()
        {
            inventory.RemoveItem("камень", 2);
            inventory.AddItem("лезвие ножа", 1);
        }
        public void MakeKnife()
        {
            inventory.RemoveItem("палка", 1);
            inventory.RemoveItem("лезвие ножа", 1);
            inventory.AddItem("нож", 1);
        }
        public void MakeAxe()
        {
            inventory.RemoveItem("камень", 1);
            inventory.RemoveItem("палка", 1);
            inventory.RemoveItem("ткань", 1);
            inventory.AddItem("топор", 1);
        }
        public void MakeCloth()
        {
            inventory.RemoveItem("кокос", 1);
            inventory.RemoveItem("волокно", 1);
            inventory.AddItem("ткань", 1);
        }
        public void MakeTank()
        {
            inventory.RemoveItem("ткань", 7);
            inventory.AddItem("баллон", 1);
        }
        public void MakeGondola()
        {
            inventory.RemoveItem("древесина", 5);
            inventory.AddItem("гондола", 1);
        }
    }
}
