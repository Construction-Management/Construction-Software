// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldPerson.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the FieldPerson type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Model.FieldObservation
{
    using Google.Cloud.Firestore;

    /// <summary>
    /// The field person.
    /// </summary>
    [FirestoreData]
    public class FieldPerson
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [FirestoreProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [FirestoreProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the images.
        /// </summary>
        [FirestoreProperty("images")]
        public FieldImages Images { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [FirestoreProperty("email")]
        public string Email { get; set; }
    }
}
