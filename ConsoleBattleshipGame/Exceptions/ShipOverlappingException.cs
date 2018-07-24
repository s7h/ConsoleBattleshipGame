using System;

namespace ConsoleBattlefield.Exceptions
{
    [Serializable]
    public class ShipOverlappingException : Exception
    {
        public ShipOverlappingException()
        {

        }

        public ShipOverlappingException(string existingShip, string toBePlacedShip)
        : base($"{toBePlacedShip} cannot overlap {existingShip}. Try Changin coordinates or alignment.")
        {

        }
    }
}
