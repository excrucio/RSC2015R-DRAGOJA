using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class IgraRepository : Repository<Igra, int>, IIgraRepository
    {
        private IUnitOfWork _unitOfWork;

        public IgraRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
    }
}
