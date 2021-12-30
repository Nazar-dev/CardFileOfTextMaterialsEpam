﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Card:IEntity {
		[Key]
		[ForeignKey(nameof(BookId))]
		
		public int Id { get; set; }
		public int BookId { get; set; }
		
	}
}
