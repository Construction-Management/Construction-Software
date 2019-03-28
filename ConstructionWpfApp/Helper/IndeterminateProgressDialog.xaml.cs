// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IndeterminateProgressDialog.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for IndeterminateProgressDialog.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Helper
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Threading;

    using ConstructionWpfApp.Properties;

    /// <summary>
    /// Interaction logic for Indeterminate Progress Dialog XAML
    /// </summary>
    public partial class IndeterminateProgressDialog : UserControl
    {
        /// <summary>
        /// The background worker.
        /// </summary>
        [NotNull]
        private static BackgroundWorker backgroundWorker = new BackgroundWorker();

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ConstructionWpfApp.Helper.IndeterminateProgressDialog" /> class.
        /// </summary>
        public IndeterminateProgressDialog()
        {
            this.InitializeComponent();
            this.ButtonOk.IsEnabled = false;
        }

        /// <summary>
        /// The background worker do work.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerDoWork([CanBeNull] object sender, [CanBeNull] DoWorkEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(
                DispatcherPriority.Normal,
                new Action(() => this.ProgressBar.Visibility = Visibility.Visible));
        }

        /// <summary>
        /// The background worker run worker completed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BackgroundWorkerRunWorkerCompleted([CanBeNull] object sender, [CanBeNull] RunWorkerCompletedEventArgs e)
        {
            this.ProgressBar.Visibility = Visibility.Collapsed;
            this.ButtonOk.IsEnabled = true;
        }
    }
}
