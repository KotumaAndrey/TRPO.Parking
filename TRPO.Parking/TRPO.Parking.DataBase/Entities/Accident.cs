﻿using System;

namespace TRPO.Parking.DataBase.Entities
{
    public class Accident
    {
        public int Id { get; set; }

        public DateTime AccidentDate { get; set; }

        public int CulpritId { get; set; }

        public string Comment { get; set; }
    }
}