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
        private Stack<MissileCoordinates> moves;
        private string name;
        private bool isValidPlayer;
        private List<string> errors;
        public Dictionary<string, int> BattlefieldAnalyzer;
        public bool IsVictor;

        public Player(IConstraintValidator constraintValidator, IBattlefieldSetter battlefieldSetter, GameConstraint gameConstraint)
        {
            this.constraintValidator = constraintValidator;
            this.battlefieldSetter = battlefieldSetter;
            this.gameConstraint = gameConstraint;

            ValidateConstraint(gameConstraint);
            InitializeBattlefieldAnalyzer();
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
                moves = new Stack<MissileCoordinates>();

                var missileArray = gameConstraint.MissileCoordinates.Split(',');

                foreach (var missile in missileArray)
                {
                    var positionXY = missile.ToCharArray();
                    moves.Push(new MissileCoordinates
                    {
                        PosX = Int32.Parse(positionXY[0].ToString()),
                        PosY = Int32.Parse(positionXY[1].ToString())
                    });
                }

                battlefield = battlefieldSetter.PrepareBattlefield(gameConstraint.Ships);
                
                
            }
        }

        /// <summary>
        /// Dictionary to track elements on battlefield
        /// </summary>
        private void InitializeBattlefieldAnalyzer()
        {
            BattlefieldAnalyzer = new Dictionary<string, int>();
            BattlefieldAnalyzer.Add(Constants.DESTROYER_AVATAR, 2);
            BattlefieldAnalyzer.Add(Constants.BATTLESHIP_AVATAR, 4);
            BattlefieldAnalyzer.Add(Constants.CARRIER_AVATAR, 5);
            BattlefieldAnalyzer.Add(Constants.CRUISER_AVATAR, 3);
            BattlefieldAnalyzer.Add(Constants.SUBMARINE_AVATAR, 3);
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

        public Stack<MissileCoordinates> Moves
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
