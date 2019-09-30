using Altkom.DotnetCore.IRepositories;
using Altkom.DotnetCore.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.DotnetCore.FakeRepositories
{

    public class FakeEntityRepository<TEntity> : IEntityRepository<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ICollection<TEntity> entities;
        private readonly Faker<TEntity> entityFaker;

        public FakeEntityRepository(Faker<TEntity> entityFaker)
        {
            this.entityFaker = entityFaker;
            entities = entityFaker.Generate(100);
        }

        public virtual void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public virtual ICollection<TEntity> Get()
        {
            return entities.ToList();
        }

        public virtual TEntity Get(int id)
        {
            return entities.SingleOrDefault(e => e.Id == id);
        }

        public void Remove(int id)
        {
            entities.Remove(Get(id));
        }

        public virtual void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
