﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace TRPO.Parking.Entities
{
    public class RentalRenewalType
    { 
        public static IEnumerable<RentalRenewalType> DefaultValues { get; private set; }

        static RentalRenewalType()
        {
            var values = new List<RentalRenewalType>();

            var rentalRenewalTypeValues = Configs.DefaultValuesConfig.RentalRenewalTypeValues;
            var xDocument = XDocument.Parse(rentalRenewalTypeValues);

            var elements = xDocument.Element("RentalRenewalTypeConfig").Elements("RentalRenewalType");

            foreach (var element in elements)
            {
                var idValue = element.Attribute("Id")?.Value;
                var id = int.Parse(idValue);

                var title = element.Attribute("Name")?.Value;

                var priceMultiplerValue = element.Attribute("PriceMultipler")?.Value;
                var priceMultipler = double.Parse(priceMultiplerValue);

                var FromValue = element.Attribute("From")?.Value;
                var From = FromValue is null 
                    ? (int?)null 
                    : int.Parse(FromValue);

                var ToValue = element.Attribute("To")?.Value;
                var To = int.Parse(ToValue);

                var value = new RentalRenewalType
                {
                    Id = id,
                    Title = title,
                    PriceMultiplier = priceMultipler,
                    From = From,
                    To = To
                };

                values.Add(value);
            }

            DefaultValues = values;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public double PriceMultiplier { get; set; }
        public int? From { get; set; }
        public int To { get; set; }
    }
}