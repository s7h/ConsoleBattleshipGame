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
        private readonly IConsoleWriter consoleWriter;

        bool gameOn = true;

        public BattleshipExecutor(IGameConstraintsParser gameConstraintsParser,
            IConstraintValidator constraintValidator,
            IBattlefieldSetter battlefieldSetter,
            IConsoleWriter consoleWriter)
        {
            this.gameConstraintsParser = gameConstraintsParser;
            this.constraintValidator = constraintValidator;
            this.battlefieldSetter = battlefieldSetter;
            this.consoleWriter = consoleWriter;
        }

        public void SetupAndStartTheGame(IEnumerable<string> filepaths)
        {
            var constraints = GetConstraintsFromFilePath(filepaths);

            var playerOne = SetupPlayer(constraints.ElementAt(0));
            var playerTwo = SetupPlayer(constraints.ElementAt(1));

            if (playerOne.IsValidPlayer && playerTwo.IsValidPlayer)
            {
                while (gameOn)
                {
                    gameOn = playerOne.FireWeapon(playerTwo);
                    gameOn = playerTwo.FireWeapon(playerOne);
                }

                if (playerOne.IsVictor)
                {
                    Console.WriteLine($"{playerOne.Name} WINS...");
                }
                else if (playerTwo.IsVictor)
                {
                    Console.WriteLine($"{playerTwo.Name} WINS...");
                }
                else
                {
                    Console.WriteLine("Both players declared peace.");
                }

                PrintBattlefield(playerOne.Battlefield, playerOne.Name);
                PrintBattlefield(playerTwo.Battlefield, playerTwo.Name);

            }
            else
            {
                var errorsDict = new Dictionary<string, IEnumerable<string>>();
                errorsDict.Add(playerOne.Name, playerOne.Errors);
                errorsDict.Add(playerTwo.Name, playerTwo.Errors);
                PrintErrors(errorsDict);
            }

        }

        private void PrintBattlefield(string[,] battlefield, string playerName)
        {
            Console.WriteLine($"[################## {playerName} ##################]");

            for (int i = 0; i <= 9; i++)
            {
                for (int j = 0; j <= 9; j++)
                {
                    consoleWriter.PrintAvatar(battlefield[i, j]);
                }
                Console.WriteLine("");
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
            Console.WriteLine("Please check the errors.\n");

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
