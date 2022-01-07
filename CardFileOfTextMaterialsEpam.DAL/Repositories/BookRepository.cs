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
			return _context.EBooks;
		}
		public Book Get(int id) {
			return _context.EBooks.FirstOrDefault(x => x.BookId == id);
		}
		public void Create(Book item) {
			if (_context.EBooks.Any(x => x.BookId == item.BookId))
				throw new Exception(); // TODO display on webpage eror
			_context.EBooks.Add(item);
		}
		public void Update(Book item) {
			_context.EBooks.Update(item);
		}
		public void Delete(int id) {
			_context.EBooks.Remove(Get(id));
		}
	}
}