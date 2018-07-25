
namespace ConsoleBattlefield.Models
{
    public class Ship
    {
        public Enum.BattleshipType Type { get; set; }
        public int Size { get { return GetSizeOfShip(); } }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Enum.Alignment Alignment { get; set; }
        public string Avatar { get { return GetAvatar(); } }

        private string GetAvatar()
        {
            switch (Type)
            {
                case Enum.BattleshipType.Battleship:
                    return Constants.BATTLESHIP_AVATAR;
                case Enum.BattleshipType.Carrier:
                    return Constants.CARRIER_AVATAR;
                case Enum.BattleshipType.Cruiser:
                    return Constants.CRUISER_AVATAR;
                case Enum.BattleshipType.Destroyer:
                    return Constants.DESTROYER_AVATAR;
                case Enum.BattleshipType.Submarine:
                    return Constants.SUBMARINE_AVATAR;
            }

            return string.Empty;
        }

        private int GetSizeOfShip()
        {
            if (Type == Enum.BattleshipType.Carrier)
                return 5;
            else if (Type == Enum.BattleshipType.Battleship)
                return 4;
            else if (Type == Enum.BattleshipType.Cruiser || Type == Enum.BattleshipType.Submarine)
                return 3;
            else
                return 2;
        }

    }
}
