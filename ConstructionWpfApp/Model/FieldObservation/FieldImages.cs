// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldImages.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the FieldImages type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Model.FieldObservation
{
    using System;

    using Google.Cloud.Firestore;

    /// <summary>
    /// The field images.
    /// </summary>
    [FirestoreData]
    public class FieldImages
    {
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [FirestoreProperty("title")]
        public string Title { get; set; }
        
        /// <summary>
        /// Gets or sets the download url.
        /// </summary>
        [FirestoreProperty("downloadUrl")]
        public string DownloadUrl { get; set; }

        /// <summary>
        /// Gets or sets the image capture time.
        /// </summary>
        [FirestoreProperty("imageCaptureTime")]
        public DateTime ImageCaptureTime { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [FirestoreProperty("description")]
        public string Description { get; set; }
    }
}
