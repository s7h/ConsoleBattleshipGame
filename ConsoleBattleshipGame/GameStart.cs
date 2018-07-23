using System;

namespace ConsoleBattlefield
{
    public class GameStart
    {
        public static void Main(string[] args)
        {
            var battlefield = UnityConfig.RegisterDependencies();

            Console.WriteLine("Enter path for input JSON");
            var filepath = Console.ReadLine();

            battlefield.SetupAndStartTheGame(filepath);

            Console.WriteLine("Game Over! Press Any Key to Exit.");
            Console.ReadKey();
        }
    }
}
