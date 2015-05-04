using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;

namespace ClouDeveloper.OpenAPI.TED.Search
{
    [Serializable]
    public class TEDSearchException : Exception
    {
        public TEDSearchException(XmlDocument doc)
            : base()
        {
            if (doc == null)
                this.message = "Unexpected error occurred.";

            this.message = doc.InnerText;
        }

        protected TEDSearchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.message = info.GetString("errorMessage");
        }

        private readonly string message;

        public override string Message
        {
            get { return this.message; }
        }
        
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("errorMessage", this.message);
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "{0}", this.message);
        }
    }
}
