using Altkom.DotnetCore.Fakers;
using Altkom.DotnetCore.IRepositories;
using Altkom.DotnetCore.Models;

namespace Altkom.DotnetCore.FakeRepositories
{
    public class FakeProductRepository : FakeEntityRepository<Product>, IProductRepository
    {
        public FakeProductRepository(ProductFaker entityFaker) : base(entityFaker)
        {
        }
    }
}
