using System;

namespace ConsoleBattlefield.GameSetup
{
    public class ConsoleWriter : IConsoleWriter

    {
        public void PrintLine(string text, ConsoleColor foregroundColor, ConsoleColor backgroundColor = ConsoleColor.Black)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void PrintAvatar(string avatar)
        {
            switch (avatar)
            {
                case Constants.OCEAN_AVATAR:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case Constants.DEBRIS:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case Constants.BATTLESHIP_AVATAR:
                case Constants.CARRIER_AVATAR:
                case Constants.CRUISER_AVATAR:
                case Constants.DESTROYER_AVATAR:
                case Constants.SUBMARINE_AVATAR:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.Write(avatar);
            Console.ResetColor();
        }


    }
}
