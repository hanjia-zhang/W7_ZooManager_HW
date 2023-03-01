using System;
namespace ZooManager
{
    public class Mouse : Animal
    {
        public Mouse(string name)
        {
            //movedistance = 2;//hz

            emoji = "🐭";
            species = "mouse";
            this.name = name; // "this" to clarify instance vs. method parameter
            reactionTime = new Random().Next(1, 4); // reaction time of 1 (fast) to 3
            /* Note that Mouse reactionTime range is smaller than Cat reactionTime,
             * so mice are more likely to react to their surroundings faster than cats!
             */
        }

        public override void Activate()
        {
            base.Activate();
            Console.WriteLine("I am a mouse. Squeak.");
            Flee("cat");//hz
        }

        int moveSteps = 2;//hz Set up the maxsimum move steps for mouse

        public override void Flee(string predator)//hz Rewrite Flee for mouse
        {
            int randomIndex = new Random().Next(0, 4); //random direction by using index of enum
            Direction rd = Direction.up;

            if (Seek(location.x, location.y, Direction.up, predator, setdistance) == 1 && location.y > 0)//f.
            {
                if (randomIndex == 2) // if random index equal 2 (up), then change the direction
                {
                    randomIndex--; 
                }

                rd = (Direction)Enum.GetValues(typeof(Direction)).GetValue(randomIndex);
                Move(moveSteps, rd);
                return;
            }
            if (Seek(location.x, location.y, Direction.down, predator, setdistance) == 1 && location.y < Game.numCellsY - 1)//f.
            {
                if (randomIndex == 3)
                {
                    randomIndex--;
                }

                rd = (Direction)Enum.GetValues(typeof(Direction)).GetValue(randomIndex);
                Move(moveSteps, rd);
                return;
            }
            if (Seek(location.x, location.y, Direction.left, predator, setdistance) == 1 && location.x > 0)//f.
            {
                if (randomIndex == 0)
                {
                    randomIndex = 3;
                }

                rd = (Direction)Enum.GetValues(typeof(Direction)).GetValue(randomIndex);
                Move(moveSteps, rd);
                return;
            }
            if (Seek(location.x, location.y, Direction.right, predator, setdistance) == 1 && location.x < Game.numCellsX - 1)//f.
            {
                if (randomIndex == 1)
                {
                    randomIndex--;
                }

                rd = (Direction)Enum.GetValues(typeof(Direction)).GetValue(randomIndex);
                Move(moveSteps, rd);
                return;
            }
        }

        /* Note that our mouse is (so far) a teeny bit more strategic than our cat.
         * The mouse looks for cats and tries to run in the opposite direction to
         * an empty spot, but if it finds that it can't go that way, it looks around
         * some more. However, the mouse currently still has a major weakness! He
         * will ONLY run in the OPPOSITE direction from a cat! The mouse won't (yet)
         * consider running to the side to escape! However, we have laid out a better
         * foundation here for intelligence, since we actually check whether our escape
         * was succcesful -- unlike our cats, who just assume they'll get their prey!
         */

    }
}

