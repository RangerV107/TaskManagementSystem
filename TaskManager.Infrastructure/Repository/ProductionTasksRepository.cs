using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Infrastructure
{
    public class ProductionTasksRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public ProductionTasksRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<ProductionTask>> GetAllAsync()
        {
            return await _context.ProductionTasks
                .Include(e => e.TaskType)
                .OrderBy(e => e.Title)
                .ToListAsync();
        }
        public async Task<ProductionTask> GetAsync(Guid id)
        {
            return await _context.ProductionTasks
                .Include(e => e.TaskType)
                .Where(e => e.Id == id)
                .FirstOrDefaultAsync();
        }
        public async Task<bool> UpdateAsync(ProductionTask entity)
        {
            ProductionTask existEntity = await _context.ProductionTasks.FindAsync(entity.Id);
            _context.Entry(existEntity).CurrentValues.SetValues(entity);

            //Owned type Update
            _context.Entry(existEntity.ResponsibleExecutor).CurrentValues.SetValues(entity.ResponsibleExecutor);

            //Owned type collection Update
            foreach (var c in _context.Entry(existEntity).Collections.ToArray())
                c.EntityEntry.State = EntityState.Modified;
            existEntity.CancellationBasics = entity.CancellationBasics;
            existEntity.CompletionBasics = entity.CompletionBasics;

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
        public async Task AddAsync(ProductionTask productionTask)
        {
            await _context.ProductionTasks.AddAsync(productionTask);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            ProductionTask productionTask = await _context.ProductionTasks.FindAsync(id);
            _context.Remove(productionTask);
            await _context.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            return _context.ProductionTasks.Any(e => e.Id == id);
        }
    }

}