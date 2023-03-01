using System;
namespace ZooManager
{
    public class Raptor:Bird //a,b. hz 
    {
        public Raptor(string name)
        {
            emoji = "🦅";
            species = "raptor";
            this.name = name;
            reactionTime = 1;
        }

        public override void Activate()// rewrite the console, also specify the prey
        {
            base.Activate();
            Console.WriteLine("I'm a raptor, twitter");
            Hunt("cat");
            Hunt("mouse");//d
        }
    }
}
