using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Validation
{
    [Serializable]

    public class CardFileExeption:Exception
    {
        public CardFileExeption() { }

        public CardFileExeption(string message) { }
        protected CardFileExeption(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
