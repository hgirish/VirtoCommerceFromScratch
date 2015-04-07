using System;
using CommerceClient;
using CommerceClient.Globalization;

namespace StoreWebApp.Models
{
    public class ItemAvailabilityModel
    {
        /// <summary>
        /// The _availability
        /// </summary>
        private ItemAvailability _availability;

        /// <summary>
        /// Initializes a new instance of the <see cref="ItemAvailabilityModel"/> class.
        /// </summary>
        /// <param name="availability">The availability.</param>
        public ItemAvailabilityModel(ItemAvailability availability)
        {
            _availability = availability;
        }


        /// <summary>
        /// Gets the availability string.
        /// </summary>
        /// <value>The availability string.</value>


        /// <summary>
        /// Gets the minimum quantity.
        /// </summary>
        /// <value>The minimum quantity.</value>
        public int MinQuantity
        {
            get { return (int)_availability.MinQuantity; }
        }

        /// <summary>
        /// Gets the maximum quantity.
        /// </summary>
        /// <value>The maximum quantity.</value>
        public int MaxQuantity
        {
            get { return (int)_availability.MaxQuantity; }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is available.
        /// </summary>
        /// <value><c>true</c> if this instance is available; otherwise, <c>false</c>.</value>
        public bool IsAvailable
        {
            get { return _availability.IsAvailable; }
        }
    }
}