// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuItem.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the MenuItem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain.TreeView
{
    using System.Collections.ObjectModel;

    using ConstructionWpfApp.Properties;

    /// <summary>
    /// The menu item.
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        /// </summary>
        public MenuItem()
        {
            this.Items = new ObservableCollection<MenuItem>();
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [CanBeNull]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        [CanBeNull]
        public ObservableCollection<MenuItem> Items { get; set; }
    }
}