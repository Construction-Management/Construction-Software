// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotEmptyValidationRule.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the NotEmptyValidationRule type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain
{
    using System.Globalization;
    using System.Windows.Controls;

    using ConstructionWpfApp.Helper;

    /// <summary>
    /// The not empty validation rule.
    /// </summary>
    public class NotEmptyValidationRule : ValidationRule
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
            if (ErrorLabelHelper.Check())
            {
                return string.IsNullOrWhiteSpace((value ?? string.Empty).ToString())
                           ? new ValidationResult(false, "Field is required.")
                           : ValidationResult.ValidResult;
            }

            return ValidationResult.ValidResult;
        }
    }
}