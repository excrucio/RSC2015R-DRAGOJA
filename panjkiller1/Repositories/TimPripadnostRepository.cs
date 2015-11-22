using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class TimPripadnostRepository : Repository<TimPripadnost, int>, ITimPripadnostRepository
    {
        private IUnitOfWork _unitOfWork;

        public TimPripadnostRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
