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

        public void SetupAndStartTheGame(IEnumerable<string> filepaths)
        {
            var constraints = GetConstraintsFromFilePath(filepaths);
            var playerOne = SetupPlayer(constraints.ElementAt(0));
            var playerTwo = SetupPlayer(constraints.ElementAt(1));


        }

        private Player SetupPlayer(GameConstraint constraints)
        {
            throw new NotImplementedException();
        }

        private IEnumerable<GameConstraint> GetConstraintsFromFilePath(IEnumerable<string> filepaths)
        {
            return gameConstraintsParser.ParseContraintsFromGameSetupJson(filepaths);
        }
    }
}
