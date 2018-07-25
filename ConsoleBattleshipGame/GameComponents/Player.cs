using ConsoleBattlefield.ConstraintValidators;
using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBattlefield.GameComponents
{
    public class Player
    {
        private readonly IConstraintValidator constraintValidator;

        private GameConstraint gameConstraint;
        private Battlefield battlefield;
        private string[] moves;
        private string name;
        private bool isValidPlayer;

        public Player(IConstraintValidator constraintValidator, GameConstraint gameConstraint)
        {
            this.constraintValidator = constraintValidator;
            ValidateConstraint(gameConstraint);
            this.gameConstraint = gameConstraint;
        }

        private void ValidateConstraint(GameConstraint gameConstraint)
        {
            constraintValidator.ValidateConstraints(gameConstraint);
        }

        public bool IsValidPlayer
        {
            get
            {
                return isValidPlayer;
            }
        }
    }
}
