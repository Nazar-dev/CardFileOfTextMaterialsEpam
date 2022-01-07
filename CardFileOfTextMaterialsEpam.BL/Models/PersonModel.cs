using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFileOfTextMaterialsEpam.BL.Models {
	public class PersonModel {
        [Key] 
        public int PersonId { get; set; }
        [ForeignKey(nameof(CardId))]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CardId { get; set; }


    }
}