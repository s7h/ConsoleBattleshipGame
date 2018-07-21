using ConsoleBattlefield.Models;

namespace ConsoleBattlefield.GameSetup
{
    public interface IParseGameConstraints
    {
        GameConstraint ParseContraintsFromGameSetupJson(string filepath);
    }
}
