using System;
using System.Collections.Generic;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Models
{
    public class JwtSettings
    {

            public string Issuer { get; set; }

            public string Secret { get; set; }

            public int ExpirationInDays { get; set; }
        
    }
}
