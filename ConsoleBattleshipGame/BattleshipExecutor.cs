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
        public BattleshipExecutor(IGameConstraintsParser gameConstraintsParser)
        {
            this.gameConstraintsParser = gameConstraintsParser;
        }

        public void SetupAndStartTheGame(string filepath)
        {
            var constraints = GetConstraintsFromFilePath(filepath);
            var playerOne = SetupPlayer(constraints);
            var playerTwo = SetupPlayer(constraints);


        }

        private Player SetupPlayer(GameConstraint constraints)
        {
            throw new NotImplementedException();
        }

        private GameConstraint GetConstraintsFromFilePath(string filepath)
        {
            return gameConstraintsParser.ParseContraintsFromGameSetupJson(filepath);
        }
    }
}
