using System.ComponentModel.DataAnnotations;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Category:IEntity { 
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }
	}
}