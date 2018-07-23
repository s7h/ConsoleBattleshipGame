using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBattlefield.ConstraintValidators
{
    public interface IConstraintValidator
    {
        bool ValidateConstraints(GameConstraint gameConstraints);
    }
}
