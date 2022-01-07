using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFileOfTextMaterialsEpam.BL.Models {
	public class MyPersonModel:Entity {
        [ForeignKey(nameof(CardId))]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int CardId { get; set; }
        public ICollection<int> CardIds { get; set; }
	}
}