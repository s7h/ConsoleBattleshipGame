using System;
using System.Collections.Generic;

namespace ConsoleBattlefield
{
    public class GameStart
    {
        public static void Main(string[] args)
        {
            var battlefield = UnityConfig.RegisterDependencies();

            Console.WriteLine("CONSOLE BATTLESHIP");
            Console.WriteLine("Enter game setup JSON file for player One");
            var playerOneFilepath = Console.ReadLine();

            Console.WriteLine("Enter game setup JSON file for player Two");
            var playerTwoFilepath = Console.ReadLine();

            Console.Clear();

            battlefield.SetupAndStartTheGame(new List<string> { playerOneFilepath, playerTwoFilepath});

            Console.WriteLine("Game Over! Press Any Key to Exit.");
            Console.ReadKey();
        }
    }
}
