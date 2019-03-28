// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DemoItem.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the DemoItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain
{
    using System;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using ConstructionWpfApp.Properties;

    /// <summary>
    /// The demo item.
    /// </summary>
    public class DemoItem : INotifyPropertyChanged
    {
        /// <summary>
        /// The name.
        /// </summary>
        [CanBeNull]
        private string name;

        /// <summary>
        /// The content.
        /// </summary>
        [CanBeNull]
        private object content;

        /// <summary>
        /// The horizontal scroll bar visibility requirement.
        /// </summary>
        private ScrollBarVisibility horizontalScrollBarVisibilityRequirement;

        /// <summary>
        /// The vertical scroll bar visibility requirement.
        /// </summary>
        private ScrollBarVisibility verticalScrollBarVisibilityRequirement;

        /// <summary>
        /// The margin requirement.
        /// </summary>
        private Thickness marginRequirement = new Thickness(16);

        /// <summary>
        /// Initializes a new instance of the <see cref="DemoItem"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="content">
        /// The content.
        /// </param>
        public DemoItem([CanBeNull] string name, [CanBeNull] object content)
        {
            this.name = name;
            this.Content = content;
        }

        /// <summary>
        /// The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [CanBeNull]
        public string Name
        {
            get => this.name;
            set => this.MutateVerbose(ref this.name, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [CanBeNull]
        public object Content
        {
            get => this.content;
            set => this.MutateVerbose(ref this.content, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the horizontal scroll bar visibility requirement.
        /// </summary>
        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement
        {
            get => this.horizontalScrollBarVisibilityRequirement;
            set => this.MutateVerbose(ref this.horizontalScrollBarVisibilityRequirement, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the vertical scroll bar visibility requirement.
        /// </summary>
        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement
        {
            get => this.verticalScrollBarVisibilityRequirement;
            set => this.MutateVerbose(ref this.verticalScrollBarVisibilityRequirement, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// Gets or sets the margin requirement.
        /// </summary>
        public Thickness MarginRequirement
        {
            get => this.marginRequirement;
            set => this.MutateVerbose(ref this.marginRequirement, value, this.RaisePropertyChanged());
        }

        /// <summary>
        /// The raise property changed.
        /// </summary>
        /// <returns>
        /// The <see cref="Action"/>.
        /// </returns>
        [NotNull]
        private Action<PropertyChangedEventArgs> RaisePropertyChanged() =>
            args => this.PropertyChanged?.Invoke(this, args);
    }
}
