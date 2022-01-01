using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.BL.Services {
	public class CardService:ICardService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public CardService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CardModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<CardModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(CardModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(CardModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new System.NotImplementedException();
        }
    }
}