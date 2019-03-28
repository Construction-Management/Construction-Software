// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SimpleDataTemplateSelector.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the SimpleDataTemplateSelector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// The simple data template selector.
    /// </summary>
    public class SimpleDataTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the fixed template.
        /// </summary>
        [CanBeNull]
        public DataTemplate FixedTemplate { get; set; }

        /// <summary>
        /// The select template.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <returns>
        /// The <see cref="DataTemplate"/>.
        /// </returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            return this.FixedTemplate;
        }
    }
}