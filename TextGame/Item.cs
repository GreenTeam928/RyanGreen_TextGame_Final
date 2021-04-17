using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public class InvalidEntry : Exception
    {
        public InvalidEntry()
        {
        }
    }
    public class Item
    {
        public Item(Player p)
        {
            player = p;
        }
        int case1choice, case2choice, case3choice, counter, attack1choice, item1choice, counter2;
        Player player;
        public void errorMsg()
        {
            Console.Clear();
            Console.WriteLine("Invalid Entry, enter the integer of the selection you wish to choose.");
            Console.Write("Press Enter");
            Console.ReadLine();
        }
        public int TV(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("There is a TV hanging on the wall, you turn it on");
                    Console.WriteLine("The local news is broadcasting on an alien attack outside!");
                    Console.WriteLine("What do you want to do?");
                    Console.WriteLine("1  Look for weapons so you can fight aliens");
                    Console.WriteLine("2  Continue watching TV");
                    if (!int.TryParse(Console.ReadLine(), out case1choice)|| case1choice < 1 || case1choice > 2)
                    {
                        errorMsg();
                        TV(choice);
                    }
                        if (case1choice == 1)
                        {
                        Console.Clear();
                        Console.WriteLine("Where to find a weapon...");
                        return 1;
                        }
                        else if (case1choice == 2)
                        {
                        Console.Clear();
                        Console.WriteLine("You turn on a movie, it's good...");
                        Console.WriteLine("Yet, aliens attack while watching...");
                        Console.WriteLine("You Loose!");
                        return 2;
                        }
                    else
                    {
                        throw new InvalidEntry();
                    }
                default:
                    {
                        
                        errorMsg();
                        throw new InvalidEntry();
                    }
            }
        }
        public int Locker(int choice)
        {
            switch (choice)
            {
                case 2:
                    Console.Clear();
                    Console.WriteLine("The locker is at the foot of the bed.");
                    Console.WriteLine("There is a half eaten sandwich on top of it, you move it to see inside.");
                    if (player.playerItems.Count == 0)
                    {
                        Console.WriteLine("In it, you see clothes, and one experimental laser gun you developed last week but have not tested.");
                        Console.WriteLine("What to do?");
                        Console.WriteLine("1 Grab items");
                        Console.WriteLine("2 Finish the half eaten sandwich");
                        if (!int.TryParse(Console.ReadLine(), out case2choice) || case2choice < 1 || case2choice > 2)
                        {
                            errorMsg();
                            Locker(choice);
                        }
                        if (case2choice == 1)
                        {
                            Console.Clear();
                            player.playerItems.Add("Clothes");
                            player.playerItems.Add("Experimental Laser Gun");
                            player.viewItems();
                            Console.WriteLine("These items allow you to leave the room.");
                            Console.WriteLine("What do you want to do next?");
                            counter = 1;
                            return 1;
                        }

                        else if (case2choice == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("The sandwich is still good, but...");
                            Console.WriteLine("Aliens attack while eating...");
                            Console.WriteLine("You Loose!");
                            return 2;
                        }
                        else
                        {
                            throw new InvalidEntry();
                        }
                    }
                    else if (player.playerItems.Count == 2)
                    {
                        Console.WriteLine("Chest is empty.");
                        Console.WriteLine("What do you want to do next?");
                        return 1;
                    }
                    else
                    {
                        throw new InvalidEntry();
                    }
                    
                default:
                    {
                        errorMsg();
                        throw new InvalidEntry();
                    }
            }
        }
        public int Door(int choice)
        {
            switch (choice)
            {
                case 3:
                    Console.Clear();
                    Console.WriteLine("This door leads out of the room.");
                    if (player.playerItems.Count == 0)
                    {
                        Console.WriteLine("However, you need clothes and a weapon before you should leave the room.");
                        Console.WriteLine("Choose wisely");
                        Console.WriteLine("1 Find clothes and a weapon");
                        Console.WriteLine("2 Leave your room");
                        if (!int.TryParse(Console.ReadLine(), out case3choice) || case3choice < 1 || case3choice > 2)
                        {
                            errorMsg();
                            Door(choice);
                        }
                        if (case3choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Hum, where to look to find clothes and a weapon...");
                            return 1;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You do not have the items you need to leave the room.");
                            Console.WriteLine("Go look for the stuff you need to leave the room.");
                            return 1;
                        }
                    }
                    else if (counter == 1)
                    {
                        return 2;
                    }
                    else
                    {
                        throw new InvalidEntry();
                    }
                default:
                    {
                        errorMsg();
                        throw new InvalidEntry();
                    }
            }
        }
        public int Solider(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("There is a dead solider on the street in front of you.");
                    if (counter == 1)
                    {
                        Console.WriteLine("You are considering what to do…");
                        Console.WriteLine("1 Pillage from the dead");
                        Console.WriteLine("2 Continue walking down the street towards the alien");
                        if (!int.TryParse(Console.ReadLine(), out case1choice) || case1choice < 1 || case1choice > 2)
                        {
                            errorMsg();
                            Solider(choice);
                        }
                        if (case1choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You look around and find an armor chest plate.");
                            Console.WriteLine("It fits, you put it on.");
                            player.playerItems.Add("Chest Plate");
                            counter += 1;
                            player.viewItems();
                            return 1;
                        }
                        else if (case1choice == 2)
                        {
                            Console.WriteLine("You are quickly confronted by an alien.");
                            if (counter == 1)
                            {
                                Console.WriteLine("You shoot your laser gun at the alien...");
                                Console.WriteLine("The laser beam hits and stuns the alien for a second…");
                                Console.WriteLine("It shoots back and hits you, killing you instantly.");
                                Console.WriteLine("You Loose!");
                                return 2;
                            }
                            else if (counter == 2)
                            {
                                Console.WriteLine("The laser beam hits and stuns the alien for a second…");
                                Console.WriteLine("It shoots back and hits the chest plate, stunning you for a second");
                                Console.WriteLine("You shoot once again, killing the alien instantly.");
                                counter2 = 1;
                                player.playerItems.Add("Keys to the alien's ship");
                                player.playerItems.Add("Alien Laser Gun");
                                Console.WriteLine("While stepping over its dead body you collect:");
                                Console.WriteLine("Keys to the alien's ship");
                                Console.WriteLine("Alien Laser Gun");
                                Console.WriteLine("These items give you access to the alien's ship.");
                                return 1;
                            }
                            else
                            {
                                throw new InvalidEntry();
                            }
                        }
                        else
                        {
                            throw new InvalidEntry();
                        }
                    }
                    else if (counter == 2)
                    {
                        Console.WriteLine("Nothing more to find here.");
                        player.viewItems();
                        return 1;
                    }
                    else
                    {
                        throw new InvalidEntry();
                    }
                default:

                    {
                        errorMsg();
                        throw new InvalidEntry();
                    }
            }
        }
        public int Alien(int choice)
        {
            switch (choice)
            {
                case 2:
                    Console.Clear();
                    if (player.playerItems.Count == 5)
                    {
                        Console.WriteLine("Alien already defeated, all items retreived, you may now proceed to its ship.");
                        return 1;
                    }
                    else
                    {
                        Console.WriteLine("You are quickly confronted by an alien.");
                        Console.WriteLine("What are you going to do?");
                        Console.WriteLine("1 Attack Alien");
                        Console.WriteLine("2 Run");
                        if (!int.TryParse(Console.ReadLine(), out attack1choice) || attack1choice < 1 || attack1choice > 2)
                        {
                            errorMsg();
                            Alien(choice);
                        }

                        if (attack1choice == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("You prepare yourself for an attack.");
                            player.viewItems();
                            Console.WriteLine("You shoot the alien with your laser gun.");
                            if (counter == 1)
                            {
                                Console.WriteLine("The laser beam hits and stuns the alien for a second…");
                                Console.WriteLine("It shoots back and hits you, killing you instantly.");
                                Console.WriteLine("you loose");
                                return 2;
                            }
                            else if (counter == 2)
                            {
                                Console.WriteLine("The laser beam hits and stuns the alien for a second…");
                                Console.WriteLine("It shoots back and hits the chest plate, stunning you for a second");
                                Console.WriteLine("You shoot once again, killing the alien instantly.");
                                counter2 = 1;
                                player.playerItems.Add("Keys to the alien's ship");
                                player.playerItems.Add("Alien Laser Gun");
                                Console.WriteLine("While stepping over its dead body you collect:");
                                Console.WriteLine("Keys to the alien's ship");
                                Console.WriteLine("Alien Laser Gun");
                                Console.WriteLine("These items give you access to the alien's ship.");
                                return 1;
                            }
                            else
                            {
                                throw new InvalidEntry();
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You quickly realize how slow you are, the alien catches, and then kills you.");
                            Console.WriteLine("You Loose!");
                            return 2;
                        }
                    }
                default:

                    {
                        errorMsg();
                        throw new InvalidEntry();

                    }
            }
        }
        public int AlienShip(int choice)
        {
            switch (choice)
            {
                case 3:
                    Console.Clear();
                    if (player.playerItems.Count == 3)
                    {
                        Console.Clear();
                        Console.WriteLine("An alien jumps in front of you as you approach the ship…");
                        Console.WriteLine("You prepare yourself for an attack.");
                        player.viewItems();
                        Console.WriteLine("You shoot the alien with your laser gun.");
                        if (counter == 1)
                        {
                            Console.WriteLine("The laser beam hits and stuns the alien for a second…");
                            Console.WriteLine("It shoots back and hits you, killing you instantly.");
                            Console.WriteLine("you loose");
                            return 2;
                        }
                        else if (counter == 2)
                        {
                            Console.WriteLine("The laser beam hits and stuns the alien for a second…");
                            Console.WriteLine("It shoots back and hits the chest plate, stunning you for a second");
                            Console.WriteLine("You shoot once again, killing the alien instantly.");
                            player.playerItems.Add("Keys to the alien's ship");
                            player.playerItems.Add("Alien Laser Gun");
                            Console.WriteLine("While stepping over its dead body you collect:");
                            Console.WriteLine("Keys to the alien's ship");
                            Console.WriteLine("Alien Laser Gun");
                            Console.WriteLine("These items give you access to the alien's ship.");
                            Console.WriteLine("Press 'y' to continue on to the ship");
                            Console.WriteLine("Press 'n' for main selection");
                            string select = Console.ReadLine().ToLower();
                            if (select == "y")
                            {
                                counter2 = 1;
                                return 3;
                            }
                            else if (select == "n")
                            {
                                return 1;
                               
                            }
                            else
                            {
                                errorMsg();
                                throw new InvalidEntry();
                            }
                        }
                        else
                        {
                            throw new InvalidEntry();
                        }
                    }
                    else if (player.playerItems.Count == 5)
                    {
                        return 3;
                    }
                    else
                    {
                        throw new InvalidEntry();
                    }
                default:
                    {
                        errorMsg();
                        throw new InvalidEntry();
                    }
            }
        }
        public int BossAlien(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    player.viewItems();
                    Console.WriteLine("What item do you want to use to fight the Big Boss Alien");
                    if (!int.TryParse(Console.ReadLine(), out item1choice) || item1choice < 1 || item1choice > 4)
                    {
                        errorMsg();
                        return 1;
                    }
                    if (item1choice == 1)
                    {
                        Console.WriteLine("you are wearing clothes...");
                        Console.WriteLine("Press Any Key To Choose A Weapon");
                        Console.ReadLine();
                        return 1;
                    }
                    else if (item1choice == 2)
                    {

                        return 3;
                    }
                    else if (item1choice == 3)
                    {
                        Console.WriteLine("you are wearing the armored chest plate...");
                        Console.WriteLine("Press Any Key To Choose A Weapon");
                        Console.ReadLine();
                        //BossAlien(choice);
                        return 1;
                    }
                    else if (item1choice == 4)
                    {
                        return 4;
                    }
                    else
                    {
                        throw new InvalidEntry();
                    }
                default:
                    {
                        errorMsg();
                        throw new InvalidEntry();
                    }
            }
        }
        public int Run(int choice)
        {
            switch (choice)
            {
                case 2:
                    Console.Clear();
                    Console.WriteLine("You realize you are not a alien fighter and run home…");
                    Console.WriteLine("Press Any Key to continue");
                    Console.ReadLine();
                    return 1;
                default:
                    {
                        errorMsg();
                        throw new InvalidEntry();
                    }
            }
        }
        
        }
    }






   







