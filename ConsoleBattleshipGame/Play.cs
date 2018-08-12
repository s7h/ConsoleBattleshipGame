using ConsoleBattlefield.GameComponents;
using ConsoleBattlefield.GameSetup;
using ConsoleBattlefield.Models;
using System;
using System.Linq;
using System.Threading;

namespace ConsoleBattlefield
{
    public static class Play
    {
        public static bool FireWeapon(this Player thisPlayer, Player otherPlayer, IConsoleWriter consoleWriter)
        {
            if (!thisPlayer.IsVictor)
            {
                consoleWriter.ClearScreen();

                PrintEnemyBattlefield(otherPlayer, consoleWriter);
                var coordinates = consoleWriter.ReadCoordinates();
                
                var avatar = otherPlayer.Battlefield[coordinates.PosX, coordinates.PosY];
                if (string.Equals(avatar, Constants.OCEAN_AVATAR) 
                    || string.Equals(avatar, Constants.DEBRIS)
                    || string.Equals(avatar, Constants.HIT_ALREADY))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{thisPlayer.Name} : It's a Miss.");
                    Console.ResetColor();
                    otherPlayer.MaskedBattlefield[coordinates.PosX, coordinates.PosY] = Constants.HIT_ALREADY;
                }
                else
                {
                    otherPlayer.Battlefield[coordinates.PosX, coordinates.PosY] = Constants.DEBRIS;
                    otherPlayer.MaskedBattlefield[coordinates.PosX, coordinates.PosY] = Constants.DEBRIS;
                    otherPlayer.BattlefieldAnalyzer[avatar] -= 1;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{thisPlayer.Name} : It's a Hit!");
                    Console.ResetColor();
                }
                var gameOn = AnalyzeBattlefield(otherPlayer);

                thisPlayer.IsVictor = gameOn ? false : true;
                Thread.Sleep(1000);
                return gameOn;
            }
            return false;
        }

        private static void PrintEnemyBattlefield(Player player, IConsoleWriter consoleWriter)
        {
            consoleWriter.PrintLine($"Enemy's Battlefield \n", ConsoleColor.White);

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    consoleWriter.PrintAvatar(player.MaskedBattlefield[i, j]);
                }
                Console.WriteLine("");
            }

            consoleWriter.PrintLine($"{player.Name} turn: Enter Coordinates. \n", ConsoleColor.White);
        }

        private static bool AnalyzeBattlefield(Player otherPlayer)
        {
            if (otherPlayer.BattlefieldAnalyzer.Any(x => x.Value == 0))
            {
                var avatar = otherPlayer.BattlefieldAnalyzer.First(x => x.Value == 0).Key;
                otherPlayer.BattlefieldAnalyzer[avatar] = -1;
                Console.WriteLine($"Great!! {otherPlayer.Name} lost his {GetShipTypeFromAvatar(avatar)}.");
            }
            else if(otherPlayer.BattlefieldAnalyzer.Where(x => x.Value == -1).Count() == 5)
            {
                Console.WriteLine($"Awesome!! {otherPlayer.Name} lost all his ships.");
                return false;
            }

            return true;
        }

        private static string GetShipTypeFromAvatar(string avatar)
        {
            switch (avatar)
            {
                case Constants.BATTLESHIP_AVATAR:
                    return Constants.BATTLESHIP;
                case Constants.CARRIER_AVATAR:
                    return Constants.CARRIER;
                case Constants.CRUISER_AVATAR:
                    return Constants.CRUISER;
                case Constants.DESTROYER_AVATAR:
                    return Constants.DESTROYER;
                case Constants.SUBMARINE_AVATAR:
                    return Constants.SUBMARINE;
            }

            return string.Empty;
        }
    }
}
