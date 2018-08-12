using ConsoleBattlefield.Models;
using System.Collections.Generic;

namespace ConsoleBattlefield.ConstraintValidators
{
    public interface IConstraintValidator
    {
        IEnumerable<string> ValidateShipConstraints(GameConstraint gameConstraints);
        IEnumerable<string> ValidateMissile(string coordinates);
    }
}
