using System.Threading.Tasks;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;
using CardFileOfTextMaterialsEpam.DAL.Repositories;

namespace CardFileOfTextMaterialsEpam.DAL {
	public class UnitOfWork:IUnitOfWork {
		private readonly CardFileDbContext _context;
		
		private IBookRepository _bookRepository;
		
		private ICardRepository _cardRepository;
		
		private ICategoryRepository _categoryRepository;
		
		
		public UnitOfWork(CardFileDbContext context) {
			_context = context;
		}

		public IBookRepository BookRepository
		{
			get
			{
				this._bookRepository ??= new BookRepository(_context);
				return _bookRepository;
			}
			
			
		}

		public ICardRepository CardRepository
		{
			get
			{
				this._cardRepository ??= new CardRepository(_context);
				return _cardRepository;
			}
			
		}

		public ICategoryRepository CategoryRepository
		{
			get
			{
				this._categoryRepository ??= new CategoryRepository(_context);
				return _categoryRepository;
			}
		}


		
		public async Task<int> SaveAsync() {
			return await _context.SaveChangesAsync();
		}
	}
}