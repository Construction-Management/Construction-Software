// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectFireStore.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the ConnectFireStore type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable StyleCop.SA1202

namespace ConstructionWpfApp.GoogleCloudFireStoreLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ConstructionWpfApp.Properties;

    using Google.Apis.Auth.OAuth2;
    using Google.Cloud.Firestore;
    using Google.Cloud.Firestore.V1;

    using Grpc.Auth;
    using Grpc.Core;

    /// <summary>
    /// The connect fire store.
    /// </summary>
    public class ConnectFireStore
    {
        /// <summary>
        /// The fire store Database.
        /// </summary>
        [CanBeNull]
        private static FirestoreDb fireStoreDb;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectFireStore"/> class.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <param name="jsonPath">
        /// The JSON path.
        /// </param>
        /// <param name="databaseId">
        /// The database id.
        /// </param>
        public ConnectFireStore([NotNull] string projectId, [NotNull] string jsonPath, [NotNull] string databaseId = "(default)")
        {
            var googleCredential = GoogleCredential.FromFile(jsonPath);
            var channel = new Channel(
                FirestoreClient.DefaultEndpoint.Host,
                FirestoreClient.DefaultEndpoint.Port,
                googleCredential.ToChannelCredentials());
            var fireStoreClient = FirestoreClient.Create(channel);

            fireStoreDb = FirestoreDb.Create(projectId, fireStoreClient);
        }

        /// <summary>
        /// The string array to string.
        /// </summary>
        /// <param name="stringArray">
        /// The string array.
        /// </param>
        /// <param name="separator">
        /// The separator.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [NotNull]
        private static string StringArrayToString([NotNull] string[] stringArray, [NotNull] string separator)
        {
            if (stringArray == null)
            {
                throw new ArgumentNullException(nameof(stringArray));
            }

            if (separator == null)
            {
                throw new ArgumentNullException(nameof(separator));
            }

            return string.Join(separator, stringArray);
        }

        /// <summary>
        /// The get collection path.
        /// </summary>
        /// <param name="pathArray">
        /// The path array.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [NotNull]
        private static string GetCollectionPath([NotNull] string[] pathArray)
        {
            if (pathArray == null)
            {
                throw new ArgumentNullException(nameof(pathArray));
            }

            if (pathArray.Length > 1)
            {
                return (pathArray.Length % 2 != 0 ? StringArrayToString(pathArray, "/") : null)
                       ?? throw new InvalidOperationException();
            }

            return (pathArray.ToString().Contains("/") ? pathArray.ToString() : null)
                   ?? throw new InvalidOperationException();
        }

        /// <summary>
        /// The get document path.
        /// </summary>
        /// <param name="pathArray">
        /// The path array.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        [NotNull]
        private static string GetDocumentPath([NotNull] string[] pathArray)
        {
            if (pathArray == null)
            {
                throw new ArgumentNullException(nameof(pathArray));
            }

            if (pathArray.Length > 1)
            {
                return (pathArray.Length % 2 == 0 ? StringArrayToString(pathArray, "/") : null)
                       ?? throw new InvalidOperationException();
            }

            return (pathArray.ToString().Contains("/") ? pathArray.ToString() : null)
                   ?? throw new InvalidOperationException();
        }

        #region Add Data

        /// <summary>
        /// The add collection data async.
        /// </summary>
        /// <param name="dictionary">
        /// The dictionary.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task AddCollectionDataAsync(
            [NotNull] Dictionary<string, object> dictionary,
            [NotNull] params string[] name)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (fireStoreDb != null)
            {
                var documentReference = fireStoreDb.Document(GetDocumentPath(name));

                if (documentReference == null)
                {
                    return;
                }

                await documentReference.SetAsync(dictionary).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// The add collection data async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="TEntity">
        /// Entity maybe a Model Class
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task AddCollectionDataAsync<TEntity>([NotNull] TEntity entity, [NotNull] params string[] name)
            where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (fireStoreDb != null)
            {
                var documentReference = fireStoreDb.Document(GetDocumentPath(name));

                if (documentReference == null)
                {
                    return;
                }

                await documentReference.SetAsync(entity).ConfigureAwait(false);
            }
        }

        #endregion

        #region Add Or Update Data

        /// <summary>
        /// The add or update collection data async.
        /// </summary>
        /// <param name="dictionary">
        /// The dictionary.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task AddOrUpdateCollectionDataAsync(
            [NotNull] Dictionary<string, object> dictionary,
            [NotNull] params string[] name)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var documentReference = fireStoreDb?.Document(GetDocumentPath(name));

            if (documentReference != null)
            {
                await documentReference.SetAsync(dictionary, SetOptions.MergeAll).ConfigureAwait(false);
            }
        }

        /// <summary>
        /// The add or update collection data async.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="TEntity">
        /// Entity maybe a class of Model
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task AddOrUpdateCollectionDataAsync<TEntity>(
            [NotNull] TEntity entity,
            [NotNull] params string[] name)
            where TEntity : class
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var documentReference = fireStoreDb?.Document(GetDocumentPath(name));

            if (documentReference != null)
            {
                await documentReference.SetAsync(entity, SetOptions.MergeAll).ConfigureAwait(false);
            }
        }

        #endregion

        #region Update Data

        /// <summary>
        /// The update doc async.
        /// </summary>
        /// <param name="dictionary">
        /// The dictionary.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task UpdateDocAsync(
            [NotNull] IDictionary<string, object> dictionary,
            [NotNull] params string[] name)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException(nameof(dictionary));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var documentReference = fireStoreDb?.Document(GetDocumentPath(name));

            if (documentReference != null)
            {
                await documentReference.UpdateAsync(dictionary).ConfigureAwait(false);
            }
        }

        #endregion

        #region Get Data

        #region Get Collection Fields

        /// <summary>
        /// The get collection fields.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="TEntity">
        /// Entity maybe a class of Model
        /// </typeparam>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        [CanBeNull]
        public TEntity GetCollectionFields<TEntity>([NotNull] params string[] name)
            where TEntity : class
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var documentReference = fireStoreDb?.Document(GetDocumentPath(name));

            if (documentReference == null)
            {
                return null;
            }

            var snapshot = documentReference.GetSnapshotAsync().Result;

            return snapshot.Exists ? snapshot.ConvertTo<TEntity>() : null;
        }

        /// <summary>
        /// The get collection fields.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="Dictionary{TKey,TValue}"/>.
        /// </returns>
        [CanBeNull]
        public Dictionary<string, object> GetCollectionFields([NotNull] params string[] name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var documentReference = fireStoreDb?.Document(GetDocumentPath(name));

            if (documentReference == null)
            {
                return null;
            }

            var snapshot = documentReference.GetSnapshotAsync().Result;

            return snapshot.Exists ? snapshot.ToDictionary() : null;
        }

        #endregion

        #region Get All Document or Collection

        /// <summary>
        /// The get all document data.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        [CanBeNull]
        public List<Dictionary<string, object>> GetAllDocumentData([NotNull] params string[] name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var allCollectionsQuery = fireStoreDb?.Collection(GetCollectionPath(name));

            var allCollectionQuerySnapshot = allCollectionsQuery?.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot?.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Where(documentSnapshot => documentSnapshot.ToDictionary() != null)
                .Select(documentSnapshot => documentSnapshot.ToDictionary()).ToList();
        }

        /// <summary>
        /// The get all document data.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <typeparam name="TEntity">
        /// Entity maybe a class of Model
        /// </typeparam>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        [CanBeNull]
        public List<TEntity> GetAllDocumentData<TEntity>([NotNull] params string[] name) where TEntity : class
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var allCollectionsQuery = fireStoreDb?.Collection(GetCollectionPath(name));

            var allCollectionQuerySnapshot = allCollectionsQuery?.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot?.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Select(documentSnapshot => documentSnapshot.ConvertTo<TEntity>()).ToList();
        }

        /// <summary>
        /// The get all document id.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument Null Exception
        /// </exception>
        [CanBeNull]
        public List<string> GetAllDocumentId([NotNull] params string[] name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var allCollectionsQuery = fireStoreDb?.Collection(GetCollectionPath(name));

            var allCollectionQuerySnapshot = allCollectionsQuery?.GetSnapshotAsync().Result;

            return allCollectionQuerySnapshot?.Documents.Where(documentSnapshot => documentSnapshot.Exists)
                .Select(documentSnapshot => documentSnapshot.Id).ToList();
        }

        /// <summary>
        /// The get collections.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        [CanBeNull]
        public List<CollectionReference> GetCollections([NotNull] params string[] name)
        {
            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (fireStoreDb == null)
            {
                return null;
            }

            var documentReference = fireStoreDb.Document(GetDocumentPath(name));
            var collectionReference = new List<CollectionReference>();

            if (documentReference == null)
            {
                return null;
            }

            IList<CollectionReference> subCollections = documentReference.ListCollectionsAsync().ToList().Result;

            collectionReference.AddRange(subCollections);

            return collectionReference;
        }

        #endregion

        #endregion

        #region Query

        /// <summary>
        /// The find document.
        /// </summary>
        /// <param name="documentId">
        /// The document id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool FindDocument([NotNull] string documentId, [NotNull] params string[] name)
        {
            if (documentId == null)
            {
                throw new ArgumentNullException(nameof(documentId));
            }

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            var collectionReference = fireStoreDb?.Collection(GetCollectionPath(name));

            if (collectionReference == null)
            {
                return false;
            }

            var documentSnapshot = collectionReference.Document(documentId).GetSnapshotAsync().Result;

            return documentSnapshot.Exists;
        }

        #endregion
    }
}
