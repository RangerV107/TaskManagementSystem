using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Infrastructure
{
    public class ProductionSubTasksRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public ProductionSubTasksRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ProductionSubTask>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
        public async Task<ProductionSubTask> GetAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        public async Task<bool> UpdateAsync(ProductionSubTask entity)
        {
            ProductionSubTask existEntity = await _context.Tasks.FindAsync(entity.Id);
            _context.Entry(existEntity).CurrentValues.SetValues(entity);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(entity.Id))
                {
                    return false;
                }
            }
            return true;
        }
        public async Task AddAsync(ProductionSubTask productionTask)
        {
            await _context.Tasks.AddAsync(productionTask);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            ProductionSubTask productionTask = await _context.Tasks.FindAsync(id);
            _context.Remove(productionTask);
            await _context.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }

}
