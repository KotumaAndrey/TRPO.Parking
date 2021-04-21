using Autofac;
using TRPO.Parking.DataBase.Mappers.Utilities;
using TRPO.Parking.Utilitas.Pathfinder;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    static class FullTest
    {
        public static void Test(bool print = false)
        {
            IPathfinder pathfinder = Dependencies.DependencyResolver.Container.Resolve<IPathfinder>();
            GetEntityFromDb.Pathfinder = pathfinder;

            ClientTest.Test(print, pathfinder);
            AccidentTest.Test(print, pathfinder);

            AccidentMemberTest.Test(print, pathfinder);

        }
    }
}
