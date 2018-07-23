using ConsoleBattlefield.Models;

namespace ConsoleBattlefield.GameSetup
{
    public interface IGameConstraintsParser
    {
        GameConstraint ParseContraintsFromGameSetupJson(string filepath);
    }
}
