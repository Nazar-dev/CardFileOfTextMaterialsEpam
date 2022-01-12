using System;
using System.Collections.Generic;
using System.Linq;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;
using CardFileOfTextMaterialsEpam.DAL.Validation;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class CategoryRepository:ICategoryRepository {
		private readonly CardFileDbContext _context;
		public CategoryRepository(CardFileDbContext context) {
			_context = context;
		}


		public IEnumerable<Category> GetAll() {
			return _context.ECategories;
		}
		public Category Get(int id) {
			return _context.ECategories.FirstOrDefault(x => x.CategoryId == id);
		}
		public void Create(Category item) {
			if (_context.ECategories.Any(x => x.CategoryId == item.CategoryId))
				throw new RepositoryException(); 
			_context.ECategories.Add(item);
		}
		public void Update(Category item) {
			_context.ECategories.Update(item);
		}
		public void Delete(int id) {
			_context.ECategories.Remove(Get(id));
		}
	}
}