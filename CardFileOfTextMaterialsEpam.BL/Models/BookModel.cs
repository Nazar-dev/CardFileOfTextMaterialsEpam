using System;
using System.Collections.Generic;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Models
{
    public class BookModel:Entity
    {
        public string BookName { get; set; }
        public int CardId { get; set; }
        public int CategoryId { get; set; }
    }
}
