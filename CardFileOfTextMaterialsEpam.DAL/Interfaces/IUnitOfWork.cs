using System.Threading.Tasks;

namespace CardFileOfTextMaterialsEpam.DAL.Interfaces {
	public interface IUnitOfWork {
		IBookRepository BookRepository { get; }

		ICardRepository CardRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		IUserRepository UserRepository { get; }
		Task<int> SaveAsync();
	}
}