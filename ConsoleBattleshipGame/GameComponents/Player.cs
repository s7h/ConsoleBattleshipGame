using ConsoleBattlefield.ConstraintValidators;
using ConsoleBattlefield.GameSetup;
using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBattlefield.GameComponents
{
    public class Player
    {
        private readonly IConstraintValidator constraintValidator;
        private readonly IBattlefieldSetter battlefieldSetter;

        private GameConstraint gameConstraint;
        private string[,] battlefield;
        private List<MissileCoordinates> moves;
        private string name;
        private bool isValidPlayer;
        private List<string> errors;

        public Player(IConstraintValidator constraintValidator, IBattlefieldSetter battlefieldSetter, GameConstraint gameConstraint)
        {
            this.constraintValidator = constraintValidator;
            this.battlefieldSetter = battlefieldSetter;
            this.gameConstraint = gameConstraint;

            ValidateConstraint(gameConstraint);
            name = gameConstraint.PlayerName;
        }

        private void ValidateConstraint(GameConstraint gameConstraint)
        {
            errors = new List<string>();
            errors.AddRange(constraintValidator.ValidateConstraints(gameConstraint).ToList());

            isValidPlayer = errors.Any() ? false : true;

            if (isValidPlayer)
            {
                battlefield = new string[10,10];
                moves = new List<MissileCoordinates>();

                battlefield = battlefieldSetter.PrepareBattlefield(gameConstraint.Ships);
                
                
            }
        }

        public bool IsValidPlayer
        {
            get
            {
                return isValidPlayer;
            }
        }

        public IEnumerable<string> Errors
        {
            get
            {
                return errors;
            }
        }

        public string[,] Battlefield
        {
            get
            {
                return battlefield;
            }
        }

        public IEnumerable<MissileCoordinates> Moves
        {
            get
            {
                return moves;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
        }



    }
}
