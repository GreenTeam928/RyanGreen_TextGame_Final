using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame
{
    public class Game
    {
        public Game(Player name1, Item selection1)
        {
            player = name1;
            selection = selection1;
        }
        public int counter, choice, case1choice, case2choice, case3choice, selcChoice, userChoice, tries, item1choice, output;
        public Item selection;
        public Player player;
        public void greetMsg1()
        {
            Console.Clear();
            Console.WriteLine($"Hello {player.name}!");
            Console.WriteLine("You wake up in a bed, in a room, and see several objects.");
            Console.WriteLine("Move around the room and interact with the different objects.");
            Console.WriteLine("Advance to the next level by leaving the room.");
            mainSelc1();
        }
        public void greetMsg2()
        {
            Console.Clear();
            Console.WriteLine($"{player.name}, congrgts, you found the items you needed to get out of your room...");
            Console.WriteLine($"You are now on the street in your town, and you see several things.");
            Console.WriteLine("Same thing here, interact with the different items and figure out what you need to advance.");
            mainSelc2();
        }
        public void greetMsg3()
        {
            Console.Clear();
            Console.WriteLine($"{player.name}, nice! You survived the alien filled streets and now have access to the alien’s ship.");
            Console.WriteLine($"You try opening the door to the ship, but it is locked...");
            Console.WriteLine("You look through your items...");
            player.viewItems();
            Console.WriteLine("Of course... you use the keys to open the door");
            player.playerItems.Remove("Keys to the alien's ship");
            mainSelc3();
        }
        public void mainSelc1()
        {
            //Console.Clear();
            Console.WriteLine("You See:");
            Console.WriteLine("(1) TV");
            Console.WriteLine("(2) Locker");
            Console.WriteLine("(3) Door");
            makeSelc1();
        }
        public void mainSelc2()
        {
            Console.WriteLine("You See:");
            Console.WriteLine("(1) Dead Solider");
            Console.WriteLine("(2) Alien");
            Console.WriteLine("(3) Alien's Ship");
            makeSelc2();
        }
        public void mainSelc3()
        {
            Console.WriteLine("On the space ship you see the Big Boss Alien!");
            Console.WriteLine("What are you going to do?");
            Console.WriteLine("(1) Attack");
            Console.WriteLine("(2) Run");
            makeSelc3();
        }
        public void makeSelc1()
        {
            Console.WriteLine("Enter the number in front of the item you wish to interact with.");
            if (!int.TryParse(Console.ReadLine(), out choice) || choice > 3 || choice < 1)
            {
                selection.errorMsg();
                mainSelc1();
            }
            else if (choice == 1)
            {
                try
                {
                    output = selection.TV(choice);
                    if (output == 1)
                    {
                        mainSelc1();
                    }
                    else if (output == 2)
                    {
                        gamePromt();
                    }
                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.TV(choice);
                }
            }
            else if (choice == 2)
            {
                try
                {
                    output = selection.Locker(choice);
                    if (output == 1)
                    {
                        mainSelc1();
                    }
                    else if (output == 2)
                    {
                        gamePromt();
                    }
                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.Locker(choice);
                }
            }
            else if (choice == 3)
                try
                {
                    output = selection.Door(choice);
                    if (output == 1)
                    {
                        mainSelc1();
                    }
                    else if (output == 2)
                    {
                        greetMsg2();
                    }
                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.Door(choice);
                }
        }
        public void makeSelc2()
        {
            Console.WriteLine("What are you going to do? ");
            if (!int.TryParse(Console.ReadLine(), out choice) || choice > 3 || choice < 1)
            {
                selection.errorMsg();
                mainSelc2();
            }
            else if (choice == 1)
            {
                try
                {
                    int output = selection.Solider(choice);
                    if (output == 1)
                    {
                        mainSelc2();
                    }
                    else if (output == 2)
                    {
                        gamePromt();
                    }
                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.Solider(choice);
                }
            }
            else if (choice == 2)
            {
                try
                {
                    int output = selection.Alien(choice);
                    if (output == 1)
                    {
                        mainSelc2();
                    }
                    else if (output == 2)
                    {
                        gamePromt();
                    }

                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.Alien(choice);
                }
            }
            else if (choice == 3)
            {
                try
                {
                    int output = selection.AlienShip(choice);
                    if (output == 1)
                    {
                        mainSelc2();
                    }
                    else if (output == 2)
                    {
                        gamePromt();
                    }
                    else if (output == 3)
                    {
                        greetMsg3();
                    }

                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.AlienShip(choice);
                }
            }
        }
        public void makeSelc3()
        {
            if (!int.TryParse(Console.ReadLine(), out choice) || choice > 3 || choice < 1)
            {
                selection.errorMsg();
                mainSelc3();
            }
            else if (choice == 1)
            {
                try
                {
                    output = selection.BossAlien(choice);
                    if (output == 1)
                    {
                        mainSelc3();
                    }
                    else if (output == 2)
                    {
                        gamePromt();
                    }
                    else if (output == 3)
                    {
                        bossBattle1();
                    }
                    else if (output == 4)
                    {
                        bossBattle2();
                    }
                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.BossAlien(choice);
                }
            }
            else if (choice == 2)
            {
                try
                {
                    output = selection.Run(choice);
                    if (output == 1)
                    {
                        greetMsg1();
                    }
                }
                catch (InvalidEntry)
                {
                    selection.errorMsg();
                    selection.Run(choice);
                }
            }
        }
        public void bossBattle1()
        {
            System.Random random = new System.Random();
            int bossNum = random.Next(200);
            int playerNum = random.Next(100);
            int playerHit, bossHit;
            playerHit = 0;
            bossHit = 0;
            Console.WriteLine("You prepare for battle using the experimental laser gun.");
            while (playerHit < 3 && bossHit < 3)
            {

                if (bossNum > playerNum)
                {
                    Console.WriteLine($"Big Boss Alien shoots a laser gun and hits {player.name}...");
                    playerHit += 1;
                    if (playerHit == 1)
                    {
                        Console.WriteLine("Two more hits and you are dead.");
                    }
                    else if (playerHit == 2)
                    {
                        Console.WriteLine("Watch Out!");
                    }
                    else if (playerHit == 3)
                    {
                        Console.WriteLine($"Big Boss Alien kills {player.name}");
                        Console.WriteLine("You Loose");
                        gamePromt();
                    }
                else if (playerNum > bossNum)
                {
                    Console.WriteLine($"{player.name} shoots the alien with the experimental laser gun, hitting it...");
                    bossHit += 1;
                        if (bossHit == 1)
                        {
                            Console.WriteLine("Shoot and hit the alien two more times...");
                        }
                        else if (bossHit == 3)
                        {
                            Console.WriteLine($"{player.name} kills the Big Boss Alien");
                            Console.WriteLine("You Win");
                            gamePromt();
                        }
                    }
                }
            }
            {
                throw new InvalidEntry();
            }
        }
        public void bossBattle2()
        {
            System.Random random = new System.Random();
            int bossNum = random.Next(100);
            int playerNum = random.Next(400);
            int playerHit, bossHit;
            playerHit = 0;
            bossHit = 0;
            Console.WriteLine("You prepare for battle using the Alien's Laser Gun.");
            while (playerHit < 3 && bossHit < 3)
            {
                if (bossNum > playerNum)
                {
                    Console.WriteLine($"Big Boss Alien shoots their laser gun and hits {player.name}...");
                    playerHit += 1;
                    if (playerHit == 1)
                    {
                        Console.WriteLine("Two more hits and you are dead.");
                    }
                    else if (playerHit == 2)
                    {
                        Console.WriteLine("Watch Out!");
                    }

                    else if (playerHit == 3)
                    {
                        Console.WriteLine($"Big Boss Alien kills {player.name}");
                        Console.WriteLine("You Loose");
                        gamePromt();
                    }
                }
                else if (playerNum > bossNum)
                {
                    Console.WriteLine($"{player.name} shoots the alien with the Alien Laser Gun and hits it...");
                    bossHit += 1;
                    if (bossHit == 1)
                    {
                        Console.WriteLine($"{player.name} shoots at the alien again but misses it.");
                    }
                    else if (bossHit == 2)
                    {
                        Console.WriteLine("You only need to hit it one more time.");
                    }
                    else if (bossHit == 3)
                    {
                        Console.WriteLine($"{player.name} kills the Big Big Boss Alien");
                        Console.WriteLine("You Win");
                        gamePromt();
                    }
                }
            }
        }
        public void gamePromt()
        { 
            Console.WriteLine("(1)Play Again \r\n" + "(2)Exit");
            if (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice > 2)
            {
                selection.errorMsg();
                gamePromt();
            }
            else if (userChoice == 1)
            {
                Player player = new Player();
                Item selection = new Item(player);
                Game game = new Game(player, selection);
                player.getName();
                game.greetMsg1();
            }
            else if (userChoice == 2)
            {
                System.Environment.Exit(0);
            }
        }
    }
}

    





