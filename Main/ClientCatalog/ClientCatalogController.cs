using System;
using System.Linq;
using System.Threading.Tasks;
using Main.ClientCatalog.Requests;
using Main.ClientCatalog.Resources;
using Main.Domain.ClientCatalog.Models;
using Main.Domain.ClientCatalog.Queries;
using Main.Domain.HouseholdItems.Commands;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Main.ClientCatalog
{
    // TODO - Implement Swagger open API and the route is missing a main domain (Client, Estimator, etc)
    // ie. api/clients/{clientId}/catalogs/{catalogId}
    [ApiController]    
    [Route("api/client-catalog")]
    public class ClientCatalogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ClientCatalogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [EnableCors]
        [HttpGet]
        public async Task<ClientCatalogResource> GetCatalogAsync()
        {
            var model = await _mediator.Send(new ClientCatalogQuery());

            return ToResource(model);
        }

        // TODO
        // - Document endpoints
        // - Move the next two calls to its own controller and create sub-domains
        //   Also they should return a HouseholdItemResource but to get app completion return the catalog
        //   The FE should be concerned with retrieving the catalog after performing one of these actions.
        [EnableCors]
        [HttpPost]        
        public async Task<ClientCatalogResource> AddHouseholdItem(AddHouseholdItemRequest item)
        {
            var command = new AddHouseholdItemForClientCommand(item.Name, item.Value, item.Category);
            await _mediator.Send(command);

            return await GetCatalogAsync();
        }

        [EnableCors]
        [HttpDelete, Route("{householdItemId}")]        
        public async Task<ClientCatalogResource> RemoveClientHouseholdItem(Guid householdItemId)
        {
            var command = new RemoveClientHouseholdItemCommand(householdItemId);
            await _mediator.Send(command);

            return await GetCatalogAsync();
        }

        // There is enough logic here to maybe justify using a factory
        private ClientCatalogResource ToResource(ClientCatalogModel model)
        {
            return new ClientCatalogResource
            {
                TotalValue = model.TotalValue,
                HouseholdItems = model.HouseholdItems.Select(catalogItems => new HouseholdItemsResource
                {
                    Category = catalogItems.Category,
                    TotalValue = catalogItems.TotalValue,
                    Items = catalogItems.Items.Select(i => new HouseholdItemResource
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Category = i.Category,
                        Value = i.Value
                    }).ToList()
                }).ToList()
            };
        }
    }
}
