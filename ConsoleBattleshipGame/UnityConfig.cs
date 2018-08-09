using ConsoleBattlefield.ConstraintValidators;
using ConsoleBattlefield.GameSetup;
using Unity;

namespace ConsoleBattlefield
{
    public class UnityConfig
    {
        public static BattleshipExecutor RegisterDependencies()
        {
            var container = new UnityContainer();
            container.RegisterType<BattleshipExecutor>();

            //Register all dependencies
            container.RegisterType<IGameConstraintsParser, GameConstraintsParser>();
            container.RegisterType<IConstraintReader, ConstraintReader>(); 
            container.RegisterType<IConstraintValidator, ConstraintValidator>();
            container.RegisterType<IBattlefieldSetter, BattlefieldSetter>();
            container.RegisterType<IConsoleWriter, ConsoleWriter>();

            return container.Resolve<BattleshipExecutor>();
        }
    }
}
