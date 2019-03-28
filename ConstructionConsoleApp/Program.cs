// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Program.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the Program type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionConsoleApp
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Firebase.Auth;
    using Firebase.Storage;

    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Storage.v1.Data;
    using Google.Cloud.Firestore;
    using Google.Cloud.Firestore.V1;
    using Google.Cloud.Storage.V1;

    using Grpc.Auth;

    using Channel = Grpc.Core.Channel;

    /// <summary>
    /// The program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The api key.
        /// </summary>
        private static string ApiKey = "AIzaSyBUJAUantLj-avPjzyUlB6pXw5sYy3FktM";
        private static string AuthEmail = "hello@gmail.com";
        private static string AuthPassword = "helloworld";

        /// <summary>
        /// The main.
        /// </summary>
        /// <param name="args">
        /// The args.
        /// </param>
        public static void Main(string[] args)
        {
            UploadAsync().Wait();
        }

        /// <summary>
        /// The google task.
        /// </summary>
        /// <param name="clientId">
        /// The client id.
        /// </param>
        /// <param name="clientSecret">
        /// The client secret.
        /// </param>
        /// <param name="projectName">
        /// The project name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task GoogleTaskAsync(string clientId, string clientSecret, string projectName)
        {
            var clientSecrets = new ClientSecrets { ClientId = clientId, ClientSecret = clientSecret };

            // there are different scopes, which you can find here https://cloud.google.com/storage/docs/authentication
            var scopes = new[] { @"https://www.googleapis.com/auth/devstorage.full_control" };

            var cts = new CancellationTokenSource();
            var userCredential = await GoogleWebAuthorizationBroker
                                     .AuthorizeAsync(clientSecrets, scopes, "uselessgroup2k18@gmail.com", cts.Token)
                                     .ConfigureAwait(false);

            await userCredential.RefreshTokenAsync(cts.Token).ConfigureAwait(false);

            var service = new Google.Apis.Storage.v1.StorageService();

            var newBucket = new Google.Apis.Storage.v1.Data.Bucket()
                                {
                                    Name = "hello"
                                };

            var newBucketQuery = service.Buckets.Insert(newBucket, projectName);
            newBucketQuery.OauthToken = userCredential.Token.AccessToken;

            // you probably want to wrap this into try..catch block
            await newBucketQuery.ExecuteAsync(cts.Token).ConfigureAwait(false);

            var bucketsQuery = service.Buckets.List(projectName);
            bucketsQuery.OauthToken = userCredential.Token.AccessToken;
            var buckets = await bucketsQuery.ExecuteAsync(cts.Token).ConfigureAwait(false);

            // enter bucket name to which you want to upload file
            var bucketToUpload = buckets.Items.FirstOrDefault()?.Name;
            var newObject = new Google.Apis.Storage.v1.Data.Object()
                                {
                                    Bucket = bucketToUpload, Name = "some-file-" + new Random().Next(1, 666)
                                };

            FileStream fileStream = null;
            try
            {
                var dir = Directory.GetCurrentDirectory();
                var path = Path.Combine(dir, "images.png");
                fileStream = new FileStream(path, FileMode.Open);
                var uploadRequest = new Google.Apis.Storage.v1.ObjectsResource.InsertMediaUpload(
                                        service,
                                        newObject,
                                        bucketToUpload,
                                        fileStream,
                                        "image/png") { OauthToken = userCredential.Token.AccessToken };
                await uploadRequest.UploadAsync(cts.Token).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                fileStream?.Dispose();
            }
        }

        /// <summary>
        /// The upload async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task UploadAsync()
        {
            // Google Cloud Platform project ID.
            const string projectId = "photoupload-aebca";

            // The name for the new bucket.
            const string bucketName = projectId + ".appspot.com";

            // Path to the file to upload
            const string filePath = @"download.png";

            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword).ConfigureAwait(false);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            using (var fileStream = new FileStream(filePath, FileMode.Open))
            {
                var task = new FirebaseStorage(
                        bucketName,
                        new FirebaseStorageOptions
                            {
                                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                            })
                    .Child("uploads")
                    .Child("1553457134780.jpg")
                    .GetDownloadUrlAsync();

                // task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                // cancel the upload
                // cancellation.Cancel();
                try
                {
                    // error during upload will be thrown when you await the task
                    Console.WriteLine("Download link:\n" + await task);
                    // task.Wait(cancellation.Token);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception was thrown: {0}", ex);
                }
            }
        }
    }
}
