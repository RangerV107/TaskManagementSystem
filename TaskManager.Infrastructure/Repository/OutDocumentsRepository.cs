using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain;

namespace TaskManager.Infrastructure
{
    public class OutDocumentsRepository
    {
        private readonly Context _context;
        public Context UnitOfWork
        {
            get
            {
                return _context;
            }
        }
        public OutDocumentsRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<OutDocument>> GetAllAsync()
        {
            return await _context.OutDocuments
                .OrderBy(e => e.Name)
                .ToListAsync();
        }
        public async Task<OutDocument> GetAsync(Guid id)
        {
            return await _context.OutDocuments.FindAsync(id);
        }
        public async Task<bool> UpdateAsync(OutDocument entity)
        {
            OutDocument existEntity = await _context.OutDocuments.FindAsync(entity.Id);
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
        public async Task AddAsync(OutDocument productionTask)
        {
            await _context.OutDocuments.AddAsync(productionTask);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            OutDocument productionTask = await _context.OutDocuments.FindAsync(id);
            _context.Remove(productionTask);
            await _context.SaveChangesAsync();
        }

        public bool Exists(Guid id)
        {
            return _context.OutDocuments.Any(e => e.Id == id);
        }
    }


}
