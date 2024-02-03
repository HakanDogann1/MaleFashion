using MaleFashion.DataAccessLayer.Abstract;
using MaleFashion.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaleFashion.DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly MaleFashionContext _context;

        public GenericRepository(MaleFashionContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            
        }

        public async Task<List<T>> GetAllAsync()
        {
            var values = await _context.Set<T>().ToListAsync();
            return values;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var value = await _context.Set<T>().FindAsync(id);
            
            return value;
        }

        public T Update(T entity)
        {
             _context.Update(entity);
            return entity;
        }
    }
}
