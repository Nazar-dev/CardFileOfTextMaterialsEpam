using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Book:Entity {
		
        public string BookName { get; set; }
        public int CardId { get; set; }	
        public int CategoryId { get; set; }
        public Card Card { get; set; }
        public Category Category { get; set; }
	}
}