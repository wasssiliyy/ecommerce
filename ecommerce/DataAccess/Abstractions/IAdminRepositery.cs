﻿using ecommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.DataAccess.Abstractions
{
    public interface IAdminRepository : IRepository<Admin>
    {

    }
}
