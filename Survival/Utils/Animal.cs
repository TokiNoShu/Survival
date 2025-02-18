namespace AnimalsClass
{
    public class Animal
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Health { get; set; } = 10;

        public Animal(int positionX, int positionY)
        {
            PositionX = positionX;
            PositionY = positionY;
        }
    }
}