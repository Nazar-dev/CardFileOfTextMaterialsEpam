using System.Collections.Generic;
using CardFileOfTextMaterialsEpam.DAL.Entities;

namespace CardFileOfTextMaterialsEpam.BL.Models {
	public class CardModel:Entity {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public ICollection<int> BooksIds { get; set; }
    }
}