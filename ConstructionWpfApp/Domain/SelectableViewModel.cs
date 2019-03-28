// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectableViewModel.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the SelectableViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ConstructionWpfApp.Domain
{
    using System;

    /// <summary>
    /// The selectable view model.
    /// </summary>
    public class SelectableViewModel
    {
        /// <summary>
        /// The train no.
        /// </summary>
        [CanBeNull]
        private string trainNo;

        /// <summary>
        /// The train name.
        /// </summary>
        [CanBeNull]
        private string trainName;

        /// <summary>
        /// The source station.
        /// </summary>
        [CanBeNull]
        private string sourceStation;

        /// <summary>
        /// The destination station.
        /// </summary>
        [CanBeNull]
        private string destinationStation;

        /// <summary>
        /// Gets or sets the train no.
        /// </summary>
        [CanBeNull]
        public string TrainNo
        {
            get => this.trainNo;
            set
            {
                if (this.trainNo != null && this.trainNo == value)
                {
                    return;
                }

                this.trainNo = value;
            }
        }

        /// <summary>
        /// Gets or sets the train name.
        /// </summary>
        [CanBeNull]
        public string TrainName
        {
            get => this.trainName;
            set
            {
                if (string.Equals(this.trainName, value, StringComparison.Ordinal))
                {
                    return;
                }

                this.trainName = value;
            }
        }

        /// <summary>
        /// Gets or sets the source station.
        /// </summary>
        [CanBeNull]
        public string SourceStation
        {
            get => this.sourceStation;
            set
            {
                if (this.sourceStation != null && this.sourceStation == value)
                {
                    return;
                }

                this.sourceStation = value;
            }
        }

        /// <summary>
        /// Gets or sets the destination station.
        /// </summary>
        [CanBeNull]
        public string DestinationStation
        {
            get => this.destinationStation;
            set
            {
                if (value != null && this.destinationStation == value)
                {
                    return;
                }

                this.destinationStation = value;
            }
        }
    }
}