// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingModuleViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the BillingModuleViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.ViewModel.BillingModule.Windows
{
    using System;
    using System.Windows;

    using ConstructionWpfApp.Domain;
    using ConstructionWpfApp.Helper;
    using ConstructionWpfApp.Properties;
    using ConstructionWpfApp.View.BillingModule.UserControls;
    using ConstructionWpfApp.ViewModel.BillingModule.UserControls;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// The billing module view model.
    /// </summary>
    public class BillingModuleViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BillingModuleViewModel"/> class.
        /// </summary>
        /// <param name="snackBarMessageQueue">
        /// The snack bar message queue.
        /// </param>
        public BillingModuleViewModel([NotNull] ISnackbarMessageQueue snackBarMessageQueue)
        {
            if (snackBarMessageQueue == null)
            {
                throw new ArgumentNullException(nameof(snackBarMessageQueue));
            }

            this.DemoItems = new[]
                                 {
                                     new DemoItem("Home", new Home()),
                                     new DemoItem(
                                         "Field Observation Report",
                                         new FieldObservationReport { DataContext = new FieldObservationViewModel() }),
                                     new DemoItem("Add Field Observation Report", new AddFieldObservationReport())
                                 };

            try
            {
                StaticFireBaseStorageContext.FireBaseStorageLibrary = FireBaseStorageContext.GetFireBaseStorageLibrary();
                StaticDbContext.ConnectFireStore = FireStoreDbContext.GetInstance();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Application.Current.Shutdown(-1);
            }
        }

        /// <summary>
        /// Gets or sets the demo items.
        /// </summary>
        public DemoItem[] DemoItems { get; set; }
    }
}
