using System.Text;

namespace System.Waf.Foundation
{
    /// <summary>
    /// Extends the <see cref="StringBuilder"/> class with new methods.
    /// </summary>
    public static class StringBuilderExtensions
    {
        /// <summary>
        /// Appends the specified string in a new line or the first line when the <see cref="StringBuilder"/> was empty.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        /// <param name="value">The string to append.</param>
        /// <returns>A reference to this instance after the append operation has completed.</returns>
        /// <exception cref="ArgumentNullException">The argument stringBuilder must not be null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Enlarging the value of this instance would exceed System.Text.StringBuilder.MaxCapacity.</exception>
        public static StringBuilder AppendInNewLine(this StringBuilder stringBuilder, string value)
        {
            if (stringBuilder == null) { throw new ArgumentNullException("stringBuilder"); }

            if (stringBuilder.Length == 0)
            {
                stringBuilder.Append(value);
            }
            else
            {
                stringBuilder.Append(Environment.NewLine + value);
            }
            return stringBuilder;
        }
    }
}
