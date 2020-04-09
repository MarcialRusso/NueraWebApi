using System;
using Main.Domain.Interfaces;

namespace Main.Domain.HouseholdItems.Commands
{
    /// <summary>
    /// Command to remove a client's household item
    /// </summary>
    public class RemoveClientHouseholdItemCommand : ICommand
    {
        public RemoveClientHouseholdItemCommand(Guid householdItemId)
        {
            HouseholdItemId = householdItemId;
        }

        /// <summary>
        /// The household item identifier
        /// </summary>
        public Guid HouseholdItemId { get; }
    }
}