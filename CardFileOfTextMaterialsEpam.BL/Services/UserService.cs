using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.BL.Services {
	public class UserService:IUserService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public UserService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<UserModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<UserModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(UserModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(UserModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }
    }
}