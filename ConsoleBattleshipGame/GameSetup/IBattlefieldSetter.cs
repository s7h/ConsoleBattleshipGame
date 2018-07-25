using ConsoleBattlefield.Models;
using System.Collections.Generic;

namespace ConsoleBattlefield.GameSetup
{
    public interface IBattlefieldSetter
    {
        bool CanPlaceShipsOnTheBattlefield(Ship[] ships, out List<string> errorMessages);
    }
}
