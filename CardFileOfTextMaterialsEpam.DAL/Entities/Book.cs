using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Book:Entity {
		[ForeignKey(nameof(CategoryId))]
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
	}
}