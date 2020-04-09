using System;

namespace Main.Domain.HouseholdItems.Models
{
    /// <summary>
    /// Describes the Business model for a household insurable item
    /// </summary>
    public class HouseholdItemModel
    {
        /// <summary>
        /// The household item identifier
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The household item name
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The household item value
        /// </summary>
        /// <remarks>
        /// Value must be a positive value
        /// </remarks>
        public int Value { get; set; }
        
        /// <summary>
        /// The household item category
        /// </summary>
        public string Category { get; set; }
    }
}