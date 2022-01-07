using System.Threading.Tasks;

namespace CardFileOfTextMaterialsEpam.DAL.Interfaces {
	public interface IUnitOfWork {
		IBookRepository BookRepository { get; }

		ICardRepository CardRepository { get; }
		ICategoryRepository CategoryRepository { get; }
		IPersonRepository PersonRepository { get; }
		Task<int> SaveAsync();
	}
}