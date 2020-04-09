using System.Collections.Generic;
using System.Linq;
using Main.Domain.HouseholdItems.Models;

namespace Main.Domain.ClientCatalog.Models
{
    /// <summary>
    /// Describes the Business model for a client's household insurable items with total monetary value count.
    /// </summary>
    public class ClientCatalogModel
    {
        public List<HouseholdItemsModel> HouseholdItems { get; set; }

        /// <summary>
        /// The household items total value
        /// </summary>
        public int TotalValue => HouseholdItems.Sum(h => h.TotalValue);
    }
}