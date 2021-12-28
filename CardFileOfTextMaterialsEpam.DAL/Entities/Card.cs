using CardFileOfTextMaterialsEpam.DAL.Enums;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Card:IEntity {

		public int Id { get; set; }
		public Category Category { get; set; }
	}
}