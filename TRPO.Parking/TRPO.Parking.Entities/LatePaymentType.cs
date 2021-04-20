using System.Collections.Generic;
using System.Xml.Linq;
using TRPO.Parking.Utilitas;

namespace TRPO.Parking.Entities
{
    public class LatePaymentType
    {
        public static IEnumerable<LatePaymentType> DefaultValues { get; private set; }

        static LatePaymentType()
        {
            var values = new List<LatePaymentType>();

            var latePaymentTypeValues = Configs.DefaultValuesConfig.LatePaymentTypeValues;
            var xDocument = XDocument.Parse(latePaymentTypeValues);

            var elements = xDocument.Element("LatePaymentTypeConfig").Elements("LatePaymentType");

            foreach (var element in elements)
            {
                var idValue = element.Attribute("Id")?.Value;
                var id = int.Parse(idValue);

                var priceMultiplerValue = element.Attribute("PriceMultipler")?.Value
                    .ReplaceCultureRealSepataror(".");
                var priceMultipler = double.Parse(priceMultiplerValue);

                var FromValue = element.Attribute("From")?.Value;
                var From = int.Parse(FromValue);

                var ToValue = element.Attribute("To")?.Value;
                var To = ToValue is null
                    ? (int?)null
                    : int.Parse(ToValue);

                var value = new LatePaymentType
                {
                    Id = id,
                    PriceMultiplier = priceMultipler,
                    From = From,
                    To = To
                };

                values.Add(value);
            }

            DefaultValues = values;
        }

        public int Id { get; set; }
        public double PriceMultiplier { get; set; }
        public int From { get; set; }
        public int? To { get; set; }
    }
}
