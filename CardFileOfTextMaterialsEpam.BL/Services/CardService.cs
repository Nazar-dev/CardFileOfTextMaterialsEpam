using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.BL.Services {
	public class CardService:ICardService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CardService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IEnumerable<CardModel>> GetAllAsync()
        {
            var book = _mapper.Map<IEnumerable<Card>, IEnumerable<CardModel>>(_unitOfWork.CardRepository.GetAll());
            return Task.FromResult(book);
        }
        public Task<CardModel> GetByIdAsync(int id)
        {
            var card = _mapper.Map<IEnumerable<Card>, IEnumerable<CardModel>>(_unitOfWork.CardRepository.GetAll())
                .FirstOrDefault(x => x.Id == id);
            return Task.FromResult(card);
        }

        public Task AddAsync(CardModel model)
        {
            var card = _mapper.Map<CardModel, Card>(model);
            _unitOfWork.CardRepository.Update(card);
            _unitOfWork.SaveAsync();
            return Task.CompletedTask;
        }


        public Task UpdateAsync(CardModel model)
        {
            var card = _mapper.Map<CardModel, Card>(model);
            _unitOfWork.CardRepository.Update(card);
            _unitOfWork.SaveAsync();
            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(int modelId)
        {
            var model = GetByIdAsync(modelId).Result;
            var card = _mapper.Map<CardModel, Card>(model);
            _unitOfWork.CardRepository.Delete(card.Id);
            _unitOfWork.SaveAsync();
            return Task.CompletedTask;
        }
    }
}