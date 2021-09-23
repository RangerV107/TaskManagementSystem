using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Infrastructure
{
    public class InDocumentsRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public InDocumentsRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<InDocument>> GetAllAsync()
        {
            return await _context.InDocuments
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
        public async Task<InDocument> GetAsync(Guid id)
        {
            return await _context.InDocuments.FindAsync(id);
        }
        public async Task<bool> UpdateAsync(InDocument entity)
        {
            InDocument existEntity = await _context.InDocuments.FindAsync(entity.Id);
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
        public async Task AddAsync(InDocument productionTask)
        {
            await _context.InDocuments.AddAsync(productionTask);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            InDocument productionTask = await _context.InDocuments.FindAsync(id);
            _context.Remove(productionTask);
            await _context.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            return _context.InDocuments.Any(e => e.Id == id);
        }
    }


}
