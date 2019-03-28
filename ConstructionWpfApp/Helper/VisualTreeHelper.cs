// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VisualTreeHelper.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the VisualTreeHelper type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Helper
{
    using System;
    using System.Windows;
    using System.Windows.Media;

    using ConstructionWpfApp.Properties;

    /// <summary>
    /// The visual tree helpers.
    /// </summary>
    public static class VisualTreeHelper
    {
        /// <summary>
        /// The get visual parent.
        /// </summary>
        /// <param name="childObject">
        /// The child object.
        /// </param>
        /// <typeparam name="T">
        /// T is entity
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        [CanBeNull]
        public static T GetVisualParent<T>([NotNull] object childObject) where T : Visual
        {
            if (childObject == null)
            {
                throw new ArgumentNullException(nameof(childObject));
            }

            var child = childObject as DependencyObject;

            while (child != null && !(child is T))
            {
                child = System.Windows.Media.VisualTreeHelper.GetParent(child);
            }

            return child as T;
        }
    }
}
