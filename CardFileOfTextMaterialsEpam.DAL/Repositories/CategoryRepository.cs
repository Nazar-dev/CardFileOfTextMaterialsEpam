using System;
using System.Collections.Generic;
using System.Linq;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class CategoryRepository:ICategoryRepository {
		private readonly CardFileDbContext _context;
		public CategoryRepository(CardFileDbContext context) {
			_context = context;
		}


		public IEnumerable<Category> GetAll() {
			return _context.Categories;
		}
		public Category Get(int id) {
			return _context.Categories.FirstOrDefault(x => x.Id == id);
		}
		public void Create(Category item) {
			if (_context.Categories.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.Categories.Add(item);
		}
		public void Update(Category item) {
			_context.Categories.Update(item);
		}
		public void Delete(int id) {
			_context.Categories.Remove(Get(id));
		}
	}
}