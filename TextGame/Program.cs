using System;
using System.Collections.Generic;
using System.Text;
namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            Item selection = new Item(player);
            Game game = new Game(player, selection);
            player.getName();
            game.greetMsg1();
          }
    }
}
