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
                .FirstOrDefault(x => x.Id == id);
            return Task.FromResult(book);
        }

        public Task AddAsync(BookModel model)
        {
            if (!Check(model.BookName)) throw new CardFileExeption();
            var reader = _mapper.Map<BookModel, Book>(model);
            _unitOfWork.BookRepository.Update(reader);
            _unitOfWork.SaveAsync();
            return Task.CompletedTask;
        }

        private bool Check(string name)
        {
            if (name == "")
                return false;
            return true;
        }

        public Task UpdateAsync(BookModel model)
        {
            if (!Check(model.BookName)) throw new CardFileExeption();
            var reader = _mapper.Map<BookModel, Book>(model);
            _unitOfWork.BookRepository.Update(reader);
            _unitOfWork.SaveAsync();
            return Task.CompletedTask;
        }

        public Task DeleteByIdAsync(int modelId)
        {
            var model = GetByIdAsync(modelId).Result;
            var reader = _mapper.Map<BookModel, Book>(model);
            _unitOfWork.BookRepository.Delete(reader.Id);
            return Task.CompletedTask;
        }
    }
}