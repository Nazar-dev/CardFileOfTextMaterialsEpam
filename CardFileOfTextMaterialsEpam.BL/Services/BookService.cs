using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.BL.Validation;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<IEnumerable<BookModel>> GetAllAsync()
        {
            var book = _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(_unitOfWork.BookRepository.GetAll());
            return Task.FromResult(book);
        }

        public Task<BookModel> GetByIdAsync(int id)
        {
            var book = _mapper.Map<IEnumerable<Book>, IEnumerable<BookModel>>(_unitOfWork.BookRepository.GetAll())
                .FirstOrDefault(x => x.BookId == id);
            return Task.FromResult(book);
        }

        public async Task AddAsync(BookModel model)
        {
            if (!Check(model.BookName)) throw new CardFileException();
            var reader = _mapper.Map<BookModel, Book>(model);
            _unitOfWork.BookRepository.Create(reader);

            var res = await _unitOfWork.SaveAsync();

        }

        private bool Check(string name)
        {
            if (name == "")
                return false;
            return true;
        }

        public async  Task UpdateAsync(BookModel model)
        {
            if (!Check(model.BookName)) throw new CardFileException();
            var reader = _mapper.Map<BookModel, Book>(model);
            _unitOfWork.BookRepository.Update(reader);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var model = GetByIdAsync(modelId).Result;
            var reader= _mapper.Map<BookModel, Book>(model);
            _unitOfWork.BookRepository.Delete(reader.BookId);
            await _unitOfWork.SaveAsync();
        }
    }
}