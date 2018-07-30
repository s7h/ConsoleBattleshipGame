using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBattlefield.GameSetup;

namespace ConsoleBattlefield.ConstraintValidators
{
    public class ConstraintValidator : IConstraintValidator
    {
        private readonly IBattlefieldSetter battlefieldSetter;

        public ConstraintValidator(IBattlefieldSetter battlefieldSetter)
        {
            this.battlefieldSetter = battlefieldSetter;
        }

        public  IEnumerable<string> ValidateConstraints(GameConstraint gameConstraints)
        {
            var errorMessages = new List<string>();

            errorMessages.AddRange(ValidateMissiles(gameConstraints.MissileCoordinates.Split(',')));
            errorMessages.AddRange(ValidateShips(gameConstraints.Ships));

            return errorMessages;
        }

        private void WriteErrorMessagesToConsole(List<string> errorMessages)
        {
            var counter = 1;
            foreach (var message in errorMessages)
            {
                Console.WriteLine($"{counter}. {message}");
                counter++;
            }
        }

        private IEnumerable<string> ValidateShips(Ship[] ships)
        {
            var errorMessages = new List<string>();

            battlefieldSetter.CanPlaceShipsOnTheBattlefield(ships, out errorMessages);

            return errorMessages;
        }

        private IEnumerable<string> ValidateMissiles(string[] missileCoordinates)
        {
            var errorMessages = new List<string>();

            if (missileCoordinates.Count() != 20)
            {
                errorMessages.Add("Count of missile coordinates should be 20.");
                return errorMessages;
            }

            foreach (var coordinate in missileCoordinates)
            {
                int coordinateInDigits;
                if (coordinate.Length != 2)
                {
                    errorMessages.Add($"{coordinate} : is not a correct coordinate. Use coordinates ranging from 00 to 99.");
                }
                if (!Int32.TryParse(coordinate, out coordinateInDigits))
                {
                    errorMessages.Add($"{coordinate} : is not a correct coordinate. Use numeric digits ranging from 0 to 9 only.");
                }
                if (coordinateInDigits < 0 || coordinateInDigits > 99)
                {
                    errorMessages.Add($"{coordinate} : is not a correct coordinate. Use coordinates ranging from 00 to 99.");
                }
            }

            return errorMessages;
        }
    }
}
