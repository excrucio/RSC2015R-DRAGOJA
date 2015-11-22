using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class PreprekeRepository : Repository<Prepreke, int>, IPreprekeRepository
    {
        private IUnitOfWork _unitOfWork;

        public PreprekeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
