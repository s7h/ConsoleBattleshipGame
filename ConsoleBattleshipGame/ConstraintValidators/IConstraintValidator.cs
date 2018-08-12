using ConsoleBattlefield.Models;
using System.Collections.Generic;

namespace ConsoleBattlefield.ConstraintValidators
{
    public interface IConstraintValidator
    {
        IEnumerable<string> ValidateConstraints(GameConstraint gameConstraints);
        IEnumerable<string> ValidateMissile(string coordinates);
    }
}
