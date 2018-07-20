using System;

namespace ConsoleBattlefield
{
    public class GameStart
    {
        public static void Main(string[] args)
        {
            var battlefield = UnityConfig.RegisterDependencies();

            //battlefield.RunBattlefield();

            Console.WriteLine("Game Over! Press Any Key to Exit.");
            Console.ReadKey();
        }
    }
}
