using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class MecRepository : Repository<Mec, int>, IMecRepository
    {

        private IUnitOfWork _unitOfWork;

        public MecRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Mec> GetAktivni()
        {
            return _unitOfWork.Mec.Where(m => m.Aktivan == true).ToList();
        }
    }
}
