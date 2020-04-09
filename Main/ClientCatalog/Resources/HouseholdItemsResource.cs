using System.Collections.Generic;
using System.Linq;

namespace Main.ClientCatalog.Resources
{
    // TODO - Convert to Hal resource with embedded & links
    /// <summary>
    /// Describes the Business model for a household insurable items grouped by category
    /// with total monetary value count.
    /// </summary>
    public class HouseholdItemsResource
    {
        /// <summary>
        /// The household items category
        /// </summary>
        public string Category { get; set; } 

        // TODO - Use Hal Resource to build each embedded Item
        /// <summary>
        /// The items on the category
        /// </summary>
        public List<HouseholdItemResource> Items { get; set; }

        /// <summary>
        /// The household items total value  
        /// </summary>
        public int TotalValue { get; set; }
    }
}