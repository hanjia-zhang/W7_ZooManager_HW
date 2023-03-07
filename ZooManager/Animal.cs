using System;
using System.Collections.Generic;//hz
namespace ZooManager
{
    public class Animal:Creatures, IPredator, Iprey
    {

        //public int movedistance = 1;//hz


        /*Change the Hunt class to the Animal which only needs to be called from this class if want to add new animals, 
         * instead to writhe a new once. Also pass a string parameter "prey" which identifies the specific animal
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


        /*Change the Flee class to the Animal which only needs to be called from this class if want to add new animals, 
         * instead to writhe a new once. Also pass a string parameter "predator" which identifies the specific animal
         */
        public virtual void Flee(string predator) //hz
        {

            if (Seek(location.x, location.y, Direction.up, predator, setdistance) == 1)//f.
            {
                //this.Move(predator);
                if (Game.Retreat(this, Direction.down)) return;
            }
            if (Seek(location.x, location.y, Direction.down, predator, setdistance) == 1)//f.
            {
                //this.Move(predator);
                if (Game.Retreat(this, Direction.up)) return;
            }
            if (Seek(location.x, location.y, Direction.left, predator, setdistance) == 1)//f.
            {
                //this.Move(predator);
                if (Game.Retreat(this, Direction.right)) return;
            }
            if (Seek(location.x, location.y, Direction.right, predator, setdistance) == 1)//f.
            {
                //this.Move(predator);
                if (Game.Retreat(this, Direction.left)) return;
            }
        }

        public int Move(int escapdistance, Direction d)//hz
        {
            int movedistance = 0;
            for (int i = 0; i < escapdistance; i++)
            {
                switch (d)
                {
                    case Direction.up:
                        if ((location.y - 1 >= 0) && (Game.animalZones[location.y - 1][location.x].occupant == null))
                        {
                            Game.animalZones[location.y][location.x].occupant = null;
                            Game.animalZones[this.location.y - 1][this.location.x].occupant = this;
                            movedistance++;
                        }
                        break;

                    case Direction.down:
                        if ((location.y + 1 <= Game.numCellsY - 1) && (Game.animalZones[location.y + 1][location.x].occupant == null))
                        {
                            Game.animalZones[location.y][location.x].occupant = null;
                            Game.animalZones[this.location.y + 1][this.location.x].occupant = this;
                            movedistance++;
                        }
                        break;

                    case Direction.left:
                        if ((location.x - 1 >= 0) && (Game.animalZones[location.y][location.x - 1].occupant == null))
                        {
                            Game.animalZones[location.y][location.x].occupant = null;
                            Game.animalZones[this.location.y][this.location.x - 1].occupant = this;
                            movedistance++;
                        }
                        break;

                    case Direction.right:
                        if ((location.x + 1 <= Game.numCellsX - 1) && (Game.animalZones[location.y][location.x + 1].occupant == null))
                        {
                            Game.animalZones[location.y][location.x].occupant = null;
                            Game.animalZones[this.location.y][this.location.x + 1].occupant = this;
                            movedistance++;
                        }
                        break;
                }

            }

            return movedistance;
        }


        //Uncompleted Move function
        //public int Move(string predator)
        //{
        //    int leftX = this.location.x - 1;
        //    int rightX = this.location.x + 1;
        //    int upY = this.location.y - 1;
        //    int downY = this.location.y + 1;
        //    int distance = 0;

        //    Direction unSafe = Direction.up;
        //    if (upY >= 0 && Game.animalZones[upY][location.x].occupant != null && Game.animalZones[upY][location.x].occupant.species == predator)
        //    {
        //        unSafe = Direction.up;
        //    }

        //    if (downY < Game.numCellsY && Game.animalZones[downY][location.x].occupant != null && Game.animalZones[downY][location.x].occupant.species == predator)
        //    {
        //        unSafe = Direction.down;
        //    }

        //    if (leftX >= 0 && Game.animalZones[location.y][leftX].occupant != null && Game.animalZones[location.y][leftX].occupant.species == predator)
        //    {
        //        unSafe = Direction.left;
        //    }

        //    if (rightX < Game.numCellsX && Game.animalZones[location.y][rightX].occupant != null && Game.animalZones[location.y][rightX].occupant.species == predator)
        //    {
        //        unSafe = Direction.right;
        //    }

        //    int[] destination = new int[] { location.y, location.x };//Store a signle destination square's location

        //    List<List<int[]>> listDestination = new List<List<int[]>>(); //Store all avalibale destination square's loction
        //    Queue<int[]> queue = new Queue<int[]>();
        //    queue.Enqueue(destination);//
        //    HashSet<int[]> visited = new HashSet<int[]>();
        //    visited.Add(destination);

        //    for (int i = 0; i <= this.movedistance; i++)
        //    {
        //        List<int[]> recordSteps = new List<int[]>();
        //        Queue<int[]> curQueue = new Queue<int[]>();

        //        while (queue.Count != 0)
        //        {
        //            int[] currentLocation = queue.Dequeue();
        //            recordSteps.Add(currentLocation);
        //            if (currentLocation[0] - 1 >= 0 && unSafe != Direction.up && Game.animalZones[currentLocation[0] - 1][currentLocation[1]].occupant == null && visited.Add(new int[] { currentLocation[0] - 1, currentLocation[1] }))
        //            {
        //                curQueue.Enqueue(new int[] { currentLocation[0] - 1, currentLocation[1] });
        //            }

        //            if (currentLocation[0] + 1 < Game.numCellsY && unSafe != Direction.down && Game.animalZones[currentLocation[0] + 1][currentLocation[1]].occupant == null && visited.Add(new int[] { currentLocation[0] + 1, currentLocation[1] }))
        //            {
        //                curQueue.Enqueue(new int[] { currentLocation[0] + 1, currentLocation[1] });
        //            }

        //            if (currentLocation[1] - 1 >= 0 && unSafe != Direction.left && Game.animalZones[currentLocation[0]][currentLocation[1] - 1].occupant == null && visited.Add(new int[] { currentLocation[0], currentLocation[1] - 1 }))
        //            {
        //                curQueue.Enqueue(new int[] { currentLocation[0], currentLocation[1] - 1 });
        //            }

        //            if (currentLocation[1] + 1 < Game.numCellsX && unSafe != Direction.right && Game.animalZones[currentLocation[0]][currentLocation[1] + 1].occupant == null && visited.Add(new int[] { currentLocation[0], currentLocation[1] + 1 }))
        //            {
        //                curQueue.Enqueue(new int[] { currentLocation[0], currentLocation[1] + 1 });
        //            }

        //        }
        //        queue = curQueue;
        //        listDestination.Add(recordSteps);
        //    }
        //    foreach (List<int[]> locationList in listDestination)
        //    {
        //        if (locationList.Count != 0)
        //        {
        //            distance++;
        //            Random random = new Random();
        //            int randomIndex = random.Next(locationList.Count);
        //            destination = locationList[randomIndex];
        //        }
        //    }
        //    Game.animalZones[location.y][location.x].occupant = null;
        //    Game.animalZones[destination[0]][destination[1]].occupant = this;
        //    return distance;
        /////////////////////////////

        

    }
}