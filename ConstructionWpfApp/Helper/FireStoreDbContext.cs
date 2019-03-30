// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FireStoreDbContext.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the FireStoreDbContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// Singleton Pattern Used

namespace ConstructionWpfApp.Helper
{
    using ConstructionWpfApp.GoogleCloudFireStoreLibrary;
    using ConstructionWpfApp.Properties;

    /// <summary>
    /// The fire store DB context.
    /// </summary>
    public class FireStoreDbContext
    {
        /// <summary>
        /// The connect fire store.
        /// </summary>
        private static readonly ConnectFireStore ConnectFireStore = new ConnectFireStore(Resources.ProjectId, Resources.JsonPath);

        /// <summary>
        /// Prevents a default instance of the <see cref="FireStoreDbContext"/> class from being created.
        /// </summary>
        private FireStoreDbContext()
        {
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <returns>
        /// The <see cref="GoogleCloudFireStoreLibrary.ConnectFireStore"/>.
        /// </returns>
        public static ConnectFireStore GetInstance()
        {
            return ConnectFireStore;
        }
    }
}
