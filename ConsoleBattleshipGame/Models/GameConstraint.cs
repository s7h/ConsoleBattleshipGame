using System;

namespace ConsoleBattlefield.Models
{
    [Serializable]
    public class GameConstraint
    {
        public Ship[] Ships { get; set; }
        public string[] MissileCoordinates { get; set; }
        public string PlayerName { get; set; }
    }
}
