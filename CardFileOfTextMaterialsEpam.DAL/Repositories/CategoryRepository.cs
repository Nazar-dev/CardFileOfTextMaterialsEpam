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
			return _context.EntityCategories;
		}
		public Category Get(int id) {
			return _context.EntityCategories.FirstOrDefault(x => x.Id == id);
		}
		public void Create(Category item) {
			if (_context.EntityCategories.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.EntityCategories.Add(item);
		}
		public void Update(Category item) {
			_context.EntityCategories.Update(item);
		}
		public void Delete(int id) {
			_context.EntityCategories.Remove(Get(id));
		}
	}
}