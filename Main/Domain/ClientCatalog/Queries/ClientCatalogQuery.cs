using Main.Domain.ClientCatalog.Models;
using MediatR;

namespace Main.Domain.ClientCatalog.Queries
{
    /// <summary>
    /// Retrieves a client insurable household items catalog.
    /// </summary>
    public class ClientCatalogQuery : IRequest<ClientCatalogModel>
    {
    }
}