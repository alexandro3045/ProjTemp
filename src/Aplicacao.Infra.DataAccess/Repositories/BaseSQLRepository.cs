using Aplicacao.Domain.Interfaces.Repositories;
using Aplicacao.Domain.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Aplicacao.Infra.DataAccess.Repositories
{
    public abstract class BaseSQLRepository<T, Tid> : ISQLRepository<T, Tid> where T : TEntity<Tid>
    {
        private readonly DbContext _context;

        public BaseSQLRepository(DbContext context)
        {
            _context = context;
        }

        private async Task<T> SaveChanges(T item)
        {
            try
            { 
                _context.SaveChanges();
            }
            catch (ValidationException valExc) { Console.WriteLine(valExc.Message); }
           catch (DbUpdateException dbUpEx) { Console.WriteLine(dbUpEx.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }            

            return item;
        }

        public async Task<T> Create(T entity)
        {
            _context.Entry(entity).State = EntityState.Added;

            SaveChanges(_context.Set<T>().Add(entity).Entity);

            return entity;
        }

        public async Task Delete(T t)
        {
            _context.Entry(t).State = EntityState.Modified;

            SaveChanges(_context.Set<T>().Remove(t).Entity);
        }

        public async Task Delete(Tid id)
        {
            var entity = await this.ReadById(id);

            Delete(entity);
        }

        //TODO: paginacao
        public async Task<IEnumerable<T>> ReadAll()
        {
            IQueryable<T> result = _context.Set<T>();

            return await result.ToListAsync();
        }

        public async Task<T> ReadById(Tid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            SaveChanges(_context.Set<T>().Update(entity).Entity);

            return entity;
        }
    }
}