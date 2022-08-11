using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RLHerrera.Business.Interfaces;
using RLHerrera.Business.Models;
using RLHerrera.Data.Context;

namespace RLHerrera.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly AppDbContext Db;
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(AppDbContext db)
        {
            Db = db;
            _dbSet = db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate) 
            => await _dbSet.AsNoTracking().Where(predicate).ToListAsync();

        public virtual async Task<TEntity> ObterPorId(Guid id) 
            => await _dbSet.FindAsync(id);

        public virtual async Task<List<TEntity>> ObterTodos() 
            => await _dbSet.ToListAsync();

        public virtual async Task Adicionar(TEntity entity)
        {
            _dbSet.Add(entity);
            await SaveChanges();
        }
        
        public virtual async Task Atualizar(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            _dbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }
       
        public async Task<int> SaveChanges() 
            => await Db.SaveChangesAsync();

        public void Dispose() => Db?.Dispose();
    }
}