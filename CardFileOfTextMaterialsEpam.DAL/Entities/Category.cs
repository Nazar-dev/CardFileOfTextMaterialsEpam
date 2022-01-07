using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace CardFileOfTextMaterialsEpam.DAL.Entities {
	public class Category {
        public int CategoryId { get; set; }
		public string Name { get; set; }
	}
}