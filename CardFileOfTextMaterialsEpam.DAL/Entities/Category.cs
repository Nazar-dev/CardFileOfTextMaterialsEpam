using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Category:Entity { 
		public string Name { get; set; }
        public ICollection<Book> BookCollection { get; set; }
	}
}