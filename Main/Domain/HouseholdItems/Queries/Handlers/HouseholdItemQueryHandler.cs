using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Context;
using Main.Domain.HouseholdItems.Models;
using MediatR;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace Main.Domain.HouseholdItems.Queries.Handlers
{
    public class HouseholdItemQueryHandler : IRequestHandler<HouseholdItemQuery, HouseholdItemModel>
    {
        private readonly NueraContext _context;

        public HouseholdItemQueryHandler(NueraContext context)
        {
            _context = context;
        }

        async Task<HouseholdItemModel> IRequestHandler<HouseholdItemQuery, HouseholdItemModel>.Handle(HouseholdItemQuery request, CancellationToken cancellationToken)
        {
            var householdItem = await _context.HouseholdItems
                .Where(h => h.Id == request.HouseholdItemId)
                .Select(h => new HouseholdItemModel
                {
                    Name = h.Name,
                    Category = h.Category,
                    Value = h.Value
                }).FirstOrDefaultAsync();

            // TODO - Null reference is not really whats happening here,
            // implement a Nuera exception for EntityNotFoundException 
            if (householdItem == null) throw new NullReferenceException($"Household item {request.HouseholdItemId} was not found.");

            return householdItem;
        }
    }
}