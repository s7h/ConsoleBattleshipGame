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

            return container.Resolve<BattleshipExecutor>();
        }
    }
}
