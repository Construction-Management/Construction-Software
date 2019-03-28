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
    using ConstructionWpfApp.Domain;

    /// <summary>
    /// The billing module view model.
    /// </summary>
    public class BillingModuleViewModel
    {
        public BillingModuleViewModel()
        {
            
        }

        /// <summary>
        /// Gets or sets the demo items.
        /// </summary>
        public DemoItem[] DemoItems { get; set; }
    }
}
