using System;

namespace ZooManager
{
    public class Cat : Animal
    {
        public Cat(string name)
        {
            emoji = "🐱";
            species = "cat";
            this.name = name;
            reactionTime = new Random().Next(1, 6); // reaction time 1 (fast) to 5 (medium)
        }
        
        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a cat. Meow.");
            Flee("raptor");//e.
            Hunt("chick", "mouse");//hz
            
        }

        /* Note that our cat is currently not very clever about its hunting.
         * It will always try to attack "up" and will only seek "down" if there
         * is no mouse above it. This does not affect the cat's effectiveness
         * very much, since the overall logic here is "look around for a mouse and
         * attack the first one you see." This logic might be less sound once the
         * cat also has a predator to avoid, since the cat may not want to run in
         * to a square that sets it up to be attacked!
         */
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

