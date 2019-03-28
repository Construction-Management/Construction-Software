// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AnotherCommandImplementation.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   No WPF project is complete without it's own version of this.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain
{
    using System;
    using System.Windows.Input;

    using ConstructionWpfApp.Properties;

    /// <inheritdoc />
    /// <summary>
    /// No WPF project is complete without it's own version of this.
    /// </summary>
    public class AnotherCommandImplementation : ICommand
    {
        /// <summary>
        /// The execute.
        /// </summary>
        [NotNull]
        private readonly Action<object> execute;

        /// <summary>
        /// The can execute.
        /// </summary>
        [NotNull]
        private readonly Func<object, bool> canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="AnotherCommandImplementation"/> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        public AnotherCommandImplementation([CanBeNull] Action<object> execute) : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AnotherCommandImplementation"/> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        /// <param name="canExecute">
        /// The can execute.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// thrown if Argument Null Exception
        /// </exception>
        public AnotherCommandImplementation([NotNull] Action<object> execute, [CanBeNull] Func<object, bool> canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute ?? (x => true);
        }

        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;

            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanExecute(object parameter) => this.canExecute(parameter);

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter) => this.execute(parameter);

        /// <summary>
        /// The refresh.
        /// </summary>
        public void Refresh() => CommandManager.InvalidateRequerySuggested();
    }
}
