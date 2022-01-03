﻿using System;
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

		public IEnumerable<MyPerson> GetAll() {
			return _context.EntityUsers;
		}
		public MyPerson Get(int id) {
			return _context.EntityUsers.FirstOrDefault(x => x.Id  == id);
		}
		public void Create(MyPerson item) {
			if (_context.EntityUsers.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.EntityUsers.Add(item);
		}
		public void Update(MyPerson item) {
			_context.EntityUsers.Update(item);
		}
		public void Delete(int id) {
			_context.EntityUsers.Remove(Get(id));
		}
	}
}