using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleBattlefield.Exceptions;

namespace ConsoleBattlefield.ConstraintValidators
{
    public class ConstraintValidator : IConstraintValidator
    {
        private static string[,] battlefield;

        public ConstraintValidator()
        {
            InitializeEmptyBattleField();
        }

        public bool ValidateConstraints(GameConstraint gameConstraints)
        {
            var errorMessages = new List<string>();

            errorMessages.AddRange(ValidateMissiles(gameConstraints.MissileCoordinates));
            errorMessages.AddRange(ValidateShips(gameConstraints.Ships));

            return errorMessages.Any() ? false : true;
        }

        private IEnumerable<string> ValidateShips(Ship[] ships)
        {
            var errorMessages = new List<string>();
            foreach (var ship in ships)
            {
                errorMessages.AddRange(CanPlaceOnTheBattlefield(ship));
            }

            return errorMessages;
        }

        private IEnumerable<string> CanPlaceOnTheBattlefield(Ship ship)
        {
            var errorMessages = new List<string>();
            int shipLength = ship.Size;
            int posX = ship.XCoordinate;
            int posY = ship.YCoordinate;

            try
            {
                while (shipLength > 0)
                {
                    if (string.Equals(battlefield[posX, posY], Constants.OCEAN))
                        battlefield[posX, posY] = ship.Avatar;
                    else
                        IdentifyShipAtCurrentCoordinateAndThrowError(posX, posY, ship.Avatar);

                    if (ship.Alignment == Enum.Alignment.Vertical)
                        posY++;
                    else
                        posX++;

                    shipLength--;
                }
            }
            catch (IndexOutOfRangeException iorEx)
            {
                errorMessages.Add($"Cannot deploy {ship.Type} outside the range of the battlefield. Try different Coordinate or change the alignment.");
            }
            catch(ShipOverlappingException soEx)
            {
                errorMessages.Add(soEx.Message);
            }


            return errorMessages;
        }

        private void IdentifyShipAtCurrentCoordinateAndThrowError(int posX, int posY, string toBePlaceShipAvatar)
        {
            var existingShipAvatar = battlefield[posX, posY];
            var existingShipType = GetShipTypeFromAvatar(existingShipAvatar);
            var toBePlaceShipType = GetShipTypeFromAvatar(toBePlaceShipAvatar);
            throw new ShipOverlappingException(existingShipType, toBePlaceShipType);
        }

        private string GetShipTypeFromAvatar(string avatar)
        {
            switch (avatar)
            {
                case Constants.BATTLESHIP:
                    return "BATTLESHIP";
                case Constants.CARRIER:
                    return "CARRIER";
                case Constants.CRUISER:
                    return "CRUISER";
                case Constants.DESTROYER:
                    return "DESTROYER";
                case Constants.SUBMARINE:
                    return "SUBMARINE";
            }

            return string.Empty;
        }

        private IEnumerable<string> ValidateMissiles(string[] missileCoordinates)
        {
            var errorMessages = new List<string>();

            return errorMessages;
        }

        private void InitializeEmptyBattleField()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    battlefield[i, j] = Constants.OCEAN;
                }
            }
        }
    }
}
