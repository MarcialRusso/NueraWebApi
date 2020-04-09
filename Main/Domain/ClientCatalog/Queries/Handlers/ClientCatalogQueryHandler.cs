using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Main.Domain.ClientCatalog.Models;
using Main.Domain.HouseholdItems.Models;
using MediatR;

namespace Main.Domain.ClientCatalog.Queries.Handlers
{
    // TODO - Replace IRequestHandler with an abstraction layer (eg: IQueryHandler)
    public class ClientCatalogQueryHandler : IRequestHandler<ClientCatalogQuery, ClientCatalogModel>
    {
        private readonly INueraContext _context;

        public ClientCatalogQueryHandler(INueraContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves a client's catalog
        /// </summary>
        /// <remarks>
        /// Check performance since we are pulling all objects at once
        /// If performance is bad then improve by:
        /// 1. Using pagination
        /// 2. Improve query performance by implementing a more complex LINQ query(ie. let x ... ) 
        /// 3. Instead of the model calculating the total value, provide it from the query
        ///
        /// Due to issues with EF core Group By query needs .AsEnumerable() and also it may not be async
        /// for more info see: https://github.com/dotnet/efcore/issues/17068
        /// and https://stackoverflow.com/questions/58916542/converting-ef-core-queries-from-2-2-to-3-0-async-await/58920736#58920736
        /// </remarks>
        public Task<ClientCatalogModel> Handle(ClientCatalogQuery request, CancellationToken cancellationToken)
        {            
            var householdItems = _context.HouseholdItems
                .Select(h => new HouseholdItemModel
                { 
                    Id = h.Id,
                    Category = h.Category,
                    Name = h.Name,
                    Value = h.Value
                })
                .AsEnumerable()
                .GroupBy(h => h.Category)
                .Select(i => new HouseholdItemsModel
                {
                    Category = i.First().Category,
                    Items = i.Select(s => s).ToList()
                })
                .OrderBy(h => h.Category)
                .ToList();
            
            var catalog = new ClientCatalogModel
            {
                HouseholdItems = householdItems
            };

            return Task.FromResult(catalog);
        }
    }
}