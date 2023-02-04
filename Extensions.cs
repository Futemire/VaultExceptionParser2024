namespace VaultExceptionParser2023
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;

    public static class Extensions
    {

        /// <summary>
        /// Ensures that the specified string ends with a period (.) by adding one if it does not exist.
        /// </summary>
        /// <param name="str">String to ensure has a period at the end.</param>
        [DebuggerHidden]
        public static string EndWithPeriod(this string str)
        {
            return str.Trim().EndsWith(".") ? str : $"{str}.";
        }

        /// <summary>
        /// Gets the string representation of the Code Type enum value.
        /// </summary>
        /// <param name="field">Code Type Enum value to retrieve the string representation of.</param>
        [DebuggerHidden]
        public static string GetCodeTypeString(this Enum field)
        {
            FieldStringValueAttribute[] customAttributes = (FieldStringValueAttribute[])field.GetType().GetField(field.ToString()).GetCustomAttributes(typeof(FieldStringValueAttribute), false);
            return (customAttributes.Length != 0) ? customAttributes[0].Value : string.Empty;
        }

        /// <summary>
        /// Checks is a string is null or empty.
        /// </summary>
        /// <param name="Str">The string to check.</param>
        [DebuggerHidden]
        public static bool IsNullOrEmpty(this string Str)
        {
            if (Str == null | Str == string.Empty || Str?.Trim() == "")
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the collection is null or empty.
        /// </summary>
        /// <typeparam name="T">Collection Type.</typeparam>
        /// <param name="collection">Collection to check.</param>
        [DebuggerHidden]
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            return collection == null || collection.Count() == 0;
        }

    }
}
