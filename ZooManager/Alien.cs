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
            Hunt("chick");//hz
            Hunt("cat");
            Hunt("mouse");
            Hunt("raptor");
        }

        public void Hunt(string prey)
        {
            if (Seek(location.x, location.y, Direction.up, prey, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.up);
            }
            else if (Seek(location.x, location.y, Direction.down, prey, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.down);
            }
            else if (Seek(location.x, location.y, Direction.left, prey, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.left);
            }
            else if (Seek(location.x, location.y, Direction.right, prey, setdistance) == 1)//f.
            {
                Game.Attack(this, Direction.right);
            }
        }

    }
}
