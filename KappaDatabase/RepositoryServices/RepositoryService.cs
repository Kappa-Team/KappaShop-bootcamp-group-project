﻿using KappaDatabase.Database;
using KappaDatabase.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace KappaDatabase.RepositoryServices
{
    /// <summary>
    /// Used for handling CRUD operations to the database. Generic class.
    /// </summary>
    /// <typeparam name="TEntity">A <see cref="IEntity"/> type.</typeparam>
    public class RepositoryService<TEntity> : IRepositoryService<TEntity>
        where TEntity : IEntity
    {
        protected readonly ShopContext db;

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryService{TEntity}" class/>.
        /// Opens a new connection with the database.
        /// </summary>
        public RepositoryService() => db = new ShopContext();

        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryService{TEntity}" class/>.
        /// </summary>
        /// <param name="db">An instance of the database.</param>
        public RepositoryService(ShopContext db) => this.db = db;
        
        public DbSet Set { get => db.Set(typeof(TEntity)); }

        public virtual TEntity Get(int id) => (TEntity)Set.Find(id);

        public virtual IEnumerable<TEntity> GetAll() => (IEnumerable<TEntity>)Set;

        public virtual void Add(TEntity entity)
        {
            Set.Add(entity);
            db.SaveChanges();
        }

        public virtual bool Update(TEntity newEntity)
        {
            int id = newEntity.Id;
            object oldEntity = Get(id);

            if (oldEntity is null)
            {
                return false;
            }
            oldEntity = newEntity;
            db.SaveChanges();
            return true;
        }

        public virtual bool Delete(int id)
        {
            object entity = Get(id);

            if (entity is null)
            {
                return false;
            }
            Set.Remove(entity);
            db.SaveChanges();
            return true;
        }
        public virtual bool Delete(TEntity entity) => Delete(entity.Id);
    }
}