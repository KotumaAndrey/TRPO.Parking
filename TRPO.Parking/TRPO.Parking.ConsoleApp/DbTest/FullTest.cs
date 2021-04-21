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
            FloorTest.Test(print, pathfinder);
            ParkingSpaceTest.Test(print, pathfinder);

            AccidentTest.Test(print, pathfinder);
            ActiveRentalTest.Test(print, pathfinder);
            AccidentMemberTest.Test(print, pathfinder);
            //ActiveRentalParkingSpacesTest.Test(print, pathfinder);
            ActiveRentalRenewalTest.Test(print, pathfinder);

            ClosedRentalTest.Test(print, pathfinder);
            //ClosedRentalParkingSpacesTest.Test(print, pathfinder);
            //ClosedRentalRenewalTest.Test(print, pathfinder);

            EmployeeTest.Test(print, pathfinder);
            AdministratorTest.Test(print, pathfinder);

            //  Can't remove entities from DBSet
            //ClientTypeEntityTypeEntityTest.Test(print, pathfinder);
            ClientTypeUpdateRequestTypeUpdateRequestTest.Test(print, pathfinder);

            //LatePaymentTypeTest.Test(print, pathfinder);
            //LatePaymentTest.Test(print, pathfinder);
        }
    }
}
