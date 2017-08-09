using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VisualTAF.Exceptions
{
    /// <summary>
    /// Represents exceptions that are thrown when an error occurs during actions.
    /// </summary>
    [Serializable]
    public class ImageException : Exception
    {
        public ImageException()
        {
        }

        public ImageException(string message)
            : base(message)
        {
        }

        public ImageException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected ImageException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
