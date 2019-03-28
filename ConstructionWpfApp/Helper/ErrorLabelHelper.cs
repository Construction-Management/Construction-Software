// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorLabelHelper.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the ErrorLabelHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Helper
{
    /// <summary>
    /// The error label helper.
    /// </summary>
    public class ErrorLabelHelper
    {
        /// <summary>
        /// The counter.
        /// </summary>
        private static int counter;

        /// <summary>
        /// The check.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool Check()
        {
            counter++;
            return counter > 2;
        }

        /// <summary>
        /// The reset.
        /// </summary>
        public static void Reset() => counter = 0;
    }
}
