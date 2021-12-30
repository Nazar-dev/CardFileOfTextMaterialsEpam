using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.XPath;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class UserRepository:IUserRepository {
		private readonly CardFileDbContext _context;
		public UserRepository(CardFileDbContext context) {
			_context = context;
		}

		public IEnumerable<User> GetAll() {
			return _context.Users;
		}
		public User Get(int id) {
			return _context.Users.FirstOrDefault(x => x.Id  == id);
		}
		public void Create(User item) {
			if (_context.Users.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.Users.Add(item);
		}
		public void Update(User item) {
			_context.Users.Update(item);
		}
		public void Delete(int id) {
			_context.Users.Remove(Get(id));
		}
	}
}