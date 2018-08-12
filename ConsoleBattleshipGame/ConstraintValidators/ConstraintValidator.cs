using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
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

        public  IEnumerable<string> ValidateShipConstraints(GameConstraint gameConstraints)
        {
            var errorMessages = new List<string>();
            errorMessages.AddRange(ValidateShips(gameConstraints.Ships));

            return errorMessages;
        }

        private IEnumerable<string> ValidateShips(Ship[] ships)
        {
            var errorMessages = new List<string>();

            battlefieldSetter.CanPlaceShipsOnTheBattlefield(ships, out errorMessages);

            return errorMessages;
        }

        public IEnumerable<string> ValidateMissile(string coordinates)
        {
            var errorMessages = new List<string>();
            
            int coordinateInDigits;
            if (coordinates.Length != 2)
            {
                errorMessages.Add($"{coordinates} : Length of coordinate should be 2. Use coordinates ranging from 00 to 99.");
            }
            if (!Int32.TryParse(coordinates, out coordinateInDigits))
            {
                errorMessages.Add($"{coordinates} : is not a correct coordinate. Use numeric digits ranging from 0 to 9 only.");
            }
            if (coordinateInDigits < 0 || coordinateInDigits > 99)
            {
                errorMessages.Add($"{coordinates} : is not a correct coordinate. Use coordinates ranging from 00 to 99.");
            }

            return errorMessages;
        }
    }
}
