using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Models
{
    public class BookModel:Entity
    {
        [ForeignKey(nameof(CategoryId))]
        public string BookName { get; set; }
        public int CategoryId { get; set; }
    }
}
