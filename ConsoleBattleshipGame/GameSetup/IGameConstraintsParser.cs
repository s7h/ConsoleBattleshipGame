using ConsoleBattlefield.Models;
using System.Collections.Generic;

namespace ConsoleBattlefield.GameSetup
{
    public interface IGameConstraintsParser
    {
        IEnumerable<GameConstraint> ParseContraintsFromGameSetupJson(IEnumerable<string> filepath);
    }
}
