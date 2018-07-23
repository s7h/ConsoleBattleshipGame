using ConsoleBattlefield.Models;
using Newtonsoft.Json;

namespace ConsoleBattlefield.GameSetup
{
    public class GameConstraintsParser : IGameConstraintsParser
    {
        private readonly IConstraintReader constraintReader;

        public GameConstraintsParser(IConstraintReader constraintReader)
        {
            this.constraintReader = constraintReader;
        }

        public GameConstraint ParseContraintsFromGameSetupJson(string filepath)
        {
            var jsonString = constraintReader.ReadConstraintsFromJSON(filepath);
            var constraints = JsonConvert.DeserializeObject<GameConstraint>(jsonString);

            return constraints;
        }
    }
}
