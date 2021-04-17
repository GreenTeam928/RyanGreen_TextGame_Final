using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public class Player
    {
        public string name, item;
        public int item1choice;
        public List<string> playerItems = new List<string>();
        public void getName()
        {
            Console.Clear();
            Console.WriteLine("This is Aliens Attack, a text adventure game.");
            Console.WriteLine("Press Enter to play");
            Console.ReadLine();
            Console.Clear();
            Console.WriteLine("What is your name?");
            name = Console.ReadLine();
            Console.WriteLine($"Welcome to the game {name}! Have Fun!");
        }
        public void viewItems()
        {
            Console.WriteLine($"{name}, you have:");
            if (playerItems.Count == 0)
            {
                Console.WriteLine("no items");
            }
            else
            {
                for (int i = 0; i < playerItems.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {playerItems[i]}");
                }
            }
        }

    }
}






