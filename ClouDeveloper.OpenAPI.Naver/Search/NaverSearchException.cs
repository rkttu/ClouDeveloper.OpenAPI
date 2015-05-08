using System;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;

namespace ClouDeveloper.OpenAPI.Naver.Search
{
    /// <summary>
    /// NaverSearchException
    /// </summary>
    [Serializable]
    public class NaverSearchException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NaverSearchException"/> class.
        /// </summary>
        /// <param name="doc">The document.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="NaverSearchException"/> class.
        /// </summary>
        /// <param name="info">throw되는 예외에 대해 serialize된 개체 데이터를 보유하는 <see cref="T:System.Runtime.Serialization.SerializationInfo" />입니다.</param>
        /// <param name="context">소스 또는 대상에 대한 컨텍스트 정보를 포함하는 <see cref="T:System.Runtime.Serialization.StreamingContext" />입니다.</param>
        protected NaverSearchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.message = info.GetString("errorMessage");
            this.errorCode = info.GetString("errorCode");
        }

        /// <summary>
        /// The message
        /// </summary>
        private readonly string message;
        /// <summary>
        /// The error code
        /// </summary>
        private string errorCode;

        /// <summary>
        /// 현재 예외를 설명하는 메시지를 가져옵니다.
        /// </summary>
        public override string Message
        {
            get { return this.message; }
        }

        /// <summary>
        /// Gets the error code.
        /// </summary>
        /// <value>
        /// The error code.
        /// </value>
        public string ErrorCode
        {
            get { return this.errorCode; }
        }

        /// <summary>
        /// 파생 클래스에서 재정의될 때, 예외에 관한 정보를 <see cref="T:System.Runtime.Serialization.SerializationInfo" />에 설정합니다.
        /// </summary>
        /// <param name="info">throw되는 예외에 대해 serialize된 개체 데이터를 보유하는 <see cref="T:System.Runtime.Serialization.SerializationInfo" />입니다.</param>
        /// <param name="context">소스 또는 대상에 대한 컨텍스트 정보를 포함하는 <see cref="T:System.Runtime.Serialization.StreamingContext" />입니다.</param>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///   <IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("errorMessage", this.message);
            info.AddValue("errorCode", this.errorCode);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*" />
        /// </PermissionSet>
        public override string ToString()
        {
            return String.Format(CultureInfo.InvariantCulture, "[{0}] {1}", this.errorCode, this.message);
        }
    }
}
