using System;
namespace ZooManager
{
    public class Chick:Bird //c. hz
    {
        public Chick(string name)
        {
            emoji = "🐥";
            species = "chick";
            this.name = name;
            reactionTime = new Random().Next(6, 10);
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I'm a chick, Cuckoo.");
            Flee("cat");
        }
    }
}
