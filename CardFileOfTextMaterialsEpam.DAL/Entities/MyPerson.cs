using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class MyPerson:Entity {
        [ForeignKey(nameof(CardId))]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CardId { get; set; }
        public ICollection<Card> Cards { get; set; }
	}
}