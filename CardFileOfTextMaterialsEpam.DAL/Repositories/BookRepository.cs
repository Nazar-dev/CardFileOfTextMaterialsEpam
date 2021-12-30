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
			return _context.Books;
		}
		public Book Get(int id) {
			return _context.Books.FirstOrDefault(x => x.Id == id);
		}
		public void Create(Book item) {
			if (_context.Books.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.Books.Add(item);
		}
		public void Update(Book item) {
			_context.Books.Update(item);
		}
		public void Delete(int id) {
			_context.Books.Remove(Get(id));
		}
	}
}