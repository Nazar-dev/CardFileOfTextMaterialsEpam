using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CardFileOfTextMaterialsEpam.DAL.Validation
{
    [Serializable]
    public class RepositoryException:Exception
    {
        public RepositoryException() { }

        public RepositoryException(string message) { }
        protected RepositoryException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
