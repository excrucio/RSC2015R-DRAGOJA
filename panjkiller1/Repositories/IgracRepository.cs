using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class IgracRepository : Repository<Igrac, int>, IIgracRepository
    {
        private IUnitOfWork _unitOfWork;

        public IgracRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Igrac GetByKorisnikId(int korisnikID)
        {
            return _unitOfWork.Igrac.Where(i => i.KorisnikId == korisnikID).SingleOrDefault();
        }
    }
}
