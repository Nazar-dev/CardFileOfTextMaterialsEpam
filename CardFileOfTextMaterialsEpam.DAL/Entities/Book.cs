using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Book:IEntity {
		[Key]
		[ForeignKey(nameof(CategoryId))]
		
		public int Id { get; set; }
		
		public string BookName { get; set; }
		
		public int CategoryId { get; set; }
	}
}