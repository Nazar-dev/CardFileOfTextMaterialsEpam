using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Book {
        [Key] 
        public int BookId { get; set; }   
		[ForeignKey(nameof(CategoryId))]
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
	}
}