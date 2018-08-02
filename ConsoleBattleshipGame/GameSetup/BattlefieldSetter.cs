using ConsoleBattlefield.Exceptions;
using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBattlefield.GameSetup
{
    public class BattlefieldSetter : IBattlefieldSetter
    {
        public bool CanPlaceShipsOnTheBattlefield(Ship[] ships, out List<string> errorMessages)
        {
            errorMessages = new List<string>();

            var battlefield = InitializeEmptyBattleField();

            foreach (var ship in ships)
            {
                int shipLength = ship.Size;
                int posX = ship.XCoordinate;
                int posY = ship.YCoordinate;

                try
                {
                    while (shipLength > 0)
                    {
                        if (string.Equals(battlefield[posX, posY], Constants.OCEAN_AVATAR))
                            battlefield[posX, posY] = ship.Avatar;
                        else
                            IdentifyShipAtCurrentCoordinateAndThrowError(battlefield, posX, posY, ship.Avatar);

                        if (ship.Alignment == Enum.Alignment.Vertical)
                            posX++;
                        else
                            posY++;

                        shipLength--;
                    }
                }
                catch (IndexOutOfRangeException iorEx)
                {
                    errorMessages.Add($"Cannot deploy {ship.Type} outside the range of the battlefield. Try different Coordinate or change the alignment.");
                }
                catch (ShipOverlappingException soEx)
                {
                    errorMessages.Add(soEx.Message);
                }
            }

            //Only for testing
            //for (int i = 0; i < 10; i++)
            //{
            //    for (int j = 0; j < 10; j++)
            //    {
            //        Console.Write(battlefield[i, j]);
            //    }
            //    Console.WriteLine("");
            //}


            return errorMessages.Any() ? false : true;
        }

        public string[,] PrepareBattlefield(Ship[] ships)
        {
            var battlefield = InitializeEmptyBattleField();

            foreach (var ship in ships)
            {
                int shipLength = ship.Size;
                int posX = ship.XCoordinate;
                int posY = ship.YCoordinate;

                while (shipLength > 0)
                {
                    if (string.Equals(battlefield[posX, posY], Constants.OCEAN_AVATAR))
                        battlefield[posX, posY] = ship.Avatar;
                    else
                        IdentifyShipAtCurrentCoordinateAndThrowError(battlefield, posX, posY, ship.Avatar);

                    if (ship.Alignment == Enum.Alignment.Vertical)
                        posX++;
                    else
                        posY++;

                    shipLength--;
                }
            }

            return battlefield;
        }

        private void IdentifyShipAtCurrentCoordinateAndThrowError(string[,] battlefield, int posX, int posY, string toBePlaceShipAvatar)
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

        private string[,] InitializeEmptyBattleField()
        {
            var battlefield = new string[10, 10];
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    battlefield[i, j] = Constants.OCEAN_AVATAR;
                }
            }

            return battlefield;
        }
    }
}
