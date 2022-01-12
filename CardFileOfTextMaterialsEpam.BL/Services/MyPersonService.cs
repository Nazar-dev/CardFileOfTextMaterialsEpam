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
using Microsoft.Extensions.Localization.Internal;

namespace CardFileOfTextMaterialsEpam.BL.Services {
	public class MyPersonService:IMyPersonService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MyPersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IEnumerable<PersonModel>> GetAllAsync()
        {
            var book = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonModel>>(_unitOfWork.PersonRepository.GetAll());
            return Task.FromResult(book);
        }

        public Task<PersonModel> GetByIdAsync(int id)
        {
            var person = _mapper.Map<IEnumerable<Person>, IEnumerable<PersonModel>>(_unitOfWork.PersonRepository.GetAll())
                .FirstOrDefault(x => x.PersonId == id);
            return Task.FromResult(person);
        }

        public async Task AddAsync(PersonModel model)
        {
            if (!Check(model.Name) && !Check(model.Surname)) throw new CardFileException();
            var person = _mapper.Map<PersonModel, Person>(model);
            _unitOfWork.PersonRepository.Create(person);
            await _unitOfWork.SaveAsync();
        }

        private bool Check(string name)
        {
            if (name == "")
                return false;
            return true;
        }

        public async Task UpdateAsync(PersonModel model)
        {
            if (!Check(model.Name) && !Check(model.Surname)) throw new CardFileException();
            var person = _mapper.Map<PersonModel, Person>(model);
            _unitOfWork.PersonRepository.Update(person);
           await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var model = GetByIdAsync(modelId).Result;
            var person = _mapper.Map<PersonModel, Person>(model);
            _unitOfWork.PersonRepository.Delete(person.PersonId);
            await _unitOfWork.SaveAsync();
        }
    }
}