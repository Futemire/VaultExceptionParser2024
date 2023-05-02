namespace VaultExceptionParser2024
{
    using System.ComponentModel;

    internal class VaultCode : ICode
    {

        public VaultCode(int code, string name, string description)
        {
            Code = code;
            Name = name;
            Description = description;
        }

        #region enumeration

        /// <summary>
        /// The type of Code returned from Vault.
        /// </summary>
        public enum ECodeType
        {
            /// <summary>
            /// The Code is an Error returned from Vault.
            /// </summary>
            [FieldStringValue("Error")]
            Error,
            /// <summary>
            /// The code is related to a Restriction (Failed permission to do something in Vault).
            /// </summary>
            [FieldStringValue("Restriction")]
            Restriction
        }

        #endregion

        /// <summary>
        /// Vault Error Code.
        /// </summary>
        public int Code { get; }

        /// <summary>
        /// Vault Error Name.
        /// </summary>
        public string Name { get; } = string.Empty;

        /// <summary>
        /// Vault Error Description.
        /// </summary>
        public string Description { get; } = string.Empty ;

        /// <summary>
        /// The type of code, Error or Restriction.
        /// </summary>
        public ECodeType Type { get; }

        /// <summary>
        /// The Vault Year Version of the Error or Restriction code.
        /// </summary>
        public int Year { get; }

        public override string ToString()
        {
            return $"{Type.GetCodeTypeString()}: {Name} ({Code}) - {Description.EndWithPeriod()}";
        }

    }

    

}
