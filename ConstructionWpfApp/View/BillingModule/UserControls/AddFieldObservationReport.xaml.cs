// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddFieldObservationReport.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for AddFieldObservationReport.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.View.BillingModule.UserControls
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    using ConstructionWpfApp.GoogleCloudStorageLibrary;
    using ConstructionWpfApp.Helper;
    using ConstructionWpfApp.Model.FieldObservation;

    using Google.Cloud.Firestore;

    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for AddFieldObservationReport.XAML
    /// </summary>
    public partial class AddFieldObservationReport : UserControl
    {
        /// <summary>
        /// The filled counter.
        /// </summary>
        private int filledCounter;
        
        /// <summary>
        /// The api key.
        /// </summary>
        private static string ApiKey = "AIzaSyBUJAUantLj-avPjzyUlB6pXw5sYy3FktM";
        private static string AuthEmail = "hello@gmail.com";
        private static string AuthPassword = "helloworld";

        /// <summary>
        /// The open file dialog.
        /// </summary>
        private OpenFileDialog openFileDialog;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ConstructionWpfApp.View.BillingModule.UserControls.AddFieldObservationReport" /> class.
        /// </summary>
        public AddFieldObservationReport()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// The button upload on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonSelectImageOnClick(object sender, RoutedEventArgs e)
        {
            this.openFileDialog = new OpenFileDialog
                                      {
                                          Title = "Select a picture",
                                          Filter = "All supported graphics|*.jpg;*.jpeg;*.png|"
                                                   + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                                                   + "Portable Network Graphic (*.png)|*.png"
                                      };

            if (this.openFileDialog.ShowDialog() == true)  
            {
                this.ImageToUpload.Source = new BitmapImage(new Uri(this.openFileDialog.FileName));
                this.filledCounter++;
            }
        }

        /// <summary>
        /// The button upload on click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ButtonUploadOnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.TextBoxImage.Text)
                || string.IsNullOrWhiteSpace(this.TextBoxDescription.Text)
                || this.ImageToUpload.Source == null)
            {
                MessageBox.Show("Please fill up all the fields!");
                return;
            }

            var image = new FieldImages
                            {
                                Description = this.TextBoxDescription.Text,
                                ImageCaptureTime = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                                Title = this.TextBoxImage.Text
                            };

            var fieldPerson = new FieldPerson
                                  {
                                      Email = AuthEmail,
                                      Id = "123344",
                                      Name = "Hello World",
                                      Images = image
                                  };

            var fireBaseStorage = new FireBaseStorageLibrary(
                Properties.Resources.ProjectId,
                ApiKey,
                AuthEmail,
                AuthPassword);
            var fireStoreDb = FireStoreDbContext.GetInstance();

            image.DownloadUrl = fireBaseStorage.AddImageAsync(this.openFileDialog.FileName, fieldPerson.Id).Result;

            fireStoreDb.AddCollectionDataAsync(fieldPerson, "Root", "Field Observers", "Field", "123344").Wait();
        }
    }
}
