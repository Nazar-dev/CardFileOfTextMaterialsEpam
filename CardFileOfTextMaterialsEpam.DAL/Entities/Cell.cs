using System.Collections.Generic;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Cells :IEntity{

		public int Id { get; set; }

		public int AmountOfCards { get; set; }

		public List<Card> Cards { get; set; }
	}
}