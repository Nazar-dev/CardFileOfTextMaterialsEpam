using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Validation
{
    [Serializable]

    public class CardFileException:Exception
    {
        public CardFileException() { }

        public CardFileException(string message) { }
        protected CardFileException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
