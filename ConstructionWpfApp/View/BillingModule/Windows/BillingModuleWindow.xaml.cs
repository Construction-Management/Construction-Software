// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BillingModuleWindow.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for BillingModuleWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.View.BillingModule.Windows
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls.Primitives;
    using System.Windows.Input;
    using System.Windows.Media;

    using ConstructionWpfApp.Properties;
    using ConstructionWpfApp.ViewModel.BillingModule.Windows;

    using MahApps.Metro.Controls;

    using MaterialDesignThemes.Wpf;

    /// <summary>
    /// Interaction logic for BillingModuleWindow.XAML
    /// </summary>
    public partial class BillingModuleWindow : MetroWindow
    {
        /// <summary>
        /// The snack-bar.
        /// </summary>
        [CanBeNull]
        private static Snackbar snackbar;
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ConstructionWpfApp.View.BillingModule.Windows.BillingModuleWindow" /> class.
        /// </summary>
        public BillingModuleWindow()
        {
            this.InitializeComponent();

            Task.Factory.StartNew(() => Thread.Sleep(2000)).ContinueWith(
                t => this.MainSnackbar.MessageQueue.Enqueue("Hello Admin"),
                TaskScheduler.FromCurrentSynchronizationContext());

            this.DataContext = new BillingModuleViewModel(this.MainSnackbar.MessageQueue);

            snackbar = this.MainSnackbar;
        }

        /// <summary>
        /// The UI element on preview mouse left button up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void UiElementOnPreviewMouseLeftButtonUp([NotNull] object sender, [NotNull] MouseButtonEventArgs e)
        {
            if (sender == null)
            {
                throw new ArgumentNullException(nameof(sender));
            }

            if (e == null)
            {
                throw new ArgumentNullException(nameof(e));
            }

            // until we had a StaysOpen to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar)
                {
                    return;
                }

                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            this.MenuToggleButton.IsChecked = false;
        }
    }
}
