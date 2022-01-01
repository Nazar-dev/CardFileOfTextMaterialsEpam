using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Interfaces;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.BL.Services
{
    public class BookService:IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public BookService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<BookModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BookModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(BookModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(BookModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
