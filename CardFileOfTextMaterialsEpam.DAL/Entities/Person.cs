using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Person {

        [Key] 
        public int PersonId { get; set; }
        [ForeignKey(nameof(CardId))]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
	}
}