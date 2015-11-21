using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;

namespace Core.Repositories
{
    public interface IIgraRepository : IRepository<Igra, int>
    {
        Mec GetMec(int IID);
        Igra GetIgra(int IID);
        IEnumerable<Tim> GetTimovi(int IID);
        Tim GetPrviTim(int IID);
        Tim GetDrugiTim(int IID);
    }
}
