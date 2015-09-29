using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem
{
    class Program
    {
        private const int countOfDoors = 3;

        private static Random rnd = new Random();

        static void Main()
        {
            int hitDoorsWhenKept = 0;
            int hitDoorsWhenSwap = 0;

            for (int i = 0; i < 1000000; i++)
            {
                if (KeepDoor())
                {
                    hitDoorsWhenKept++;
                }
            }

            for (int i = 0; i < 1000000; i++)
            {
                if (SwapDoor())
                {
                    hitDoorsWhenSwap++;
                }
            }

            Console.WriteLine("Hits when player keeps door {0} out of 1 000 000", hitDoorsWhenKept);
            Console.WriteLine("Hits when player swaps doors {0} out of 1 000 000", hitDoorsWhenSwap);

            Console.ReadLine();
        }

        private static bool SwapDoor()
        {
            bool[] doors = GenerateDoors();
            int playersDoor = rnd.Next(countOfDoors);
            int openDoor = OpenDoor(doors, playersDoor);

            for (int i = 0; i < countOfDoors; i++)
			{
			    if (i != openDoor && i != playersDoor)
                {
                    return doors[i];
                }
			}

            throw new InvalidOperationException();
        }

        private static bool KeepDoor()
        {
            bool[] doors = GenerateDoors();
            int playersDoor = rnd.Next(countOfDoors);
            int openDoor = OpenDoor(doors, playersDoor);
            return doors[playersDoor];
        }

        private static bool[] GenerateDoors()
        {
            bool[] doors = new bool[countOfDoors];
            int pricePosition = rnd.Next(countOfDoors);
            doors[pricePosition] = true;

            return doors;
        }

        private static int OpenDoor(bool[] doors, int playersDoor) 
        {
            int openDoor = rnd.Next(countOfDoors - 1);
            if (openDoor >= playersDoor)
            {
                openDoor++;
            }
                        
            if (!doors[openDoor])
            {
                return openDoor;
            }

            for (int i = 0; i < countOfDoors; i++)
			{
			    if (i != openDoor && i != playersDoor)
                {
                    return i;
                }
			}

            throw new InvalidOperationException();
        }
    }
}
