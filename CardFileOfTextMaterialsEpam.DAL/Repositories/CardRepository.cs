using System;
using System.Collections.Generic;
using System.Linq;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class CardRepository:ICardRepository {
		private readonly CardFileDbContext _context;
		public CardRepository(CardFileDbContext context) {
			_context = context;
		}

		public IEnumerable<Card> GetAll() {
			return _context.EntityCards;
		}
		public Card Get(int id) {
			return _context.EntityCards.FirstOrDefault(x => x.Id==id);
		}
		public void Create(Card item) {
			if (_context.EntityCards.Any(x => x.Id == item.Id))
				throw new Exception(); // TODO display on webpage eror
			_context.EntityCards.Add(item);
		}
		public void Update(Card item) {
			_context.EntityCards.Update(item);
		}
		public void Delete(int id) {
			_context.EntityCards.Remove(Get(id));
		}
	}
}