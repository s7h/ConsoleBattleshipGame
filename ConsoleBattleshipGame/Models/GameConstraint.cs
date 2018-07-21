using System;

namespace ConsoleBattlefield.Models
{
    [Serializable]
    public class GameConstraint
    {
        public BattleshipTypes BattleshipTypes { get; set; }
        public MissileCoordinates MissileCoordinates { get; set; }
        public int NumberOfMissiles { get; set; }
    }
}
