﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRPO.Parking.Repositories.Interfaces
{
    public interface ITestRepoInterface
    {
        Task<string> GetTestValue();
        Task<IEnumerable<string>> GetGenders();
    }
}
