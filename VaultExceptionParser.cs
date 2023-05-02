namespace VaultExceptionParser2024
{
    using Autodesk.Connectivity.WebServices;

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Resources;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The Vault Exception Parser helps to parse Vault Errors and Restrictions from generic numbers to the actual message found in the 
    /// Server Errors and Restrictions tables listed in the API documentation.
    /// </summary>
    public static class VaultExceptionParser
    {

        /// <summary>
        /// Gets the lists from the internal resources and loads them into dictionaries accessible to the application.
        /// </summary>
        static VaultExceptionParser()
        {
            LoadInternalCodeLists();
        }

        #region Properties

        /// <summary>
        /// List of code lists separated by year version.
        /// </summary>
        public static List<(int yearVersion, string listName)> CodeLists = new List<(int yearVersion, string listName)>();

        /// <summary>
        /// The Vault Year Version of Error and Restriction codes to return.
        /// </summary>
        public static int VaultYear { get; private set; } = -1;

        /// <summary>
        /// Error codes from Server Error Codes table in Vault API documentation for the current version.
        /// </summary>
        public static Dictionary<int, ICode> VaultErrorCodes = new Dictionary<int, ICode>();

        /// <summary>
        /// Error codes from Restriction Codes table in Vault API documentation for the current version.
        /// </summary>
        public static Dictionary<int, ICode> VaultRestrictionCodes = new Dictionary<int, ICode>();

        #endregion

        /// <summary>
        /// Gets the list from the assembly resource stream.
        /// </summary>
        private static void LoadInternalCodeLists()
        {
            /* Only load is we haven't already. */
            if(CodeLists.Count > 0) { return; }

            /* Get the list of coed files from the resource. */
            ResourceSet resources = Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true);
            foreach (DictionaryEntry resource in resources)
            {
                /* Grab first 4 chars from resource name to get the year. Ex: 2024ErrorCodes.txt*/
                bool paresed = int.TryParse(resource.Key.ToString().Substring(0, 4), out int year);
                if (!paresed) { continue; }
                VaultYear = year;
                CodeLists.Add((year, (string)resource.Key));
            }

            /* Load the codes into their respective dictionaries. */
            CodeLists.ForEach(l => LoadCodes(l.listName));
        }

        /// <summary>
        /// Loads all of the applications codes specified in the Application Codes resource file into a dictionary for easy access.<para/>
        /// </summary>
        private static void LoadCodes(string resourceName)
        {
            /* Extracts code from string. */
            Regex codeRegex = new Regex("^\\d*[ +|\\t]");
            /* Extracts error name. */
            Regex erroName = new Regex("(?!\\d*[ +|\\t])(\\w*){1}");

            string code, currCodeLine, desc, name, prevCodeLine = string.Empty;
            VaultCode eCode;

            /* Get the resource */
            string resource = Properties.Resources.ResourceManager.GetString(resourceName);
            using (StringReader reader = new StringReader(resource))
            {
                while ((currCodeLine = reader.ReadLine()) != null)
                {
                    string eLine = currCodeLine.Trim();

                    if (eLine.StartsWith("#")) { continue; }

                    if (codeRegex.IsMatch(eLine))
                    {
                        if (prevCodeLine != string.Empty)
                        {
                            /* Since the current currCodeLine starts with a codeRegex we can publish the previous one. */
                            /* Get the Code */
                            code = codeRegex.Match(prevCodeLine).Value;

                            /* Get the Error Name */
                            name = erroName.Match(prevCodeLine).Value;
                            if (name.IsNullOrEmpty()) { name = "Unused"; }

                            /* Get the Error Description*/
                            desc = prevCodeLine.Replace(code, "").Replace(name, "").Trim();

                            eCode = new VaultCode(int.Parse(code), name, desc);

                            if (resourceName.Contains("RestrictionCodes"))
                            {
                                VaultRestrictionCodes.Add(int.Parse(code), eCode);
                            }
                            else
                            {
                                VaultErrorCodes.Add(int.Parse(code), eCode);
                            }
                        }
                        prevCodeLine = currCodeLine.Trim();
                    }
                    else
                    {
                        /* Since the currCodeLine didn't begin with a codeRegex due to a currCodeLine break we should append it to the prevCodeLine. */
                        prevCodeLine += $"\n{eLine}";
                    }

                }

                /* Publish that last error code. */
                /* Get the Code */
                code = codeRegex.Match(prevCodeLine).Value;

                /* Get the Error Name */
                name = erroName.Match(prevCodeLine).Value;
                if (name.IsNullOrEmpty()) { name = "Unused"; }

                /* Get the Error Description*/
                desc = prevCodeLine.Replace(code, "").Replace(name, "");

                eCode = new VaultCode(int.Parse(code), name, desc);

                if (resourceName.Contains("RestrictionCodes"))
                {
                    VaultRestrictionCodes.Add(int.Parse(code), eCode);
                }
                else
                {
                    VaultErrorCodes.Add(int.Parse(code), eCode);
                }
            }
        }

        /// <summary>
        /// Try to extract Vault Specific Error or Restriction codes from a general Exception.
        /// If Vault specific information cannot be returned then the original Exception is returned.
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="PareseError"></param>
        /// <returns></returns>
        public static Exception ParseVaultException(this Exception ex)
        {
            try
            {
                if (ex.GetType() == typeof(VaultServiceErrorException))
                {
                    /* Try to cast the Exception to the correct type. */
                    VaultServiceErrorException ve = (VaultServiceErrorException)ex;

                    /* See if we have restrictions or error. */
                    if (!ve.Restrictions.IsNullOrEmpty())
                    {
                        StringBuilder resMsgs = new StringBuilder("Restrictions have occurred:");

                        foreach (VaultServiceErrorException.Restriction res in ve.Restrictions)
                        {
                            if (VaultRestrictionCodes.ContainsKey(res.Code))
                            {
                                resMsgs.AppendLine(VaultRestrictionCodes[res.Code].ToString());
                            }
                            else
                            {
                                resMsgs.AppendLine($"Restriction code ({res.Code}) description not found.");
                            }
                        }

                        /* Return the concatenated restrictions message. */
                        return new Exception(resMsgs.ToString(), ex);
                    }

                    /* Return the general Vault Exception message. */
                    string errorMsg = VaultErrorCodes[ve.ErrorCode].ToString();
                    return new Exception(errorMsg.ToString(), ex);
                }

                /* Something didn't work so just return the original exception. */
                return ex;
            }
            catch
            {
                /* Not a Vault specific exception so just return the original exception. */
                return ex;
            }

        }
    }

}
