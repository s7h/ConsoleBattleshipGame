using ConsoleBattlefield.ConstraintValidators;
using ConsoleBattlefield.GameComponents;
using ConsoleBattlefield.GameSetup;
using ConsoleBattlefield.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleBattlefield
{
    public class BattleshipExecutor
    {
        private readonly IGameConstraintsParser gameConstraintsParser;
        private readonly IConstraintValidator constraintValidator;
        private readonly IBattlefieldSetter battlefieldSetter;

        public BattleshipExecutor(IGameConstraintsParser gameConstraintsParser,
            IConstraintValidator constraintValidator,
            IBattlefieldSetter battlefieldSetter)
        {
            this.gameConstraintsParser = gameConstraintsParser;
            this.constraintValidator = constraintValidator;
            this.battlefieldSetter = battlefieldSetter;
        }

        public void SetupAndStartTheGame(IEnumerable<string> filepaths)
        {
            var constraints = GetConstraintsFromFilePath(filepaths);
            var playerOne = SetupPlayer(constraints.ElementAt(0));
            var playerTwo = SetupPlayer(constraints.ElementAt(1));

            if (playerOne.IsValidPlayer && playerTwo.IsValidPlayer)
            {
                //continue processing
            }
            else
            {
                var errorsDict = new Dictionary<string, IEnumerable<string>>();
                errorsDict.Add(playerOne.Name, playerOne.Errors);
                errorsDict.Add(playerTwo.Name, playerTwo.Errors);
                PrintErrors(errorsDict);
            }

        }

        private Player SetupPlayer(GameConstraint constraints)
        {
            return new Player(constraintValidator, battlefieldSetter, constraints);
        }

        private IEnumerable<GameConstraint> GetConstraintsFromFilePath(IEnumerable<string> filepaths)
        {
            return gameConstraintsParser.ParseContraintsFromGameSetupJson(filepaths);
        }

        private void PrintErrors(Dictionary<string, IEnumerable<string>> errorsDict)
        {
            foreach (var kvp in errorsDict)
            {
                var element = errorsDict[kvp.Key];
                if (element != null && element.Any())
                {
                    foreach (var error in element)
                    {
                        Console.WriteLine($"{kvp.Key} : {error}");
                    }
                }
            }
        }
    }
}
