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
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<IEnumerable<CategoryModel>> GetAllAsync()
        {
            var book = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(_unitOfWork.CategoryRepository.GetAll());
            return Task.FromResult(book);
        }

        public Task<CategoryModel> GetByIdAsync(int id)
        {
            var category = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryModel>>(_unitOfWork.CategoryRepository.GetAll())
                .FirstOrDefault(x => x.CategoryId == id);
            return Task.FromResult(category);
        }

        public async Task AddAsync(CategoryModel model)
        {
            if (!Check(model.CategoryName)) throw new CardFileException();
            var category = _mapper.Map<CategoryModel, Category>(model);
            _unitOfWork.CategoryRepository.Create(category);
            await _unitOfWork.SaveAsync();
        }

        private bool Check(string name)
        {
            if (name == "")
                return false;
            return true;
        }

        public async Task UpdateAsync(CategoryModel model)
        {
            if (!Check(model.CategoryName)) throw new CardFileException();
            var category = _mapper.Map<CategoryModel, Category>(model);
            _unitOfWork.CategoryRepository.Update(category);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteByIdAsync(int modelId)
        {
            var model = GetByIdAsync(modelId).Result;
            var category = _mapper.Map<CategoryModel, Category>(model);
            _unitOfWork.CategoryRepository.Delete(category.CategoryId);
            await _unitOfWork.SaveAsync();
        }
    }
}
