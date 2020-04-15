using Main.Domain.Interfaces;
using System;

namespace Main.Domain.HouseholdItems.Commands
{
    /// <summary>
    /// Command to add a client's household item
    /// </summary>
    public class AddHouseholdItemForClientCommand : ICommand
    {
        public AddHouseholdItemForClientCommand(Guid id, string name, uint value, string category)
        {
            Id = id;
            Name = name;
            Value = value;
            Category = category;
        }

        /// <summary>
        /// The household item ID
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// The household item name
        /// </summary>
        public string Name { get; }
        
        /// <summary>
        /// The household item value
        /// </summary>
        /// <remarks>
        /// Value must be a positive value.
        /// </remarks>
        public uint Value { get; }
        
        /// <summary>
        /// The household item category
        /// </summary>
        public string Category { get; }
    }
}