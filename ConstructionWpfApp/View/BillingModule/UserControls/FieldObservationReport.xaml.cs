﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FieldObservationReport.xaml.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Interaction logic for FieldObservationReport.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.View.BillingModule.UserControls
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    using ConstructionWpfApp.Helper;

    using MahApps.Metro.Controls;
    using MahApps.Metro.IconPacks;

    /// <summary>
    /// Interaction logic for FieldObservationReport.XAML
    /// </summary>
    public partial class FieldObservationReport : UserControl
    {
        private static int counter = 0;
        
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ConstructionWpfApp.View.BillingModule.UserControls.FieldObservationReport" /> class.
        /// </summary>
        public FieldObservationReport()
        {
            this.InitializeComponent();

            try
            {
                this.ScrollViewer.Cursor = new Cursor(Path.Combine(Directory.GetCurrentDirectory(), "CustomHandCursor2.cur"));
            }
            catch
            {
                this.ScrollViewer.Cursor = Cursors.Hand;
            }

            // Add Tiles
            var tile1 = new Tile
                            {
                                Title = "Pallab Nag",
                                TiltFactor = 2,
                                MinHeight = 100,
                                MinWidth = 200,
                                Margin = new Thickness(3),
                                HorizontalAlignment = HorizontalAlignment.Left,
                                VerticalAlignment = VerticalAlignment.Top
                            };

            var grid2 = new Grid();
            var icon = new PackIconMaterial
                           {
                               Name = $"PackIconMaterial{++counter}",
                               MinWidth = 60,
                               MinHeight = 60,
                               Kind = PackIconMaterialKind.Windows,
                               SpinAutoReverse = true,
                               SpinDuration = 2
                           };
            grid2.Children.Add(icon);
            tile1.Content = grid2;

            tile1.MouseEnter += this.TileOnMouseEnter;
            tile1.MouseLeave += this.TileOnMouseLeave;
            tile1.Click += this.TileClick;

            this.StackPanelForTiles.Children.Add(tile1);
            /*
            this.StackPanelForTiles.Children.Add(new Tile());
            this.StackPanelForTiles.Children.Add(new Tile());
            this.StackPanelForTiles.Children.Add(new Tile());
            this.StackPanelForTiles.Children.Add(new Tile());
            this.StackPanelForTiles.Children.Add(new Tile());
            this.StackPanelForTiles.Children.Add(new Tile());
            this.StackPanelForTiles.Children.Add(new Tile());
            this.StackPanelForTiles.Children.Add(new Tile());*/
        }

        /// <summary>
        /// The tile click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TileClick(object sender, RoutedEventArgs e)
        {
            // var fieldPerson = new Fie
        }

        /// <summary>
        /// The tile on mouse enter.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TileOnMouseEnter(object sender, MouseEventArgs e)
        {
            var icon = ExtendedVisualTreeHelper.FindChild<PackIconMaterial>(this.Grid, $"PackIconMaterial{counter}");
            if (icon != null)
            {
                icon.Spin = true;
            }
        }

        /// <summary>
        /// The tile on mouse leave.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void TileOnMouseLeave(object sender, MouseEventArgs e)
        {
            var icon = ExtendedVisualTreeHelper.FindChild<PackIconMaterial>(this.Grid, "PackIconMaterial1");
            if (icon != null)
            {
                icon.Spin = false;
            }
        }
    }
}
