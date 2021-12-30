using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class User:IEntity {
		[Key]
		[ForeignKey(nameof(CardId))]
		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Surname { get; set; }
		public int CardId { get; set; }
		
		public List<Card> Cards { get; set; }
	}
}