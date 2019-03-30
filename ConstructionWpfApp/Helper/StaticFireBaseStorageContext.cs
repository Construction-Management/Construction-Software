// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StaticFireBaseStorageContext.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the StaticFireBaseStorageContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Helper
{
    using ConstructionWpfApp.GoogleCloudStorageLibrary;

    /// <summary>
    /// The static fire base storage context.
    /// </summary>
    public static class StaticFireBaseStorageContext
    {
        /// <summary>
        /// Gets or sets the fire base storage library.
        /// </summary>
        public static FireBaseStorageLibrary FireBaseStorageLibrary { get; set; }
    }
}
