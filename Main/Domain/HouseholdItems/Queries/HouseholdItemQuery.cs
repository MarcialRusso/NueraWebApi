using System;
using Main.Domain.HouseholdItems.Models;
using MediatR;

namespace Main.Domain.HouseholdItems.Queries
{
    /// <summary>
    /// Retrieves a household item by Id.
    /// </summary>
    public class HouseholdItemQuery : IRequest<HouseholdItemModel>
    {
        /// <summary>
        /// The household item identifier
        /// </summary>
        public Guid HouseholdItemId { get; set; }
    }
}