using System;
using System.Runtime.Serialization;
using System.Xml;

namespace ClouDeveloper.OpenAPI.KolisNet.Search
{
    /// <summary>
    /// KolisSearchException
    /// </summary>
    [Serializable]
    public class KolisSearchException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KolisSearchException"/> class.
        /// </summary>
        /// <param name="doc">The document.</param>
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

        /// <summary>
        /// Initializes a new instance of the <see cref="KolisSearchException"/> class.
        /// </summary>
        /// <param name="info">throw되는 예외에 대해 serialize된 개체 데이터를 보유하는 <see cref="T:System.Runtime.Serialization.SerializationInfo" />입니다.</param>
        /// <param name="context">소스 또는 대상에 대한 컨텍스트 정보를 포함하는 <see cref="T:System.Runtime.Serialization.StreamingContext" />입니다.</param>
        protected KolisSearchException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.message = info.GetString("errorMessage");
            this.success = info.GetString("success");
        }

        /// <summary>
        /// The message
        /// </summary>
        private readonly string message;
        /// <summary>
        /// The success
        /// </summary>
        private readonly string success;

        /// <summary>
        /// 현재 예외를 설명하는 메시지를 가져옵니다.
        /// </summary>
        public override string Message
        {
            get { return this.message; }
        }

        /// <summary>
        /// Gets the success.
        /// </summary>
        /// <value>
        /// The success.
        /// </value>
        public string Success
        {
            get { return this.success; }
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
            info.AddValue("success", this.success);
        }
    }
}
