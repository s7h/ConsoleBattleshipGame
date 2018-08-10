using System;
using System.Collections.Generic;

namespace ConsoleBattlefield
{
    public class GameStart
    {

        public static void Main(string[] args)
        {
            var battlefield = UnityConfig.RegisterDependencies();

            PrintTitle();

            Console.WriteLine("Enter game setup JSON filepath for player One");
            var playerOneFilepath = Console.ReadLine();

            Console.WriteLine("Enter game setup JSON filepath for player Two");
            var playerTwoFilepath = Console.ReadLine();

            Console.Clear();

            battlefield.SetupAndStartTheGame(new List<string> { playerOneFilepath, playerTwoFilepath});

            Console.WriteLine("Game Over! Press Any Key to Exit.");
            Console.ReadKey();
        }

        private static void PrintTitle()
        {
            Console.WriteLine(AsciiArtsConstants.GAME_TITLE);
            Console.WriteLine(AsciiArtsConstants.SHIP);
        }
    }
}
