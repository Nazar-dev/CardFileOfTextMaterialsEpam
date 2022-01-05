using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.BL.Validation;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.BL.Services {
	public class MyPersonService:IMyPersonService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MyPersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IEnumerable<MyPersonModel>> GetAllAsync()
        {
            var book = _mapper.Map<IEnumerable<MyPerson>, IEnumerable<MyPersonModel>>(_unitOfWork.UserRepository.GetAll());
            return Task.FromResult(book);
        }

        public Task<MyPersonModel> GetByIdAsync(int id)
        {
            var person = _mapper.Map<IEnumerable<MyPerson>, IEnumerable<MyPersonModel>>(_unitOfWork.UserRepository.GetAll())
                .FirstOrDefault(x => x.Id == id);
            return Task.FromResult(person);
        }

        public Task AddAsync(MyPersonModel model)
        {
            if (!Check(model.Name) && !Check(model.Surname)) throw new CardFileExeption();
            var person = _mapper.Map<MyPersonModel, MyPerson>(model);
            _unitOfWork.UserRepository.Update(person);
            _unitOfWork.SaveAsync();
            return Task.CompletedTask;
        }

        private bool Check(string name)
        {
            if (name == "")
                return false;
            return true;
        }

        public Task UpdateAsync(MyPersonModel model)
        {
            if (!Check(model.Name) && !Check(model.Surname)) throw new CardFileExeption();
            var person = _mapper.Map<MyPersonModel, MyPerson>(model);
            _unitOfWork.UserRepository.Update(person);
            _unitOfWork.SaveAsync();
            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(int modelId)
        {
            var model = GetByIdAsync(modelId).Result;
            var person = _mapper.Map<MyPersonModel, MyPerson>(model);
            _unitOfWork.UserRepository.Delete(person.Id);
            return Task.CompletedTask;
        }
    }
}