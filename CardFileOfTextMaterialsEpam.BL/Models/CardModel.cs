using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using CardFileOfTextMaterialsEpam.DAL.Entities;

namespace CardFileOfTextMaterialsEpam.BL.Models {
	public class CardModel:Entity {
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }
        public ICollection<int> BooksIds { get; set; }
    }
}