using System.Collections.Generic;
using System.Linq;

namespace Main.Domain.HouseholdItems.Models
{
    /// <summary>
    /// Describes the Business model for a household insurable items grouped by category
    /// with total monetary value count.
    /// </summary>
    public class HouseholdItemsModel
    {
        /// <summary>
        /// The household items category
        /// </summary>
        public string Category { get; set; } 

        /// <summary>
        /// The items on the category
        /// </summary>
        public List<HouseholdItemModel> Items { get; set; }

        /// <summary>
        /// The household items total value  
        /// </summary>
        public int TotalValue => Items.Sum(i => i.Value);
    }
}