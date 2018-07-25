using ConsoleBattlefield.ConstraintValidators;
using ConsoleBattlefield.GameComponents;
using ConsoleBattlefield.GameSetup;
using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBattlefield
{
    public class BattleshipExecutor
    {
        private readonly IGameConstraintsParser gameConstraintsParser;
        private readonly IConstraintValidator constraintValidator;
        public BattleshipExecutor(IGameConstraintsParser gameConstraintsParser,
            IConstraintValidator constraintValidator)
        {
            this.gameConstraintsParser = gameConstraintsParser;
            this.constraintValidator = constraintValidator;
        }

        public void SetupAndStartTheGame(IEnumerable<string> filepaths)
        {
            var constraints = GetConstraintsFromFilePath(filepaths);
            var playerOne = SetupPlayer(constraints.ElementAt(0));
            var playerTwo = SetupPlayer(constraints.ElementAt(1));


        }

        private Player SetupPlayer(GameConstraint constraints)
        {
            return new Player(constraintValidator, constraints);
        }

        private IEnumerable<GameConstraint> GetConstraintsFromFilePath(IEnumerable<string> filepaths)
        {
            return gameConstraintsParser.ParseContraintsFromGameSetupJson(filepaths);
        }
    }
}
