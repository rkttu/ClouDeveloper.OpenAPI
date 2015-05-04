using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    [Serializable]
    public class NaverSearchException : Exception
    {
        public NaverSearchException(XmlDocument doc)
            : base()
        {
            if (doc == null ||
                !String.Equals(doc.DocumentElement.Name, "error", StringComparison.OrdinalIgnoreCase))
                this.message = "Unexpected error occurred.";

            XmlNode node = null;

            if ((node = doc.SelectSingleNode("/error/message")) != null)
                this.message = node.InnerText;

            if ((node = doc.SelectSingleNode("/error/error_code")) != null)
                this.errorCode = node.InnerText;
        }

        protected NaverSearchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.message = info.GetString("errorMessage");
            this.errorCode = info.GetString("errorCode");
        }

        private readonly string message;
        private string errorCode;

        public override string Message
        {
            get { return this.message; }
        }

        public string ErrorCode
        {
            get { return this.errorCode; }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("errorMessage", this.message);
            info.AddValue("errorCode", this.errorCode);
        }

        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "[{0}] {1}", this.errorCode, this.message);
        }
    }
}
