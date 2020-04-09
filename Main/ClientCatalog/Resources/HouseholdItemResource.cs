using System;

namespace Main.ClientCatalog.Resources
{
    // TODO - Convert to Hal resource with links
    /// <summary>
    /// Describes the Business model for a household insurable item
    /// </summary>
    public class HouseholdItemResource
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