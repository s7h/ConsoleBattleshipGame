using ConsoleBattlefield.GameComponents;
using System;
using System.Linq;

namespace ConsoleBattlefield
{
    public static class Play
    {
        public static bool FireWeapon(this Player thisPlayer, Player otherPlayer)
        {
            if (thisPlayer.Moves.Count > 0 && !thisPlayer.IsVictor)
            {
                var move = thisPlayer.Moves.Pop();
                var avatar = otherPlayer.Battlefield[move.PosX, move.PosY];
                if (string.Equals(avatar, Constants.OCEAN_AVATAR) || string.Equals(avatar, Constants.DEBRIS))
                {
                    Console.WriteLine($"{thisPlayer.Name} : It's a Miss.");
                }
                else
                {
                    otherPlayer.Battlefield[move.PosX, move.PosY] = Constants.DEBRIS;
                    otherPlayer.BattlefieldAnalyzer[avatar] -= 1;
                    Console.WriteLine($"{thisPlayer.Name} : It's a Hit!");
                }
                var gameOn = AnalyzeBattlefield(otherPlayer);

                thisPlayer.IsVictor = gameOn ? false : true;

                return gameOn;
            }
            return false;
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
