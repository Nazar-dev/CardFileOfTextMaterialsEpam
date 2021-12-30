using System.Threading.Tasks;
using CardFileOfTextMaterialsEpam.DAL.Interfaces;
using CardFileOfTextMaterialsEpam.DAL.Repositories;

namespace CardFileOfTextMaterialsEpam.DAL {
	public class UnitOfWork:IUnitOfWork {
		private readonly CardFileDbContext _context;
		
		private BookRepository _bookRepository;
		
		private CardRepository _cardRepository;
		
		private CategoryRepository _categoryRepository;
		
		private UserRepository _userRepository;
		
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

		public IUserRepository UserRepository
		{
			get
			{
				this._userRepository ??= new UserRepository(_context);
				return _userRepository;
			}
		}
		
		public async Task<int> SaveAsync() {
			return await _context.SaveChangesAsync();
		}
	}
}