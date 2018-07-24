using System.ComponentModel;

namespace ConsoleBattlefield.Enum
{
    public enum BattleshipType
    {
        [Description("No Ship")]
        Default = 0,
        [Description("Carrier")]
        Carrier = 1,
        [Description("Cruiser")]
        Cruiser = 2,
        [Description("Submarine")]
        Submarine = 3,
        [Description("Battleship")]
        Battleship = 4,
        [Description("Destroyer")]
        Destroyer = 5
    }
}
