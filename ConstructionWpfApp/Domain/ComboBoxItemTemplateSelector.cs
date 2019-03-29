// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComboBoxItemTemplateSelector.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the ComboBoxItemTemplateSelector type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    using ConstructionWpfApp.Helper;
    using ConstructionWpfApp.Properties;

    /// <summary>
    /// The combo box item template selector.
    /// </summary>
    public class ComboBoxItemTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Gets or sets the drop down template.
        /// </summary>
        [CanBeNull]
        public DataTemplate DropDownTemplate
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the selected template.
        /// </summary>
        [CanBeNull]
        public DataTemplate SelectedTemplate
        {
            get;
            set;
        }

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
            var comboBoxItem =
                ExtendedVisualTreeHelper.GetVisualParent<ComboBoxItem>(
                    container ?? throw new ArgumentNullException(nameof(container)));
            if (comboBoxItem != null)
            {
                return this.DropDownTemplate ?? throw new InvalidOperationException();
            }

            return this.SelectedTemplate ?? throw new InvalidOperationException();
        }
    }
}
