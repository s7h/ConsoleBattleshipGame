
namespace ConsoleBattlefield.Models.BattleshipType
{
    public class Carrier
    {
        public ShipCoordinates ShipCoordinates { get; set; }
        public Alignment Alignment { get; set; }
        public int Size { get; } = 5;
        
    }
}
