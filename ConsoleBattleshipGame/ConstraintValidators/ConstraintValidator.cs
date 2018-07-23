using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBattlefield.Models.BattleshipType;
using ConsoleBattlefield.Enum;

namespace ConsoleBattlefield.ConstraintValidators
{
    public class ConstraintValidator : IConstraintValidator
    {
        public bool ValidateConstraints(GameConstraint gameConstraints)
        {
            var validationResult = new List<string>();
            if (gameConstraints != null)
            {
                validationResult.AddRange(ValidateAllShips(gameConstraints.BattleshipTypes));
                validationResult.AddRange(ValidateMissileCount(gameConstraints.NumberOfMissiles, gameConstraints.MissileCoordinates));
            }

            return (validationResult.Count == 0) ? true : false;       
        }

        private IList<string> ValidateMissileCount(int numberOfMissiles, MissileCoordinates missileCoordinates)
        {
            var errorMessages = new List<string>();
            if (numberOfMissiles == 0)
            {
                errorMessages.Add("Missile count is zero.");
            }
            else
            {
                if (missileCoordinates.playerOne.Count() != numberOfMissiles)
                {
                    errorMessages.Add("Player 1: Number of missiles and number of missile coordinates are not equal.");
                }

                if (missileCoordinates.playerTwo.Count() != numberOfMissiles)
                {
                    errorMessages.Add("Player 2: Number of missiles and number of missile coordinates are not equal.");
                }
            }

            return errorMessages;
        }

        private IList<string> ValidateAllShips(BattleshipTypes battleships)
        {
            var errorMessages = new List<string>();
            if (battleships == null)
            {
                errorMessages.Add("No battleships are present.");
            }
            else
            {
                errorMessages.AddRange(ValidateBattleship(battleships.Battleship));
                errorMessages.AddRange(ValidateCarrier(battleships.Carrier));
                errorMessages.AddRange(ValidateCruiser(battleships.Cruiser));
                errorMessages.AddRange(ValidateDestroyer(battleships.Destroyer));
                errorMessages.AddRange(ValidateSubmarine(battleships.Submarine));
            }

            return errorMessages;
        }

        private IEnumerable<string> ValidateSubmarine(Submarine submarine)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> ValidateDestroyer(Destroyer destroyer)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> ValidateCruiser(Cruiser cruiser)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> ValidateCarrier(Carrier carrier)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<string> ValidateBattleship(Battleship battleship)
        {
            throw new NotImplementedException();
        }

        private bool CanPlaceShipOnTheCoordinate(AlignmentEnum align)
        {
            return false;
        }
    }
}
