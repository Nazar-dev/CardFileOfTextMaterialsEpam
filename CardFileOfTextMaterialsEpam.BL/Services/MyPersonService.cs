using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.BL.Services {
	public class MyPersonService:IMyPersonService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public MyPersonService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<MyPersonModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<MyPersonModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(MyPersonModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(MyPersonModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }
    }
}