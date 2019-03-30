﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FireBaseStorageLibrary.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The fire base storage library.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.GoogleCloudStorageLibrary
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;

    using Firebase.Auth;
    using Firebase.Storage;

    /// <summary>
    /// The fire base storage library.
    /// </summary>
    public class FireBaseStorageLibrary
    {
        private static string ProjectId;

        private static string BucketName;

        private static string ApiKey;

        private static string AuthEmail;

        private static string AuthPassword;

        /// <summary>
        /// Initializes a new instance of the <see cref="FireBaseStorageLibrary"/> class.
        /// </summary>
        /// <param name="projectId">
        /// The project id.
        /// </param>
        /// <param name="apiKey">
        /// The API key.
        /// </param>
        /// <param name="authEmail">
        /// The authentication email.
        /// </param>
        /// <param name="authPassword">
        /// The authentication password.
        /// </param>
        public FireBaseStorageLibrary(string projectId, string apiKey, string authEmail, string authPassword)
        {
            ProjectId = projectId;
            BucketName = ProjectId + ".appspot.com";
            ApiKey = apiKey;
            AuthEmail = authEmail;
            AuthPassword = authPassword;
        }

        /// <summary>
        /// The get download url async.
        /// </summary>
        /// <param name="filePath">
        ///     The file path.
        /// </param>
        /// <param name="folderName">
        ///     The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<string> GetDownloadUrlAsync(string filePath, string folderName = null)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword).ConfigureAwait(false);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();
            
            var task = new FirebaseStorage(
                    BucketName,
                    new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                        })
                .Child(folderName)
                .Child(filePath)
                .GetDownloadUrlAsync();

            // task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            // cancellation.Cancel();
            try
            {
                // error during upload will be thrown when you await the task
                return await task.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception was thrown: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// The add image async.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<string> AddImageAsync(string filePath, string folderName = null)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword).ConfigureAwait(false);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                var task = new FirebaseStorage(
                        BucketName,
                        new FirebaseStorageOptions
                            {
                                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                                ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                            })
                    .Child(folderName)
                    .Child(filePath)
                    .PutAsync(fileStream, cancellation.Token);

                // task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

                // cancel the upload
                // cancellation.Cancel();
                try
                {
                    // error during upload will be thrown when you await the task
                    return await task;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Exception was thrown: {ex.Message}");
                    return null;
                }
            }
        }

        /// <summary>
        /// The add image async.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="folderName">
        /// The folder name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task DeleteImageAsync(string filePath, string folderName = null)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword).ConfigureAwait(false);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var task = new FirebaseStorage(
                    BucketName,
                    new FirebaseStorageOptions
                        {
                            AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                            ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                        })
                .Child(folderName)
                .Child(filePath)
                .DeleteAsync();

            // task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            // cancellation.Cancel();
            try
            {
                // error during upload will be thrown when you await the task
                task.Wait(cancellation.Token);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception was thrown: {ex.Message}");
            }
        }
    }
}
