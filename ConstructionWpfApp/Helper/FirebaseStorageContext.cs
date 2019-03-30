// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FireBaseStorageContext.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the FireBaseStorageContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// Singleton Pattern

// ReSharper disable StyleCop.SA1214
namespace ConstructionWpfApp.Helper
{
    using ConstructionWpfApp.GoogleCloudStorageLibrary;
    using ConstructionWpfApp.Properties;

    /// <summary>
    /// The fire base storage context.
    /// </summary>
    public class FireBaseStorageContext
    {
        /// <summary>
        /// The API key.
        /// </summary>
        private static string apiKey = "AIzaSyBUJAUantLj-avPjzyUlB6pXw5sYy3FktM";

        /// <summary>
        /// The authentication email.
        /// </summary>
        private static string authenticationEmail = "hello@gmail.com";

        /// <summary>
        /// The authentication password.
        /// </summary>
        private static string authenticationPassword = "helloworld";

        /// <summary>
        /// The fire base storage.
        /// </summary>
        private static readonly FireBaseStorageLibrary FireBaseStorage =
            new FireBaseStorageLibrary(Resources.ProjectId, apiKey, authenticationEmail, authenticationPassword);

        /// <summary>
        /// Prevents a default instance of the <see cref="FireBaseStorageContext"/> class from being created.
        /// </summary>
        private FireBaseStorageContext()
        {
        }

        /// <summary>
        /// The get fire base storage library.
        /// </summary>
        /// <returns>
        /// The <see cref="FireBaseStorageLibrary"/>.
        /// </returns>
        public static FireBaseStorageLibrary GetFireBaseStorageLibrary()
        {
            return FireBaseStorage;
        }

        /// <summary>
        /// The set authentication.
        /// </summary>
        /// <param name="setApiKey">
        /// The API key.
        /// </param>
        /// <param name="authEmail">
        /// The authentication email.
        /// </param>
        /// <param name="authPassword">
        /// The authentication password.
        /// </param>
        public static void SetAuthentication(string setApiKey, string authEmail, string authPassword)
        {
            apiKey = setApiKey;
            authenticationEmail = authEmail;
            authenticationPassword = authPassword;
        }
    }
}
