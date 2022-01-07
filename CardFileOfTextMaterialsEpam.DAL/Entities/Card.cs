using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Card:Entity {
		[ForeignKey(nameof(BookId))]
		public int BookId { get; set; }
        public ICollection<Book> Books { get; set; }
		
	}
}
