using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Xml.XPath;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;
using CardFileOfTextMaterialsEpam.DAL.Validation;
using Microsoft.EntityFrameworkCore;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class PersonRepository:IPersonRepository {
		private readonly CardFileDbContext _context;
		public PersonRepository(CardFileDbContext context) {
			_context = context;
		}

		public IEnumerable<Person> GetAll()
        {
            return _context.EPersons;
		}
		public Person Get(int id) {
			return _context.EPersons.FirstOrDefault(x => x.PersonId  == id);
		}
		public void Create(Person item) {
			if (_context.EPersons.Any(x => x.PersonId == item.PersonId))
				throw new RepositoryException(); 
			_context.EPersons.Add(item);
		}
		public void Update(Person item) {
			_context.EPersons.Update(item);
			//TODO MAKE UPDATE CORRECTLY
		}

		public void Delete(int id) {
			_context.EPersons.Remove(Get(id));
		}
	}
}