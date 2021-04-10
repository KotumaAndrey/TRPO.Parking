using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Xml.Linq;

namespace TRPO.Parking.Entities.Primitives
{
    public static class ClientTypeExt
    {
        private static Dictionary<ClientType, double> priceMultiplers = null;

        private static void InitPriceMultiplers()
        {
            priceMultiplers = new Dictionary<ClientType, double>();

            var xDocument = XDocument.Parse(PrimitivesConfig.ClientTypeValues);

            var elements = xDocument.Element("ClientTypeConfig").Elements("ClientType");

            var clientTypes = Enum.GetValues(typeof(ClientType))
                .Cast<ClientType>()
                .ToArray();

            foreach (var type in clientTypes)
            {
                var name = type.ToString();
                var curElement = elements.First(e => e.Attribute("Name").Value == name);
                var curValue = curElement.Attribute("PriceMultipler").Value;
                var mult = double.Parse(curValue);
                priceMultiplers.Add(type, mult);
            }
        }

        public static double GetPriceMultipler(this ClientType type)
        {
            if (priceMultiplers is null)
            {
                InitPriceMultiplers();
            }

            return priceMultiplers[type];
        }
    }
}
