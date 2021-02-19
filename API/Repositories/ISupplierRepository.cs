﻿using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repositories
{
    interface ISupplierRepository
    {
        IEnumerable<Supplier> Get();
        Task<IEnumerable<Supplier>> Get(int id);
        //IEnumerable<Supplier> Get(int id);
        int Create(Supplier supplier);
        int Update(Supplier supplier, int id);
        int Delete(int id);

    }
}
