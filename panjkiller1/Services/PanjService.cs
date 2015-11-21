using AutoMapper;
using Core;
using Core.Repositories;
using DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Configuration;
using System.Diagnostics;

namespace Services
{
    public class PanjService : BaseConfiguration
    {
        private IUnitOfWork _unitOfWork;
        private readonly IMecRepository _mecRepository;

        public PanjService(IUnitOfWork unitOfWork, IMecRepository mecRepository)
        {
            _unitOfWork = unitOfWork;
            _mecRepository = mecRepository;
        }

        public IEnumerable<MecDTO> GetAktivni()
        {
            var mecevi = _mecRepository.GetAktivni();
            var meceviDTO = Mapper.Map<IEnumerable<MecDTO>>(mecevi);

            return meceviDTO;
        }

        public int AddMec(MecDTO newMecDTO)
        {
            Mec newMec = Mapper.Map<Mec>(newMecDTO);

            try
            {

                Mec addedMec = _mecRepository.Add(newMec);

                _unitOfWork.Commit();

                return addedMec.Id;

            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                _unitOfWork.RollbackChanges();
                return -1;
            }
}
    }
}
