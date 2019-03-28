// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PhoneAuthenticationHelper.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the PhoneAuthenticationHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Helper
{
    using ConstructionWpfApp.Properties;

    /// <summary>
    /// The phone authentication helper.
    /// </summary>
    public static class PhoneAuthenticationHelper
    {
        /// <summary>
        /// Gets or sets the flag.
        /// </summary>
        public static int Flag { get; set; }
        
        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        [CanBeNull]
        public static string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the OTP.
        /// </summary>
        [CanBeNull]
        public static string Otp { get; set; }
    }
}
