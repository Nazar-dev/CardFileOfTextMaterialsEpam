using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardFileOfTextMaterialsEpam.DAL.Entities;

namespace CardFileOfTextMaterialsEpam.BL.Models {
	public class CardModel {
        [Key]
        public int CardId { get; set; }
        [ForeignKey(nameof(BookId))]
        public int BookId { get; set; }
    }
}