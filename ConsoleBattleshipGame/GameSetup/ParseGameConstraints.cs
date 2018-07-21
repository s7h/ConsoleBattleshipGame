using ConsoleBattlefield.ConstraintValidators;
using ConsoleBattlefield.Models;
using Newtonsoft.Json;

namespace ConsoleBattlefield.GameSetup
{
    public class ParseGameConstraints : IParseGameConstraints
    {
        private readonly IConstraintReader constraintReader;
        private readonly IConstraintValidator constraintValidator;

        public ParseGameConstraints(IConstraintReader constraintReader,
            IConstraintValidator constraintValidator)
        {
            this.constraintReader = constraintReader;
            this.constraintValidator = constraintValidator;
        }

        public GameConstraint ParseContraintsFromGameSetupJson(string filepath)
        {
            var jsonString = constraintReader.ReadConstraintsFromJSON(filepath);
            var constraints = JsonConvert.DeserializeObject<GameConstraint>(jsonString);

            var isValid = constraintValidator.ValidateConstraints();

            return isValid ? constraints : null;
        }
    }
}
