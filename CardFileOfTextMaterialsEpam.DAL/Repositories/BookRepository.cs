using System;
using System.Collections.Generic;
using System.Linq;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class BookRepository:IBookRepository {

		private readonly CardFileDbContext _context;
		public BookRepository(CardFileDbContext context) {
			_context = context;
		}
		public IEnumerable<Book> GetAll() {
			return _context.EntityBooks;
		}
		public Book Get(int id) {
			return _context.EntityBooks.FirstOrDefault(x => x.Id == id);
		}
		public void Create(Book item) {
			if (_context.EntityBooks.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.EntityBooks.Add(item);
		}
		public void Update(Book item) {
			_context.EntityBooks.Update(item);
		}
		public void Delete(int id) {
			_context.EntityBooks.Remove(Get(id));
		}
	}
}