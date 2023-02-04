namespace VaultExceptionParser2023
{

    public interface ICode
    {
        /// <summary>
        /// Vault Error Code.
        /// </summary>
        int Code { get; }

        /// <summary>
        /// Vault Error Description.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Vault Error Name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The Vault Year Version of the Error or Restriction code.
        /// </summary>
        int Year { get; }

    }

}
