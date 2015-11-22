using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class KorisnikRepository : Repository<Korisnik, int>, IKorisnikRepository
    {
        private IUnitOfWork _unitOfWork;

        public KorisnikRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

    }
}
