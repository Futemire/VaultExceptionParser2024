namespace System.ComponentModel
{
    /// <summary>
    /// Used to return a string value for enumerations decorated with this attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class FieldStringValueAttribute : Attribute
    {
        /// <summary>
        /// Returns the string value of the current enumeration.
        /// </summary>
        /// <param name="value"></param>
        public FieldStringValueAttribute(string value)
        {
            Value = value;
        }

        public virtual string Value { get; }
    }
}