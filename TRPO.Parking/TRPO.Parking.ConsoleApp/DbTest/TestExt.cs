using System;
using System.Collections.Generic;
using System.Text;

namespace TRPO.Parking.ConsoleApp.DbTest
{
    static class TestExt
    {
        public static string ToNullStr<T>(this T obj) where T : class
            => obj?.ToString() ?? "<null>";

        public static string ToNullStr<T>(this T? obj) where T : struct
            => obj?.ToString() ?? "<null>";
    }
}
