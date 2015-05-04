using System;
using System.Runtime.Serialization;
using System.Xml;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    [Serializable]
    public class KolisSearchException : Exception
    {
        public KolisSearchException(XmlDocument doc)
            : base()
        {
            if (doc == null)
                this.message = "Unexpected error occurred.";

            XmlNode node = null;

            if ((node = doc.SelectSingleNode("/METADATA/ERR_INFO")) != null)
                this.message = node.InnerText;

            if ((node = doc.SelectSingleNode("/METADATA/SUCCESS")) != null)
                this.success = node.InnerText;
        }

        protected KolisSearchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.message = info.GetString("errorMessage");
            this.success = info.GetString("success");
        }

        private readonly string message;
        private readonly string success;

        public override string Message
        {
            get { return this.message; }
        }

        public string Success
        {
            get { return this.success; }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("errorMessage", this.message);
            info.AddValue("success", this.success);
        }
    }
}
