using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManager.Domain;

namespace TaskManager.Infrastructure
{
    public class TaskTypesRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public TaskTypesRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<TaskType>> GetAllAsync()
        {
            return await _context.TaskTypes
                .Include(e => e.ProductionTasks)
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
        public async Task<TaskType> GetAsync(Guid id)
        {
            return await _context.TaskTypes.FindAsync(id);
        }
        public async Task<bool> UpdateAsync(TaskType entity)
        {
            TaskType existEntity = await _context.TaskTypes.FindAsync(entity.Id);
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
        public async Task AddAsync(TaskType productionTask)
        {
            await _context.TaskTypes.AddAsync(productionTask);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            TaskType productionTask = await _context.TaskTypes.FindAsync(id);
            _context.Remove(productionTask);
            await _context.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            return _context.TaskTypes.Any(e => e.Id == id);
        }
    }




}
