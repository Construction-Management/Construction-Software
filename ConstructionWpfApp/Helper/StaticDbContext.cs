// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticDbContext.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the StaticDbContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Helper
{
    using ConstructionWpfApp.GoogleCloudFireStoreLibrary;

    /// <summary>
    /// The static DB context.
    /// </summary>
    public static class StaticDbContext
    {
        /// <summary>
        /// Gets or sets the fire store DB context.
        /// </summary>
        public static ConnectFireStore ConnectFireStore { get; set; }
    }
}
