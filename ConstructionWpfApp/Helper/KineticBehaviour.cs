// --------------------------------------------------------------------------------------------------------------------
// <copyright file="KineticBehaviour.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the KineticBehaviour type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

// ReSharper disable StyleCop.SA1201
// ReSharper disable StyleCop.SA1202
namespace ConstructionWpfApp.Helper
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Threading;

    /// <summary>
    /// The kinetic behavior.
    /// </summary>
    public class KineticBehaviour
    {
        #region Friction

        /// <summary>
        /// Friction Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty FrictionProperty = DependencyProperty.RegisterAttached(
            "Friction",
            typeof(double),
            typeof(KineticBehaviour),
            new FrameworkPropertyMetadata((double)0.95));

        /// <summary>
        /// Gets the Friction property.  This dependency property
        /// indicates ....
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <returns>
        /// The <see cref="double"/>.
        /// </returns>
        public static double GetFriction(DependencyObject d)
        {
            return (double)d.GetValue(FrictionProperty);
        }

        /// <summary>
        /// Sets the Friction property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SetFriction(DependencyObject d, double value)
        {
            d.SetValue(FrictionProperty, value);
        }

        #endregion

        #region ScrollStartPoint

        /// <summary>
        /// ScrollStartPoint Attached Dependency Property
        /// </summary>
        private static readonly DependencyProperty ScrollStartPointProperty = DependencyProperty.RegisterAttached(
            "ScrollStartPoint",
            typeof(Point),
            typeof(KineticBehaviour),
            new FrameworkPropertyMetadata((Point)new Point()));

        /// <summary>
        /// Gets the ScrollStartPoint property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        private static Point GetScrollStartPoint(DependencyObject d)
        {
            return (Point)d.GetValue(ScrollStartPointProperty);
        }

        /// <summary>
        /// Sets the ScrollStartPoint property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private static void SetScrollStartPoint(DependencyObject d, Point value)
        {
            d.SetValue(ScrollStartPointProperty, value);
        }

        #endregion

        #region ScrollStartOffset

        /// <summary>
        /// ScrollStartOffset Attached Dependency Property
        /// </summary>
        private static readonly DependencyProperty ScrollStartOffsetProperty = DependencyProperty.RegisterAttached(
            "ScrollStartOffset",
            typeof(Point),
            typeof(KineticBehaviour),
            new FrameworkPropertyMetadata((Point)new Point()));

        /// <summary>
        /// Gets the ScrollStartOffset property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <returns>
        /// The <see cref="Point"/>.
        /// </returns>
        private static Point GetScrollStartOffset(DependencyObject d)
        {
            return (Point)d.GetValue(ScrollStartOffsetProperty);
        }

        /// <summary>
        /// Sets the ScrollStartOffset property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private static void SetScrollStartOffset(DependencyObject d, Point value)
        {
            d.SetValue(ScrollStartOffsetProperty, value);
        }

        #endregion

        #region InertiaProcessor

        /// <summary>
        /// InertiaProcessor Attached Dependency Property
        /// </summary>
        private static readonly DependencyProperty InertiaProcessorProperty = DependencyProperty.RegisterAttached(
            "InertiaProcessor",
            typeof(InertiaHandler),
            typeof(KineticBehaviour),
            new FrameworkPropertyMetadata((InertiaHandler)null));

        /// <summary>
        /// Gets the InertiaProcessor property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <returns>
        /// The <see cref="InertiaHandler"/>.
        /// </returns>
        private static InertiaHandler GetInertiaProcessor(DependencyObject d)
        {
            return (InertiaHandler)d.GetValue(InertiaProcessorProperty);
        }

        /// <summary>
        /// Sets the InertiaProcessor property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        private static void SetInertiaProcessor(DependencyObject d, InertiaHandler value)
        {
            d.SetValue(InertiaProcessorProperty, value);
        }

        #endregion

        #region HandleKineticScrolling

        /// <summary>
        /// HandleKineticScrolling Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty HandleKineticScrollingProperty = DependencyProperty.RegisterAttached(
            "HandleKineticScrolling",
            typeof(bool),
            typeof(KineticBehaviour),
            new FrameworkPropertyMetadata((bool)false, new PropertyChangedCallback(OnHandleKineticScrollingChanged)));

        /// <summary>
        /// Gets the HandleKineticScrolling property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool GetHandleKineticScrolling(DependencyObject d)
        {
            return (bool)d.GetValue(HandleKineticScrollingProperty);
        }

        /// <summary>
        /// Sets the HandleKineticScrolling property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        public static void SetHandleKineticScrolling(DependencyObject d, bool value)
        {
            d.SetValue(HandleKineticScrollingProperty, value);
        }

        /// <summary>
        /// Handles changes to the HandleKineticScrolling property.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnHandleKineticScrollingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollable = d as ScrollViewer;
            if ((bool)e.NewValue)
            {
                if (scrollable != null)
                {
                    scrollable.PreviewMouseDown += OnPreviewMouseDown;
                    scrollable.PreviewMouseMove += OnPreviewMouseMove;
                    scrollable.PreviewMouseUp += OnPreviewMouseUp;
                    SetInertiaProcessor(scrollable, new InertiaHandler(scrollable));
                }
            }
            else
            {
                if (scrollable != null)
                {
                    scrollable.PreviewMouseDown -= OnPreviewMouseDown;
                    scrollable.PreviewMouseMove -= OnPreviewMouseMove;
                    scrollable.PreviewMouseUp -= OnPreviewMouseUp;
                    var inertia = GetInertiaProcessor(scrollable);
                    inertia?.Dispose();
                }
            }
        }

        #endregion

        #region Mouse Events

        /// <summary>
        /// The on preview mouse down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            if (scrollViewer.IsMouseOver)
            {
                // Save starting point, used later when
                // determining how much to scroll.
                SetScrollStartPoint(scrollViewer, e.GetPosition(scrollViewer));
                SetScrollStartOffset(scrollViewer, new Point(scrollViewer.HorizontalOffset, scrollViewer.VerticalOffset));
                scrollViewer.CaptureMouse();
            }
        }

        /// <summary>
        /// The on preview mouse move.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnPreviewMouseMove(object sender, MouseEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            if (scrollViewer.IsMouseCaptured)
            {
                var currentPoint = e.GetPosition(scrollViewer);

                var scrollStartPoint = GetScrollStartPoint(scrollViewer);

                // Determine the new amount to scroll.
                var delta = new Point(scrollStartPoint.X - currentPoint.X, scrollStartPoint.Y - currentPoint.Y);

                var scrollStartOffset = GetScrollStartOffset(scrollViewer);
                var scrollTarget = new Point(scrollStartOffset.X + delta.X, scrollStartOffset.Y + delta.Y);

                var inertiaProcessor = GetInertiaProcessor(scrollViewer);
                if (inertiaProcessor != null)
                {
                    inertiaProcessor.ScrollTarget = scrollTarget;
                }

                // Scroll to the new position.
                scrollViewer.ScrollToHorizontalOffset(scrollTarget.X);
                scrollViewer.ScrollToVerticalOffset(scrollTarget.Y);
            }
        }

        /// <summary>
        /// The on preview mouse up.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnPreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            var scrollViewer = (ScrollViewer)sender;
            if (scrollViewer.IsMouseCaptured)
            {
                scrollViewer.ReleaseMouseCapture();
            }
        }

        #endregion

        #region Inertia Stuff

        /// <inheritdoc />
        /// <summary>
        /// Handles the inertia
        /// </summary>
        public class InertiaHandler : IDisposable
        {
            /// <summary>
            /// The previous point.
            /// </summary>
            private Point previousPoint;

            /// <summary>
            /// The velocity.
            /// </summary>
            private Vector velocity;

            /// <summary>
            /// The scrollable.
            /// </summary>
            private ScrollViewer scrollable;

            /// <summary>
            /// The animation timer.
            /// </summary>
            private DispatcherTimer animationTimer;

            /// <summary>
            /// The scroll target.
            /// </summary>
            private Point scrollTarget;

            /// <summary>
            /// Gets or sets the scroll target.
            /// </summary>
            public Point ScrollTarget
            {
                get => this.scrollTarget;
                set => this.scrollTarget = value;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="InertiaHandler"/> class.
            /// </summary>
            /// <param name="scrollable">
            /// The scrollable.
            /// </param>
            public InertiaHandler(ScrollViewer scrollable)
            {
                this.scrollable = scrollable;
                this.animationTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 0, 0, 20) };
                this.animationTimer.Tick +=
                    new EventHandler(this.HandleWorldTimerTick);
                this.animationTimer.Start();
            }

            /// <summary>
            /// The handle world timer tick.
            /// </summary>
            /// <param name="sender">
            /// The sender.
            /// </param>
            /// <param name="e">
            /// The e.
            /// </param>
            private void HandleWorldTimerTick(object sender, EventArgs e)
            {
                if (this.scrollable.IsMouseCaptured)
                {
                    var currentPoint = Mouse.GetPosition(this.scrollable);
                    this.velocity = this.previousPoint - currentPoint;
                    this.previousPoint = currentPoint;
                }
                else
                {
                    if (this.velocity.Length > 1)
                    {
                        this.scrollable.ScrollToHorizontalOffset(
                            this.ScrollTarget.X);
                        this.scrollable.ScrollToVerticalOffset(
                            this.ScrollTarget.Y);
                        this.scrollTarget.X += this.velocity.X;
                        this.scrollTarget.Y += this.velocity.Y;
                        this.velocity *=
                            KineticBehaviour.GetFriction(this.scrollable);
                    }
                }
            }

            #region IDisposable Members

            /// <inheritdoc />
            /// <summary>
            /// The dispose.
            /// </summary>
            public void Dispose()
            {
                this.animationTimer.Stop();
            }

            #endregion
        }

        #endregion
    }
}