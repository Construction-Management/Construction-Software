// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExtendedVisualTreeHelper.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the ExtendedVisualTreeHelper type.
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
    public static class ExtendedVisualTreeHelper
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
        public static T GetVisualParent<T>([NotNull] object childObject)
            where T : Visual
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

        /// <summary>
        /// The find child.
        /// </summary>
        /// <param name="parent">
        /// The parent.
        /// </param>
        /// <param name="childName">
        /// The child name.
        /// </param>
        /// <typeparam name="T">
        /// T is type
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T FindChild<T>([CanBeNull] DependencyObject parent, [CanBeNull] string childName)
            where T : DependencyObject
        {    
            // Confirm parent and childName are valid. 
            if (parent == null)
            {
                return null;
            }

            T foundChild = null;

            var childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (var i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                // If the child is not of the request child type child
                if (!(child is T childType))
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null)
                    {
                        break;
                    }
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    // If the child's name is set for search
                    if (child is FrameworkElement frameworkElement && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            return foundChild;
        }

    }
}
