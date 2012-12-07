using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Waf.Foundation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace System.Waf.Presentation.Converters
{
    /// <summary>
    /// Value converter that converts a <see cref="ValidationError"/> collection to a multi-line string error message.
    /// </summary>
    [ValueConversion(typeof(IEnumerable<ValidationError>), typeof(string))]
    public sealed class ValidationErrorsConverter : IValueConverter
    {
        private static readonly ValidationErrorsConverter defaultInstance = new ValidationErrorsConverter();

        /// <summary>
        /// Gets the default instance of this converter.
        /// </summary>
        public static ValidationErrorsConverter Default { get { return defaultInstance; } }


        /// <summary>
        /// Converts a collection of <see cref="ValidationError"/> objects into a multi-line string of error messages.
        /// </summary>
        /// <param name="value">The collection of <see cref="ValidationError"/> objects.</param>
        /// <param name="targetType">The type of the binding target property. This parameter will be ignored.</param>
        /// <param name="parameter">The converter parameter to use. This parameter will be ignored.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A multi-line error message or an empty string when the collection contains no errors. If the value parameter is <c>null</c>
        /// or not of the type IEnumerable&lt;ValidationError&gt; this method returns <see cref="DependencyProperty.UnsetValue"/>.
        /// </returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IEnumerable<ValidationError> validationErrors = value as IEnumerable<ValidationError>;
            if (validationErrors != null)
            {
                StringBuilder errorMessage = new StringBuilder();
                foreach (ValidationError error in validationErrors)
                {
                    string errorString = error.ErrorContent as string;
                    if (!string.IsNullOrEmpty(errorString))
                    {
                        errorMessage.AppendInNewLine(errorString);
                    }
                }
                return errorMessage.ToString();
            }
            return DependencyProperty.UnsetValue;
        }

        /// <summary>
        /// This method is not supported and throws an exception when it is called.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>Nothing because this method throws an exception.</returns>
        /// <exception cref="NotSupportedException">Throws this exception when the method is called.</exception>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
