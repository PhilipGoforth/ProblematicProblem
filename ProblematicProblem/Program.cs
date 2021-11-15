using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
              
        static bool cont = true;
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        public static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            var input = Console.ReadLine();
            if(input.ToLower() == "yes")
            {
                cont = true;
            }
            else
            {
                cont = false;
            }


            Console.WriteLine();

            Console.Write("We are going to need your information first! What is your name? ");
            string userName = Console.ReadLine();

            Console.WriteLine();

            Console.Write("What is your age? ");
            int userAge = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            bool seeList = true;
            Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
            input = Console.ReadLine();
            if (input.ToLower() == "sure")
            {
                seeList = true;
            }
            else
            {
                seeList = false;
            }

            if (seeList)
            {
                foreach (string activity in activities)
                {
                    Console.Write($"{activity} ");
                    Thread.Sleep(250);
                }

                Console.WriteLine();
                Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                input = Console.ReadLine();
                bool addToList = true;
                if (input.ToLower() == "yes")
                {
                    addToList = true;
                }
                else
                {
                    addToList = false;
                }
                Console.WriteLine();

                while (addToList)
                {
                    Console.Write("What would you like to add? ");
                    string userAddition = Console.ReadLine();

                    activities.Add(userAddition);

                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity} ");
                        Thread.Sleep(250);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Would you like to add more? yes/no: ");
                    input = Console.ReadLine();
                    if (input.ToLower() == "yes")
                    {
                        addToList = true;
                    }
                    else
                    {
                        addToList = false;
                    }
                    Console.WriteLine();
                }
            }
            
            while (cont)
            {
                Console.Write("Connecting to the database");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                Console.Write("Choosing your random activity");

                for (int i = 0; i < 9; i++)
                {
                    Console.Write(". ");
                    Thread.Sleep(500);
                }

                Console.WriteLine();

                int randomNumber = rnd.Next(activities.Count());

                string randomActivity = activities[randomNumber];

                if (userAge > 21 && randomActivity == "Wine Tasting")
                {
                    Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                    Console.WriteLine("Pick something else!");

                    activities.Remove(randomActivity);

                    randomNumber = rnd.Next(activities.Count());

                    randomActivity = activities[randomNumber];
                }

                Console.Write($"Ah got it! {randomActivity}, your random activity is: {userName}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                Console.WriteLine();
                input = Console.ReadLine();
                if (input.ToLower() == "keep")
                {
                    cont = false;
                }
                else
                {
                    cont = true;
                }
            }
        }
    }
}
