using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kessewa.Application.Shared.Models;
using Kessewa.Quiz.Domain.ViewModels;
using Kessewa.Quiz.Persistence.DatabaseContext;
using Kessewa.Quiz.Processors.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Kessewa.Quiz.Persistence.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private DbSet<T> _entities;
        protected readonly KessewaDbContext Context;

        public RepositoryBase(KessewaDbContext context)
        {
            Context = context;
        }

        public virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = Context.Set<T>();
                return _entities;
            }
        }

        public virtual IQueryable<T> Table => Entities;
        public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        public async Task<T> GetAsync(int id)
        {
            if (id <= 0) return null;
            var keyProperty = Context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
            return await GetBaseQuery().FirstOrDefaultAsync(e => EF.Property<int>(e, keyProperty.Name) == id);
        }

        public virtual IQueryable<T> GetBaseQuery()
        {
            return Entities;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await GetBaseQuery().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await GetBaseQuery().Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
        {
            return await GetBaseQuery().Where(predicate).ToListAsync(cancellationToken);
        }

        //public async Task<PaginatedList<T>> GetPage(PaginatedCommand paginated, CancellationToken cancellationToken)
        //{


        //    var whereQueryable = GetBaseQuery()
        //        .WhereIf(!string.IsNullOrEmpty(paginated.Search), GetSearchCondition(paginated.Search));

        //    var pagedModel = await whereQueryable.PageBy(x => paginated.Take, paginated)
        //        .ToListAsync(cancellationToken);

        //    var totalRecords = await whereQueryable.CountAsync(cancellationToken: cancellationToken);


        //    return new PaginatedList<T>(data: pagedModel,
        //        totalCount: totalRecords,
        //        currentPage: paginated.PageNumber,
        //        pageSize: paginated.PageSize);
        //}

        //public async Task<PaginatedList<T>> GetPage(PaginatedCommand paginated, IQueryable<T> query, CancellationToken cancellationToken)
        //{
        //    try
        //    {

        //        var whereQuerable = query
        //            .WhereIf(!string.IsNullOrEmpty(paginated.Search), GetSearchCondition(paginated.Search));

        //        var pagedModel = await whereQuerable.PageBy(x => paginated.Take, paginated)
        //            .ToListAsync(cancellationToken);

        //        var totalRecords = await whereQuerable.CountAsync(cancellationToken: cancellationToken);


        //        return new PaginatedList<T>(data: pagedModel,
        //            totalCount: totalRecords,
        //            currentPage: paginated.PageNumber,
        //            pageSize: paginated.PageSize);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }

        //}        

        public async Task InsertAsync(T entity, bool autoCommit = true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                await Entities.AddAsync(entity);
                if (autoCommit)
                    await Context.SaveChangesAsync();

            }
            catch (Exception ex) { throw ex; }
        }

        public async Task InsertAsync(IEnumerable<T> entities, bool autoCommit = true)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                foreach (var entity in entities)
                    await Entities.AddAsync(entity);
                if (autoCommit)
                    await Context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task InsertAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool autoCommit = true)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                await Entities.AddRangeAsync(entities, cancellationToken);
                if (autoCommit)
                    await Context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task UpdateAsync(T entity, bool autoCommit = true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Update(entity);
                if (autoCommit)
                    await Context.SaveChangesAsync();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken, bool autoCommit = true)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);
                if (autoCommit)
                    await Context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task DeleteAsync(int id, CancellationToken cancellationToken, bool autoCommit = true)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentNullException("id");

                var keyProperty = Context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties[0];
                var entity = await GetBaseQuery().FirstOrDefaultAsync(e => EF.Property<int>(e, keyProperty.Name) == id, cancellationToken);
                if (entity == null)
                    throw new ArgumentNullException("entity");

                Entities.Remove(entity);
                if (autoCommit)
                    await Context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex) { throw ex; }
        }

        //public Task SoftDeleteAsync(T entity, bool autoCommit = true)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task DeleteAsync(IEnumerable<T> entities, CancellationToken cancellationToken, bool autoCommit = true)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException("entities");

                Entities.RemoveRange(entities);
                if (autoCommit)

                    await Context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex) { throw ex; }
        }      
        
        public async Task CommitAsync()
        {
            await Context.SaveChangesAsync();
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await Context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> CountAsync()
        {
            return await Context.Set<T>().CountAsync();
        }

        public virtual async Task<List<Lookup>> GetLookupAsync()
        {

            return new List<Lookup>();
        }

    }
}
