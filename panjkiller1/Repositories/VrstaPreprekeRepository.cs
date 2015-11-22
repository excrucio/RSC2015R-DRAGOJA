using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using Core.Repositories;

namespace Repositories
{
    public class VrstaPreprekeRepository : Repository<VrstaPrepreke, int>, IVrstaPreprekeRepository
    {
        private IUnitOfWork _unitOfWork;

        public VrstaPreprekeRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
