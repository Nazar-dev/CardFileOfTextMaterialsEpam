using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CardFileOfTextMaterialsEpam.BL.Validation
{
    [Serializable]
    public class AuthorizationException:Exception
    {
        public AuthorizationException() { }

        public AuthorizationException(string message) { }
        protected AuthorizationException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
