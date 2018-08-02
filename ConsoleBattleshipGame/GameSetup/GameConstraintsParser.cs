using ConsoleBattlefield.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ConsoleBattlefield.GameSetup
{
    public class GameConstraintsParser : IGameConstraintsParser
    {
        private readonly IConstraintReader constraintReader;

        public GameConstraintsParser(IConstraintReader constraintReader)
        {
            this.constraintReader = constraintReader;
        }

        public IEnumerable<GameConstraint> ParseContraintsFromGameSetupJson(IEnumerable<string> filepaths)
        {
            var gameConstraints = new List<GameConstraint>();

            foreach (var filepath in filepaths)
            {
                var jsonString = constraintReader.ReadConstraintsFromJSON(filepath);
                var constraints = JsonConvert.DeserializeObject<GameConstraint>(jsonString);
                gameConstraints.Add(constraints);
            }

            return gameConstraints;
        }
    }
}
