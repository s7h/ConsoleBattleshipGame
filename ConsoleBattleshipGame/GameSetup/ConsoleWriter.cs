using ConsoleBattlefield.ConstraintValidators;
using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBattlefield.GameSetup
{
    public class ConsoleWriter : IConsoleWriter
    {
        private readonly IConstraintValidator constraintValidator;

        public ConsoleWriter(IConstraintValidator constraintValidator)
        {
            this.constraintValidator = constraintValidator;
        }
        public MissileCoordinates ReadCoordinates()
        {
            PrintLine($"Enter Coordinates", ConsoleColor.White);
            var move = Console.ReadLine();
            List<string> errors = constraintValidator.ValidateMissile(move).ToList();

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    PrintLine(error, ConsoleColor.White);
                }
                ReadCoordinates();
            }
            else
            {
                var positionXY = move.ToCharArray();

                return new MissileCoordinates
                {
                    PosX = Int32.Parse(positionXY[0].ToString()),
                    PosY = Int32.Parse(positionXY[1].ToString())
                };
            }
            return null;
        }
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

        public void ClearScreen()
        {
            Console.Clear();
        }
    }
}
