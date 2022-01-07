using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Card {
		[Key] 
        public int CardId { get; set; }
		[ForeignKey(nameof(BookId))]
		public int BookId { get; set; }
        public Book Book { get; set; }
		
	}
}
