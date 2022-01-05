using System;
using System.Collections.Generic;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Models
{
    public class CategoryModel:Entity
    {
        public string Name { get; set; }
        public ICollection<int> BookIds{ get; set; }
    }
}
