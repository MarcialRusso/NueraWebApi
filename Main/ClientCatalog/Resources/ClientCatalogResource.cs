using System.Collections.Generic;
using System.Linq;

namespace Main.ClientCatalog.Resources
{
    // TODO - Convert to Hal resource with embedded & links
    /// <summary>
    /// Describes the Business model for a client's household insurable items with total monetary value count.
    /// </summary>
    public class ClientCatalogResource
    {
        public List<HouseholdItemsResource> HouseholdItems { get; set; }

        /// <summary>
        /// The household items total value
        /// </summary>
        public int TotalValue { get; set; }
    }
}