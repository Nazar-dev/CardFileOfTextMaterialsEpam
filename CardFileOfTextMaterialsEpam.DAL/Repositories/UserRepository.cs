using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class UserRepository:IPersonRepository {
		private readonly CardFileDbContext _context;
		public UserRepository(CardFileDbContext context) {
			_context = context;
		}

		public IEnumerable<MyPerson> GetAll() {
			return _context.EntityPerson;
		}
		public MyPerson Get(int id) {
			return _context.EntityPerson.FirstOrDefault(x => x.Id  == id);
		}
		public void Create(MyPerson item) {
			if (_context.EntityPerson.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.EntityPerson.Add(item);
		}
		public void Update(MyPerson item) {
			_context.EntityPerson.Update(item);
		}
		public void Delete(int id) {
			_context.EntityPerson.Remove(Get(id));
		}
	}
}