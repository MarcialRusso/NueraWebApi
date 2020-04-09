using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using MediatR;

namespace Main.Domain.HouseholdItems.Commands.Handlers
{
    public class RemoveClientHouseholdItemCommandHandler : AsyncRequestHandler<RemoveClientHouseholdItemCommand>
    {
        private readonly IHouseholdItemRepository _householdItemRepository;

        public RemoveClientHouseholdItemCommandHandler(IHouseholdItemRepository householdItemRepository)
        {
            _householdItemRepository = householdItemRepository;
        }

        protected async override Task Handle(RemoveClientHouseholdItemCommand request, CancellationToken cancellationToken)
        {
            // Note here an Event could be raised to update a user's Total Value if it was persisted.
            // Persistence of Total Value would also have a greater performance than calculating at run time.

            // Another option is to have a ClientCatalogDomainModel exposing AddItem and RemoveItem
            // then it may raise events or calculate internally the Total Value

            await _householdItemRepository.DeleteAsync(request.HouseholdItemId);

            await _householdItemRepository.SaveAsync();
        }
    }
}