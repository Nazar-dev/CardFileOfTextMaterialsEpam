using System;
using System.Collections.Generic;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class User:IEntity {

		public int Id { get; set; }
		
		public string Name { get; set; }
		
		public string Surname { get; set; }
		
		public List<Card> Cards { get; set; }
	}
}