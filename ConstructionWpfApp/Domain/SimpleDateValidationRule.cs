// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleDateValidationRule.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the SimpleDateValidationRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain
{
    using System;
    using System.Globalization;
    using System.Windows.Controls;

    /// <inheritdoc />
    /// <summary>
    /// The simple date validation rule.
    /// </summary>
    public class SimpleDateValidationRule : ValidationRule
    {
        /// <summary>
        /// The validate.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="cultureInfo">
        /// The culture info.
        /// </param>
        /// <returns>
        /// The <see cref="ValidationResult"/>.
        /// </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return DateTime.TryParse(
                       (value ?? string.Empty).ToString(),
                       CultureInfo.CurrentCulture,
                       DateTimeStyles.AssumeLocal | DateTimeStyles.AllowWhiteSpaces,
                       out var time)
                       ? ValidationResult.ValidResult
                       : new ValidationResult(false, "Invalid date");
        }
    }
}