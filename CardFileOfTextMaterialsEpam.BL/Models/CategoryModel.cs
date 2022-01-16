using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Models
{
    public class CategoryModel
    {
        [Key] 
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
