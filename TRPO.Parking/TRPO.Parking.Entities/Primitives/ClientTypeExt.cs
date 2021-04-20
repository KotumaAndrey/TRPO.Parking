using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using TRPO.Parking.Utilitas;

namespace TRPO.Parking.Entities.Primitives
{
    public static class ClientTypeExt
    {
        private static Dictionary<ClientType, double> price = null;

        public static ClientTypeEntity ToEntity(this ClientType type)
            => new ClientTypeEntity
            {
                Type = type,
                Price = type.GetPrice()
            };

        public static double GetPrice(this ClientType type)
        {
            if (price is null)
            {
                InitPrice();
            }

            return price[type];
        }

        private static void InitPrice()
        {
            price = new Dictionary<ClientType, double>();

            var clientTypeValues = Configs.PrimitivesConfig.ClientTypeValues;
            var xDocument = XDocument.Parse(clientTypeValues);

            var elements = xDocument.Element("ClientTypeConfig").Elements("ClientType");

            var clientTypes = Enum.GetValues(typeof(ClientType))
                .Cast<ClientType>()
                .ToArray();

            foreach (var type in clientTypes)
            {
                var name = type.ToString();
                var curElement = elements.First(e => e.Attribute("Name").Value == name);
                var curValue = curElement.Attribute("Price").Value
                    .ReplaceCultureRealSepataror(".");
                var mult = double.Parse(curValue);
                price.Add(type, mult);
            }
        }
    }
}
