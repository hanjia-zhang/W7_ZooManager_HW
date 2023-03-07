using System;
namespace ZooManager
{
    public class Creatures
    {
        public bool isMove = false;// add boolean to check if the animal moved or nor
        public string emoji;
        public string species;
        public string name;
        public int reactionTime = 5; // default reaction time for animals (1 - 10)
        public int setdistance = 1;// declare a global variable set the detach distance
        public Creatures()
        {
        }

        public Point location;

        public void ReportLocation()
        {
            Console.WriteLine($"I am at {location.x},{location.y}");
        }

        virtual public void Activate()
        {
            Console.WriteLine($"Animal {name} at {location.x},{location.y} activated");
        }

        /*Switch the entire method from Game class to Creatures. Add new parameter "distance" and used instead of bool, now the seek will loop to detect area target*/
        static public int Seek(int x, int y, Direction d, string target, int distance)//f. hz
        {
            for (int i = 0; i < distance; i++)
            {
                switch (d)
                {
                    case Direction.up:
                        y--;
                        break;
                    case Direction.down:
                        y++;
                        break;
                    case Direction.left:
                        x--;
                        break;
                    case Direction.right:
                        x++;
                        break;
                }
                if (y < 0 || x < 0 || y > Game.numCellsY - 1 || x > Game.numCellsX - 1) return 0;
                if (Game.animalZones[y][x].occupant != null)
                {
                    if (Game.animalZones[y][x].occupant.species == target)
                    {
                        int area = i + 1;
                        Console.WriteLine("I found a prey " + area + " away from me!");
                        return i + 1;
                    }
                }
            }
            return 0;
        }
    }
}
