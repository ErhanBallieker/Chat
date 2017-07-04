using Chat.Data.Context;
using Chat.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ChatContext context;

        private IDbSet<T> entities;

        public Repository(ChatContext context)
        {
            this.context = context;
        }
        public int Count
        {
            get
            {
                return this.Table.Count();
            }
        }

        public IQueryable<T> TableAll
        {
            get
            {
                return this.Entities.AsQueryable();
            }
        }

        public IQueryable<T> Table
        {
            get
            {
                return this.Entities.Where(o => o.IsActive && !o.IsDeleted).AsQueryable();
            }
        }

        protected virtual IDbSet<T> Entities
        {
            get
            {
                return this.entities ?? (this.entities = this.context.Set<T>());
            }
        }

        public T GetById(int id)
        {
            return this.Entities.Where(o => o.Id == id && o.IsActive && !o.IsDeleted).First();
        }

        public T Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }

            entity.IsActive = true;
            entity.IsDeleted = false;
            entity.CreateDate = entity.CreateDate == default(DateTime) ? DateTime.Now.AddHours(2) : entity.CreateDate.AddHours(2);

            this.Entities.Add(entity);

            this.SaveChanges();

            return entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            var entry = context.Entry(entity);
            var key = (long)(entry.Entity as dynamic).Id;

            if (entry.State == EntityState.Detached || entry.State == EntityState.Modified)
            {
                var currentEntry = Entities.Find(key);
                if (currentEntry != null)
                {
                    var attachedEntry = context.Entry(currentEntry);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    Entities.Attach(entity);
                    entry.State = EntityState.Modified;
                }
            }

            this.SaveChanges();

            return entity;
        }

        public void Delete(int entityId)
        {
            var entity = this.Entities.Find(entityId);
            if (entity == null)
            {
                throw new ArgumentException("entityId");
            }

            entity.IsActive = false;
            entity.IsDeleted = true;
            entity.ModifiedDate = DateTime.Now.AddHours(3);

            this.SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                var msg = dbEx.EntityValidationErrors.Aggregate(string.Empty, (current1, validationErrors) => validationErrors.ValidationErrors.Aggregate(current1, (current, validationError) => current + (string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine)));
                var fail = new Exception(msg, dbEx);
                throw fail;
            }
        }
    }
}
