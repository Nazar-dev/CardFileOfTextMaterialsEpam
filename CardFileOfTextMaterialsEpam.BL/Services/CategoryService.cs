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
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly Mapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, Mapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<CategoryModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryModel> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
