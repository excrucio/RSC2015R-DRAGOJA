using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class SuciRepository : Repository<Suci, int>, ISuciRepository
    {
        private IUnitOfWork _unitOfWork;

        public SuciRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
