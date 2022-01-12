using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CardFileOfTextMaterialsEpam.DAL.Entities.Auth;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Person {

        [Key] 
        public int PersonId { get; set; }
        [ForeignKey(nameof(CardId))] 
        public string Email { get; set; }
        public virtual User User { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
	}
}