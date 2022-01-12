using System;
using System.Collections.Generic;
using System.Linq;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;
using CardFileOfTextMaterialsEpam.DAL.Validation;

namespace CardFileOfTextMaterialsEpam.DAL.Repositories {
	public class CardRepository:ICardRepository {
		private readonly CardFileDbContext _context;
		public CardRepository(CardFileDbContext context) {
			_context = context;
		}

		public IEnumerable<Card> GetAll() {
			return _context.ECards;
		}
		public Card Get(int id) {
			return _context.ECards.FirstOrDefault(x => x.CardId==id);
		}
		public void Create(Card item) {
			if (_context.ECards.Any(x => x.CardId == item.CardId))
				throw new RepositoryException(); 
			_context.ECards.Add(item);
		}
		public void Update(Card item) {
			_context.ECards.Update(item);
		}
		public void Delete(int id) {
			_context.ECards.Remove(Get(id));
		}
	}
}