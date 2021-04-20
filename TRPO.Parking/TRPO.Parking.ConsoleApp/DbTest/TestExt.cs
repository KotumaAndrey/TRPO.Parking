using System;
using TRPO.Parking.Entities;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    static class TestExt
    {
        public static string ToNullStr<T>(this T obj) where T : class
            => obj?.ToString() ?? "<null>";

        public static string ToNullStr<T>(this T? obj) where T : struct
            => obj?.ToString() ?? "<null>";

        public static bool IsEqual(Accident e1, Accident e2)
        {
            return e1.AccidentDate.Equals(e2.AccidentDate)
                && IsEqual(e1.CulpritClient, e2.CulpritClient)
                && e1.Comment == e2.Comment;
        }

        public static bool IsEqual(AccidentMember am1, AccidentMember am2)
        {
            return IsEqual(am1.Accident, am2.Accident)
                && IsEqual(am1.Client, am2.Client);
        }

        public static bool IsEqual(ActiveRental e1, ActiveRental e2)
        {
            return IsEqual(e1.Client, e2.Client)
                && IsEqual(e1.ParkingSpace, e2.ParkingSpace)
                && DateTime.Equals(e1.OpenDate, e2.OpenDate)
                && DateTime.Equals(e1.ExpectedCloseDate, e2.ExpectedCloseDate);
        }

        public static bool IsEqual(ActiveRentalParkingSpaces e1, ActiveRentalParkingSpaces e2)
        {
            return IsEqual(e1.ActiveRental, e2.ActiveRental)
                && IsEqual(e1.ParkingSpace, e2.ParkingSpace);
        }

        public static bool IsEqual(ActiveRentalRenewal e1, ActiveRentalRenewal e2)
        {
            return IsEqual(e1.Rental, e2.Rental)
                && DateTime.Equals(e1.NewEndDate, e2.NewEndDate)
                && IsEqual(e1.Type, e2.Type);
        }

        public static bool IsEqual(Administrator e1, Administrator e2)
        {
            return e1.Login == e2.Login
                && e1.Password == e2.Password
                && IsEqual(e1.Employee, e2.Employee);
        }

        public static bool IsEqual(Client e1, Client e2)
        {
            return e1.Name == e1.Name
                   && e1.PhoneNumber == e2.PhoneNumber
                   && e1.Password == e2.Password
                   && e1.Age == e2.Age
                   && e1.Gender == e2.Gender
                   && e1.Email == e2.Email
                   && e1.Experience == e2.Experience
                   && e1.ClientType.Type == e2.ClientType.Type
                   && e1.LatePaymentMinutesLeft == e2.LatePaymentMinutesLeft
                   && e1.LatePaymentPriceMultiplier == e2.LatePaymentPriceMultiplier;
        }

        public static bool IsEqual(ClientTypeEntity e1, ClientTypeEntity e2)
        {
            return e1.Type == e2.Type
                && e1.Price == e2.Price;
        }

        public static bool IsEqual(ClientTypeUpdateRequest e1, ClientTypeUpdateRequest e2)
        {
            return IsEqual(e1.Client, e2.Client)
                && DateTime.Equals(e1.OpenDate, e2.OpenDate)
                && e1.OldClientType == e2.OldClientType
                && e1.NewClientType == e2.NewClientType
                && e1.Status == e2.Status
                && IsEqual(e1.Administrator, e2.Administrator)
                && DateTime.Equals(e1.CloseDate, e2.CloseDate);
        }

        public static bool IsEqual(ClosedRental e1, ClosedRental e2)
        {
            return IsEqual(e1.Client, e2.Client)
                && IsEqual(e1.ParkingSpace, e2.ParkingSpace)
                && DateTime.Equals(e1.OpenDate, e2.OpenDate)
                && DateTime.Equals(e1.ExpectedCloseDate, e2.ExpectedCloseDate)
                && DateTime.Equals(e1.RealCloseDate, e2.RealCloseDate)
                && e1.Price == e2.Price;
        }

        public static bool IsEqual(ClosedRentalParkingSpaces e1, ClosedRentalParkingSpaces e2)
        {
            return IsEqual(e1.ClosedRental, e2.ClosedRental)
                && IsEqual(e1.ParkingSpace, e2.ParkingSpace);
        }

        public static bool IsEqual(ClosedRentalRenewal e1, ClosedRentalRenewal e2)
        {
            return IsEqual(e1.Rental, e2.Rental)
                && DateTime.Equals(e1.OldEndDate, e2.OldEndDate)
                && DateTime.Equals(e1.NewEndDate, e2.NewEndDate)
                && e1.Type == e2.Type;
        }

        public static bool IsEqual(Employee e1, Employee e2)
        {
            return e1.Name == e2.Name
                && DateTime.Equals(e1.EmployeementDate, e2.EmployeementDate)
                && e1.Salary == e2.Salary
                && e1.Type == e2.Type;
        }

        public static bool IsEqual(Floor e1, Floor e2)
        {
            return e1.RowCount == e2.RowCount
                && e1.ColumnCount == e2.ColumnCount;
        }

        public static bool IsEqual(LatePayment e1, LatePayment e2)
        {
            return IsEqual(e1.Client, e2.Client)
                && IsEqual(e1.LatePaymentType, e2.LatePaymentType)
                && IsEqual(e1.ParkingSpace, e2.ParkingSpace)
                && IsEqual(e1.ActiveRental, e2.ActiveRental)
                && IsEqual(e1.ClosedRental, e2.ClosedRental);
        }

        public static bool IsEqual(LatePaymentType e1, LatePaymentType e2)
        {
            return e1.PriceMultiplier == e2.PriceMultiplier
                && e1.From == e2.From
                && e1.To == e2.To;
        }

        public static bool IsEqual(ParkingSpace e1, ParkingSpace e2)
        {
            return IsEqual(e1.Floor, e2.Floor)
                && e1.Row == e2.Row
                && e1.Colunm == e2.Colunm
                && e1.Status == e2.Status;
        }

        public static bool IsEqual(RentalRenewalType e1, RentalRenewalType e2)
        {
            return e1.PriceMultiplier == e2.PriceMultiplier
                && e1.From == e2.From
                && e1.To == e2.To;
        }
    }
}
