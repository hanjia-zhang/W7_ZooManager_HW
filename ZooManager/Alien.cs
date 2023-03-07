using System;
namespace ZooManager
{
    public class Alien:Creatures, IPredator
    {
        public Alien(string name)
        {
            emoji = "👽";
            species = "alien";
            this.name = name;
            reactionTime = new Random().Next(1,1);
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            Hunt("chick", "cat");//hz
            Hunt("mouse", "raptor");
            
        }

        public void Hunt(string prey, string prey2) //hz 
        {

            if (Seek(location.x, location.y, Direction.up, prey, setdistance) == 1 || Seek(location.x, location.y, Direction.up, prey2, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.up);
            }
            else if (Seek(location.x, location.y, Direction.down, prey, setdistance) == 1 || Seek(location.x, location.y, Direction.down, prey2, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.down);
            }
            else if (Seek(location.x, location.y, Direction.left, prey, setdistance) == 1 || Seek(location.x, location.y, Direction.left, prey2, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.left);
            }
            else if (Seek(location.x, location.y, Direction.right, prey, setdistance) == 1 || Seek(location.x, location.y, Direction.right, prey2, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.right);
            }
        }

    }
}
