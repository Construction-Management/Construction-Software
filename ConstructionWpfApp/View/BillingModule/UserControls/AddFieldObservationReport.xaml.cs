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

    using Microsoft.Win32;

    /// <summary>
    /// Interaction logic for AddFieldObservationReport.XAML
    /// </summary>
    public partial class AddFieldObservationReport : UserControl
    {
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
        private void ButtonUploadOnClick(object sender, RoutedEventArgs e)
        {
            var op = new OpenFileDialog
                         {
                             Title = "Select a picture",
                             Filter = "All supported graphics|*.jpg;*.jpeg;*.png|"
                                      + "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|"
                                      + "Portable Network Graphic (*.png)|*.png"
                         };

            if (op.ShowDialog() == true)  
            {  
                this.ImageToUpload.Source = new BitmapImage(new Uri(op.FileName));  
            } 
        }
    }
}
