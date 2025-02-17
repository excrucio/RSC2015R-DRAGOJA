﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.Repositories
{
    public interface IMecRepository : IRepository<Mec, int>
    {
        IEnumerable<Mec> GetAktivni();
        IEnumerable<Tim> GetTimoviUMecu(int mid);
    }
}
